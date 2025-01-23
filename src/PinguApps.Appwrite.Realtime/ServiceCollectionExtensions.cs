using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PinguApps.Appwrite.Realtime.Models;
using PinguApps.Appwrite.Shared;

namespace PinguApps.Appwrite.Realtime;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppwriteRealtime(this IServiceCollection services, string projectId, string endpoint = "wss://cloud.appwrite.io/v1", Action<WebSocketOptions>? configureOptions = null)
    {
        var realtimeEndpoint = GetWebsocketUrl(endpoint);

        services.AddKeyedSingleton("realtime", new Config(realtimeEndpoint, projectId));

        services.Configure<WebSocketOptions>(options =>
        {
            configureOptions?.Invoke(options);
        });

        services.AddSingleton<IRealtimeClient>(sp =>
        {
            var config = sp.GetRequiredKeyedService<Config>("realtime");
            var options = sp.GetRequiredService<IOptions<WebSocketOptions>>();
            var logger = sp.GetRequiredService<ILogger<RealtimeClient>>();

            return new RealtimeClient(options, logger, config);
        });

        return services;
    }

    public static string GetWebsocketUrl(string url)
    {
        var result = url
            .Replace("https://", "wss://")
            .Replace("http://", "ws://")
            .TrimEnd('/');

        return result.EndsWith("/realtime") ? result : $"{result}/realtime";
    }

}
