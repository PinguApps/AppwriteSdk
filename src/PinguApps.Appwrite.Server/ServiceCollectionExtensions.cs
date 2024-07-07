using System;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Handlers;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Servers;
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
        services.AddSingleton(sp => new HeaderHandler(projectId, apiKey));

        services.AddRefitClient<IAccountApi>(refitSettings)
            .ConfigureHttpClient(x => x.BaseAddress = new Uri(endpoint))
            .AddHttpMessageHandler<HeaderHandler>();

        services.AddSingleton<IAccountServer, AccountServer>();
        services.AddSingleton<IAppwriteServer, AppwriteServer>();

        return services;
    }
}
