using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PinguApps.Appwrite.Server.Clients;
using PinguApps.Appwrite.Server.Handlers;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Converters;
using Polly;
using Polly.Extensions.Http;
using Refit;

namespace PinguApps.Appwrite.Server;

/// <summary>
/// Provides extensions to IServiceCollection, to enable adding the SDK to your DI container
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all necessary components for the Server SDK
    /// </summary>
    /// <param name="services">The service collection to add to</param>
    /// <param name="projectId">Your Appwrite Project ID</param>
    /// <param name="apiKey">Your Appwrite Api Key</param>
    /// <param name="endpoint">Your Appwrite Endpoint. Defaults to the cloud endpoint.</param>
    /// <param name="configureResiliencePolicy">Custom resilience policy options to customise the SDK.</param>
    /// <param name="refitSettings">Custom refit settings to customise the SDK.</param>
    /// <returns>The service collection, enabling chaining</returns>
    public static IServiceCollection AddAppwriteServer(this IServiceCollection services, string projectId, string apiKey, string endpoint = "https://cloud.appwrite.io/v1",
        Action<ResiliencePolicyOptions>? configureResiliencePolicy = null, RefitSettings? refitSettings = null)
    {
        var policyOptions = new ResiliencePolicyOptions();
        configureResiliencePolicy?.Invoke(policyOptions);

        services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(sp =>
            CreateResiliencePolicy(sp.GetRequiredService<ILogger<ResiliencePolicy>>(), policyOptions));

        var customRefitSettings = AddSerializationConfigToRefitSettings(refitSettings);

        services.AddKeyedSingleton("Server", new Config(endpoint, projectId, apiKey));
        services.AddScoped<HeaderHandler>();

        RegisterRefitClient<IAccountApi>(services, customRefitSettings, endpoint);
        RegisterRefitClient<IUsersApi>(services, customRefitSettings, endpoint);
        RegisterRefitClient<ITeamsApi>(services, customRefitSettings, endpoint);
        RegisterRefitClient<IDatabasesApi>(services, customRefitSettings, endpoint);

        RegisterBusinessClients(services);

        return services;
    }

    private static void RegisterRefitClient<T>(IServiceCollection services, RefitSettings refitSettings, string endpoint)
        where T : class
    {
        services.AddRefitClient<T>(refitSettings)
            .ConfigureHttpClient((sp, client) =>
            {
                client.BaseAddress = new Uri(endpoint);
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(BuildUserAgent());
            })
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler)
            .AddHttpMessageHandler<HeaderHandler>()
            .AddPolicyHandler((sp, _) => sp.GetRequiredService<IAsyncPolicy<HttpResponseMessage>>());
    }

    private static void RegisterBusinessClients(IServiceCollection services)
    {
        services.AddSingleton<IServerAccountClient>(sp =>
        {
            var api = sp.GetRequiredService<IAccountApi>();
            var config = sp.GetRequiredKeyedService<Config>("Server");
            return new ServerAccountClient(api, config);
        });

        services.AddSingleton<IServerUsersClient>(sp =>
        {
            var api = sp.GetRequiredService<IUsersApi>();
            var config = sp.GetRequiredKeyedService<Config>("Server");
            return new ServerUsersClient(api, config);
        });

        services.AddSingleton<IServerTeamsClient>(sp =>
        {
            var api = sp.GetRequiredService<ITeamsApi>();
            var config = sp.GetRequiredKeyedService<Config>("Server");
            return new ServerTeamsClient(api, config);
        });

        services.AddSingleton<IServerDatabasesClient>(sp =>
        {
            var api = sp.GetRequiredService<IDatabasesApi>();
            return new ServerDatabasesClient(api);
        });

        services.AddSingleton<IServerAppwriteClient, ServerAppwriteClient>();
    }

    private static IAsyncPolicy<HttpResponseMessage> CreateResiliencePolicy(ILogger logger, ResiliencePolicyOptions options)
    {
        if (options.DisableResilience)
        {
            return Policy.NoOpAsync<HttpResponseMessage>();
        }

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutException>()
            .WaitAndRetryAsync(
                retryCount: options.RetryCount,
                sleepDurationProvider: options.SleepDurationProvider,
                onRetry: (exception, timeSpan, retryCount, context) =>
                {
                    logger.LogWarning(exception.Exception,
                        "Retry {RetryCount} after {Seconds} seconds due to: {Message}",
                        retryCount,
                        timeSpan.TotalSeconds,
                        exception.Exception.Message);
                })
            .WrapAsync(HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(options.CircuitBreakerThreshold, TimeSpan.FromSeconds(options.CircuitBreakerDurationSeconds),
                (exception, duration) =>
                {
                    logger.LogError(exception.Exception,
                        "Circuit breaker opened for {Seconds} seconds due to: {Message}",
                        duration.TotalSeconds,
                        exception.Exception.Message);
                },
                () => logger.LogInformation("Circuit breaker reset")));
    }

    [ExcludeFromCodeCoverage]
    private static void ConfigurePrimaryHttpMessageHandler(HttpMessageHandler messageHandler, IServiceProvider serviceProvider)
    {
        if (messageHandler is HttpClientHandler clientHandler)
        {
            clientHandler.UseCookies = false;
        }
        else if (messageHandler.GetType().FullName == "System.Net.Http.SocketsHttpHandler")
        {
            // Use reflection to set the UseCookies property
            PropertyInfo property = messageHandler.GetType().GetProperty("UseCookies");
            if (property is not null)
            {
                property.SetValue(messageHandler, false);
            }
        }
    }

    private static RefitSettings AddSerializationConfigToRefitSettings(RefitSettings? refitSettings)
    {
        var settings = refitSettings ?? new RefitSettings();

        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        options.Converters.Add(new SdkMarkerConverter());
        options.Converters.Add(new UpdateDocumentRequestConverter());
        options.Converters.Add(new IgnoreSdkExcludedPropertiesConverterFactory());
        options.Converters.Add(new DocumentConverter());
        options.Converters.Add(new DocumentGenericConverterFactory());
        options.Converters.Add(new DocumentListConverter());
        options.Converters.Add(new DocumentListGenericConverter());

        settings.ContentSerializer = new SystemTextJsonContentSerializer(options);

        return settings;
    }

    private static string BuildUserAgent()
    {
        var dotnetVersion = RuntimeInformation.FrameworkDescription.Replace("Microsoft .NET", ".NET").Trim();

        return $"PinguAppsAppwriteDotNetServerSdk/{Constants.Version} (.NET/{dotnetVersion}; {RuntimeInformation.OSDescription.Trim()})";
    }

    // Small helper class to avoid logger type conflicts
    internal class ResiliencePolicy { }
}
