using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
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
/// Provides extenions to IServiceCollection, to enable adding the SDK to your DI container
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

        var customRefitSettings = AddSerializationConfigToRefitSettings(refitSettings);

        services.AddKeyedSingleton("Server", new Config(endpoint, projectId, apiKey));
        services.AddTransient<HeaderHandler>();

        services.AddRefitClient<IAccountApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<IAccountApi>(services, policyOptions)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<IAccountApi>(services, policyOptions)))
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddRefitClient<IUsersApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<IUsersApi>(services, policyOptions)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<IUsersApi>(services, policyOptions)))
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddRefitClient<ITeamsApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<ITeamsApi>(services, policyOptions)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<ITeamsApi>(services, policyOptions)))
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddRefitClient<IDatabasesApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<IDatabasesApi>(services, policyOptions)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<IDatabasesApi>(services, policyOptions)))
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

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

        return services;
    }

    [ExcludeFromCodeCoverage]
    private static void ConfigurePrimaryHttpMessageHandler(HttpMessageHandler messageHandler, IServiceProvider serviceProvider)
    {
        if (messageHandler is HttpClientHandler clientHandler)
        {
            clientHandler.UseCookies = false;
        }
    }

    private static void ConfigureHttpClient(HttpClient client, string endpoint)
    {
        client.BaseAddress = new Uri(endpoint);
        client.DefaultRequestHeaders.UserAgent.ParseAdd(BuildUserAgent());
    }

    [ExcludeFromCodeCoverage]
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy<T>(IServiceCollection services, ResiliencePolicyOptions options)
    {
        if (options.DisableResilience)
        {
            return Policy.NoOpAsync<HttpResponseMessage>();
        }

        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetRequiredService<ILogger<T>>();

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutException>()
            .WaitAndRetryAsync(
                retryCount: options.RetryCount,
                sleepDurationProvider: options.SleepDurationProvider,
                onRetry: (exception, timeSpan, retryCount, context) =>
                {
                    logger.LogWarning(exception.Exception,
                        "Retry {RetryCount} for {Service} after {Seconds} seconds due to: {Message}",
                        retryCount,
                        typeof(T).Name,
                        timeSpan.TotalSeconds,
                        exception.Exception.Message);
                });
    }

    [ExcludeFromCodeCoverage]
    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy<T>(IServiceCollection services, ResiliencePolicyOptions options)
    {
        if (options.DisableResilience)
        {
            return Policy.NoOpAsync<HttpResponseMessage>();
        }

        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetRequiredService<ILogger<T>>();

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: options.CircuitBreakerThreshold,
                durationOfBreak: TimeSpan.FromSeconds(options.CircuitBreakerDurationSeconds),
                onBreak: (exception, duration) =>
                {
                    logger.LogError(
                        exception.Exception,
                        "Circuit breaker for {Service} opened for {Seconds} seconds due to: {Message}",
                        typeof(T).Name,
                        duration.TotalSeconds,
                        exception.Exception.Message);
                },
                onReset: () =>
                {
                    logger.LogInformation(
                        "Circuit breaker for {Service} reset",
                        typeof(T).Name);
                });
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
}
