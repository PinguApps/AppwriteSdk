using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Realtime;
using PinguApps.Appwrite.Shared;

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
        Task.Run(async () =>
        {
            using (var _ = new AppwriteHeaderScope("X-Forwarded-For", "1.2.3.4"))
            {
                var result = await _server.Account.CreateAnonymousSession();

                Console.WriteLine(result.Result);
            }
        });

        var result2 = await _server.Account.CreateAnonymousSession();

        Console.WriteLine(result2.Result);

        Console.ReadKey();
    }
}
