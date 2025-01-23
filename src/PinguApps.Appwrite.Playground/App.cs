using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Realtime;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Playground;
internal class App
{
    private readonly Client.IClientAppwriteClient _client;
    private readonly Server.Clients.IServerAppwriteClient _server;
    private readonly IRealtimeClient _realtimeClient;
    private readonly string? _session;

    public App(Client.IClientAppwriteClient client, Server.Clients.IServerAppwriteClient server, IRealtimeClient realtimeClient, IConfiguration config)
    {
        _client = client;
        _server = server;
        _realtimeClient = realtimeClient;
        _session = config.GetValue<string>("Session");
    }

    public async Task Run(string[] args)
    {
        _realtimeClient.SetSession(_session);

        using (_realtimeClient.Subscribe<Document>("documents", x =>
        {
            Console.WriteLine(x.Payload);
        }))
        {
            Console.ReadKey();
        }
    }
}
