﻿using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Client.Handlers;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Shared;
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
        services.AddSingleton(x => new HeaderHandler(projectId));
        services.AddSingleton<ClientCookieSessionHandler>();

        services.AddRefitClient<IAccountApi>(refitSettings)
            .ConfigureHttpClient(x => x.BaseAddress = new Uri(endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddHttpMessageHandler<ClientCookieSessionHandler>();

        services.AddSingleton(new Config(endpoint, projectId));

        services.AddSingleton<IAccountClient, AccountClient>();
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
        services.AddSingleton(sp => new HeaderHandler(projectId));

        services.AddRefitClient<IAccountApi>(refitSettings)
            .ConfigureHttpClient(x => x.BaseAddress = new Uri(endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .ConfigurePrimaryHttpMessageHandler((handler, sp) =>
            {
                if (handler is HttpClientHandler clientHandler)
                {
                    clientHandler.UseCookies = false;
                }
            });

        services.AddSingleton(new Config(endpoint, projectId));

        services.AddSingleton<IAccountClient, AccountClient>();
        services.AddSingleton<IAppwriteClient, AppwriteClient>();

        return services;
    }
}
