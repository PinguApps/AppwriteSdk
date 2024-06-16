using System;
using Appwrite.Client.Handlers;
using Appwrite.Client.Internals;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Appwrite.Client;
public static class ServiceCollectionExtensions
{
    // Delegating handler to set project ID, endpoint.

    public static IServiceCollection AddAppwriteClient(this IServiceCollection services, string projectId, string endpoint = "https://cloud.appwrite.io/v1")
    {
        services.AddTransient(sp => new HeaderHandler(projectId));

        services.AddRefitClient<IAccountApi>()
            .ConfigureHttpClient(x => x.BaseAddress = new Uri(endpoint))
            .AddHttpMessageHandler<HeaderHandler>();

        services.AddSingleton<AccountClient>();
        services.AddSingleton<AppwriteClient>();

        return services;
    }
}
