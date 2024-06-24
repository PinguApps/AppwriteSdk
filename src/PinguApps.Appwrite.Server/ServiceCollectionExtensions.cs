using System;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Handlers;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Servers;
using Refit;

namespace PinguApps.Appwrite.Server;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppwriteServer(this IServiceCollection services, string projectId, string apiKey, string endpoint = "https://cloud.appwrite.io/v1")
    {
        services.AddSingleton(sp => new HeaderHandler(projectId, apiKey));

        services.AddRefitClient<IAccountApi>()
            .ConfigureHttpClient(x => x.BaseAddress = new Uri(endpoint))
            .AddHttpMessageHandler<HeaderHandler>()
            .AddStandardResilienceHandler();

        services.AddSingleton<IAccountServer, AccountServer>();
        services.AddSingleton<IAppwriteServer, AppwriteServer>();

        return services;
    }
}
