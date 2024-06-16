using System;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Client.Handlers;
using PinguApps.Appwrite.Client.Internals;
using Refit;

namespace PinguApps.Appwrite.Client;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppwriteClient(this IServiceCollection services, string projectId, string endpoint = "https://cloud.appwrite.io/v1")
    {
        services.AddTransient(sp => new HeaderHandler(projectId));

        services.AddRefitClient<IAccountApi>()
            .ConfigureHttpClient(x => x.BaseAddress = new Uri(endpoint))
            .AddHttpMessageHandler<HeaderHandler>();

        services.AddSingleton<IAccountClient, AccountClient>();
        services.AddSingleton<IAppwriteClient, AppwriteClient>();

        return services;
    }
}
