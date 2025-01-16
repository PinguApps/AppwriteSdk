using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
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
/// Provides extenions to IServiceCollection, to enable adding the SDK to your DI container
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all necessary components for the Client SDK to work as a singleton. Best used on client-side
    /// </summary>
    /// <param name="services">The service collection to add to</param>
    /// <param name="projectId">Your Appwrite Project ID</param>
    /// <param name="endpoint">Your Appwrite Endpoint. Defaults to the cloud endpoint.</param>
    /// <param name="refitSettings">Custom refit settings to customise the SDK.</param>
    /// <returns>The service collection, enabling chaining</returns>
    public static IServiceCollection AddAppwriteClient(this IServiceCollection services, string projectId, string endpoint = "https://cloud.appwrite.io/v1", RefitSettings? refitSettings = null)
    {
        var customRefitSettings = AddSerializationConfigToRefitSettings(refitSettings);

        services.AddKeyedSingleton("Client", new Config(endpoint, projectId));
        services.AddTransient<HeaderHandler>();
        services.AddTransient<ClientCookieSessionHandler>();

        services.AddRefitClient<IAccountApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<IAccountApi>(services)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<IAccountApi>(services)))
            .AddHttpMessageHandler<ClientCookieSessionHandler>();

        services.AddRefitClient<ITeamsApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<ITeamsApi>(services)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<ITeamsApi>(services)))
            .AddHttpMessageHandler<ClientCookieSessionHandler>();

        services.AddRefitClient<IDatabasesApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<IDatabasesApi>(services)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<IDatabasesApi>(services)))
            .AddHttpMessageHandler<ClientCookieSessionHandler>();

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
        services.AddSingleton(x => new Lazy<IClientAppwriteClient>(() => x.GetRequiredService<IClientAppwriteClient>()));

        return services;
    }

    /// <summary>
    /// Adds all necessary components for the Client SDK such that session will not be remembered. Best used on server-side to perform client SDK abilities on behalf of users
    /// </summary>
    /// <param name="services">The service collection to add to</param>
    /// <param name="projectId">Your Appwrite Project ID</param>
    /// <param name="endpoint">Your Appwrite Endpoint. Defaults to the could endpoint.</param>
    /// <param name="refitSettings">Custom refit settings to customise the SDK.</param>
    /// <returns>The service collection, enabling chaining</returns>
    public static IServiceCollection AddAppwriteClientForServer(this IServiceCollection services, string projectId, string endpoint = "https://cloud.appwrite.io/v1", RefitSettings? refitSettings = null)
    {
        var customRefitSettings = AddSerializationConfigToRefitSettings(refitSettings);

        services.AddKeyedSingleton("Client", new Config(endpoint, projectId));
        services.AddTransient<HeaderHandler>();

        services.AddRefitClient<IAccountApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<IAccountApi>(services)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<IAccountApi>(services)))
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddRefitClient<ITeamsApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<ITeamsApi>(services)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<ITeamsApi>(services)))
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddRefitClient<IDatabasesApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetRetryPolicy<IDatabasesApi>(services)))
            .AddHttpMessageHandler(() => new PolicyHttpMessageHandler(GetCircuitBreakerPolicy<IDatabasesApi>(services)))
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

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

        return services;
    }

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

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy<T>(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetRequiredService<ILogger<T>>();

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutException>()
            .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
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

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy<T>(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetRequiredService<ILogger<T>>();

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: 5,
                durationOfBreak: TimeSpan.FromSeconds(30),
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

        return $"PinguAppsAppwriteDotNetClientSdk/{Constants.Version} (.NET/{dotnetVersion}; {RuntimeInformation.OSDescription.Trim()})";
    }
}
