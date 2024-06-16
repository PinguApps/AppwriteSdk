using Microsoft.Extensions.DependencyInjection;

namespace PinguApps.Appwrite.Server;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppwriteServer(this IServiceCollection services, string projectId, string apiKey, string endpoint = "https://cloud.appwrite.io/v1")
    {


        return services;
    }
}
