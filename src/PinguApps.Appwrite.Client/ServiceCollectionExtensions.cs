using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Client.Handlers;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Converters;
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

        services.AddSingleton(new Config(endpoint, projectId));
        services.AddTransient<HeaderHandler>();
        services.AddTransient<ClientCookieSessionHandler>();

        services.AddRefitClient<IAccountApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler<ClientCookieSessionHandler>();

        services.AddRefitClient<ITeamsApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler<ClientCookieSessionHandler>();

        services.AddRefitClient<IDatabasesApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler<ClientCookieSessionHandler>();

        services.AddSingleton<IAccountClient>(sp =>
        {
            var api = sp.GetRequiredService<IAccountApi>();
            var config = sp.GetRequiredService<Config>();
            return new AccountClient(api, config);
        });
        services.AddSingleton<ITeamsClient>(sp =>
        {
            var api = sp.GetRequiredService<ITeamsApi>();
            var config = sp.GetRequiredService<Config>();
            return new TeamsClient(api, config);
        });
        services.AddSingleton<IDatabasesClient>(sp =>
        {
            var api = sp.GetRequiredService<IDatabasesApi>();
            return new DatabasesClient(api);
        });
        services.AddSingleton<IAppwriteClient, AppwriteClient>();
        services.AddSingleton(x => new Lazy<IAppwriteClient>(() => x.GetRequiredService<IAppwriteClient>()));

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

        services.AddSingleton(new Config(endpoint, projectId));
        services.AddTransient<HeaderHandler>();

        services.AddRefitClient<IAccountApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddRefitClient<ITeamsApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddRefitClient<IDatabasesApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddSingleton<IAccountClient>(sp =>
        {
            var api = sp.GetRequiredService<IAccountApi>();
            var config = sp.GetRequiredService<Config>();
            return new AccountClient(api, config);
        });
        services.AddSingleton<ITeamsClient>(sp =>
        {
            var api = sp.GetRequiredService<ITeamsApi>();
            var config = sp.GetRequiredService<Config>();
            return new TeamsClient(api, config);
        });
        services.AddSingleton<IDatabasesClient>(sp =>
        {
            var api = sp.GetRequiredService<IDatabasesApi>();
            return new DatabasesClient(api);
        });
        services.AddSingleton<IAppwriteClient, AppwriteClient>();

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

    private static RefitSettings AddSerializationConfigToRefitSettings(RefitSettings? refitSettings)
    {
        var settings = refitSettings ?? new RefitSettings();

        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        options.Converters.Add(new IgnoreSdkExcludedPropertiesConverterFactory());

        settings.ContentSerializer = new SystemTextJsonContentSerializer(options);

        return settings;
    }

    private static string BuildUserAgent()
    {
        var dotnetVersion = RuntimeInformation.FrameworkDescription.Replace("Microsoft .NET", ".NET").Trim();

        return $"PinguAppsAppwriteDotNetClientSdk/{Constants.Version} (.NET/{dotnetVersion}; {RuntimeInformation.OSDescription.Trim()})";
    }
}
