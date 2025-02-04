using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Client.Handlers;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Converters;
using Polly;
using Polly.Extensions.Http;
using Refit;

namespace PinguApps.Appwrite.Client;

/// <summary>
/// Provides extensions to IServiceCollection, to enable adding the SDK to your DI container
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all necessary components for the Client SDK to work as a singleton. Best used on client-side
    /// </summary>
    /// <param name="services">The service collection to add to</param>
    /// <param name="projectId">Your Appwrite Project ID</param>
    /// <param name="endpoint">Your Appwrite Endpoint. Defaults to the cloud endpoint.</param>
    /// <param name="configureResiliencePolicy">Custom resilience policy options to customise the SDK.</param>
    /// <param name="refitSettings">Custom refit settings to customise the SDK.</param>
    /// <returns>The service collection, enabling chaining</returns>
    public static IServiceCollection AddAppwriteClient(this IServiceCollection services, string projectId, string endpoint = "https://cloud.appwrite.io/v1",
        Action<ResiliencePolicyOptions>? configureResiliencePolicy = null, RefitSettings? refitSettings = null)
    {
        var policyOptions = new ResiliencePolicyOptions();
        configureResiliencePolicy?.Invoke(policyOptions);

        services.AddKeyedSingleton("Client", new Config(endpoint, projectId));

        services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(sp =>
            CreateResiliencePolicy(sp.GetRequiredService<ILogger<ResiliencePolicy>>(), policyOptions));

        services.AddTransient<HeaderHandler>();
        services.AddTransient<ClientCookieSessionHandler>();

        var customRefitSettings = AddSerializationConfigToRefitSettings(refitSettings);

        RegisterRefitClient<IAccountApi>(services, customRefitSettings, endpoint, true);
        RegisterRefitClient<ITeamsApi>(services, customRefitSettings, endpoint, true);
        RegisterRefitClient<IDatabasesApi>(services, customRefitSettings, endpoint, true);

        // Register business logic clients
        RegisterBusinessClients(services, true);

        return services;
    }

    /// <summary>
    /// Adds all necessary components for the Client SDK such that session will not be remembered. Best used on server-side to perform client SDK abilities on behalf of users
    /// </summary>
    /// <param name="services">The service collection to add to</param>
    /// <param name="projectId">Your Appwrite Project ID</param>
    /// <param name="endpoint">Your Appwrite Endpoint. Defaults to the could endpoint.</param>
    /// <param name="configureResiliencePolicy">Custom resilience policy options to customise the SDK.</param>
    /// <param name="refitSettings">Custom refit settings to customise the SDK.</param>
    /// <returns>The service collection, enabling chaining</returns>
    public static IServiceCollection AddAppwriteClientForServer(this IServiceCollection services, string projectId, string endpoint = "https://cloud.appwrite.io/v1",
        Action<ResiliencePolicyOptions>? configureResiliencePolicy = null, RefitSettings? refitSettings = null)
    {
        var policyOptions = new ResiliencePolicyOptions();
        configureResiliencePolicy?.Invoke(policyOptions);

        services.AddKeyedSingleton("Client", new Config(endpoint, projectId));

        services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(sp =>
            CreateResiliencePolicy(sp.GetRequiredService<ILogger<ResiliencePolicy>>(), policyOptions));

        services.AddTransient<HeaderHandler>();

        var customRefitSettings = AddSerializationConfigToRefitSettings(refitSettings);

        // Register API clients
        RegisterRefitClient<IAccountApi>(services, customRefitSettings, endpoint, false);
        RegisterRefitClient<ITeamsApi>(services, customRefitSettings, endpoint, false);
        RegisterRefitClient<IDatabasesApi>(services, customRefitSettings, endpoint, false);

        // Register business logic clients
        RegisterBusinessClients(services, false);

        return services;
    }

    private static void RegisterRefitClient<T>(IServiceCollection services, RefitSettings refitSettings,
        string endpoint, bool includeSessionHandler)
        where T : class
    {
        var builder = services.AddRefitClient<T>(refitSettings)
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(endpoint);
                client.DefaultRequestHeaders.UserAgent.ParseAdd(BuildUserAgent());
                client.Timeout = TimeSpan.FromSeconds(30);
            })
            .AddHttpMessageHandler<HeaderHandler>()
            .AddPolicyHandler((sp, _) => sp.GetRequiredService<IAsyncPolicy<HttpResponseMessage>>());

        if (includeSessionHandler)
        {
            builder.AddHttpMessageHandler<ClientCookieSessionHandler>();
        }
        else
        {
            builder.ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);
        }
    }

    private static void RegisterBusinessClients(IServiceCollection services, bool asSingleton)
    {
        if (asSingleton)
        {
            RegisterSingletonClients(services);
        }
        else
        {
            RegisterScopedClients(services);
        }
    }

    private static void RegisterSingletonClients(IServiceCollection services)
    {
        services.AddSingleton<IClientAccountClient>(sp =>
        {
            var api = sp.GetRequiredService<IAccountApi>();
            var config = sp.GetRequiredKeyedService<Config>("Client");
            return new ClientAccountClient(api, config);
        });

        services.AddSingleton<IClientTeamsClient>(sp =>
        {
            var api = sp.GetRequiredService<ITeamsApi>();
            var config = sp.GetRequiredKeyedService<Config>("Client");
            return new ClientTeamsClient(api, config);
        });

        services.AddSingleton<IClientDatabasesClient>(sp =>
        {
            var api = sp.GetRequiredService<IDatabasesApi>();
            return new ClientDatabasesClient(api);
        });

        services.AddSingleton<IClientAppwriteClient, ClientAppwriteClient>();
        services.AddSingleton(x => new Lazy<IClientAppwriteClient>(() =>
            x.GetRequiredService<IClientAppwriteClient>()));
    }

    private static void RegisterScopedClients(IServiceCollection services)
    {
        services.AddScoped<IClientAccountClient>(sp =>
        {
            var api = sp.GetRequiredService<IAccountApi>();
            var config = sp.GetRequiredKeyedService<Config>("Client");
            return new ClientAccountClient(api, config);
        });

        services.AddScoped<IClientTeamsClient>(sp =>
        {
            var api = sp.GetRequiredService<ITeamsApi>();
            var config = sp.GetRequiredKeyedService<Config>("Client");
            return new ClientTeamsClient(api, config);
        });

        services.AddScoped<IClientDatabasesClient>(sp =>
        {
            var api = sp.GetRequiredService<IDatabasesApi>();
            return new ClientDatabasesClient(api);
        });

        services.AddScoped<IClientAppwriteClient, ClientAppwriteClient>();
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

        return $"PinguAppsAppwriteDotNetClientSdk/{Constants.Version} (.NET/{dotnetVersion}; {RuntimeInformation.OSDescription.Trim()})";
    }

    // Small helper class to avoid logger type conflicts
    internal class ResiliencePolicy { }
}
