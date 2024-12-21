using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Clients;
using PinguApps.Appwrite.Server.Handlers;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Converters;
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
    /// <param name="refitSettings">Custom refit settings to customise the SDK.</param>
    /// <returns>The service collection, enabling chaining</returns>
    public static IServiceCollection AddAppwriteServer(this IServiceCollection services, string projectId, string apiKey, string endpoint = "https://cloud.appwrite.io/v1", RefitSettings? refitSettings = null)
    {
        var customRefitSettings = AddSerializationConfigToRefitSettings(refitSettings);

        services.AddKeyedSingleton("Server", new Config(endpoint, projectId, apiKey));
        services.AddTransient<HeaderHandler>();

        services.AddRefitClient<IAccountApi>(customRefitSettings)
            .ConfigureHttpClient(x => ConfigureHttpClient(x, endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .ConfigurePrimaryHttpMessageHandler(ConfigurePrimaryHttpMessageHandler);

        services.AddRefitClient<IUsersApi>(customRefitSettings)
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
            var config = sp.GetRequiredKeyedService<Config>("Server");
            return new AccountClient(api, config);
        });
        services.AddSingleton<IUsersClient>(sp =>
        {
            var api = sp.GetRequiredService<IUsersApi>();
            var config = sp.GetRequiredKeyedService<Config>("Server");
            return new UsersClient(api, config);
        });
        services.AddSingleton<ITeamsClient>(sp =>
        {
            var api = sp.GetRequiredService<ITeamsApi>();
            var config = sp.GetRequiredKeyedService<Config>("Server");
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

        return $"PinguAppsAppwriteDotNetServerSdk/{Constants.Version} (.NET/{dotnetVersion}; {RuntimeInformation.OSDescription.Trim()})";
    }
}
