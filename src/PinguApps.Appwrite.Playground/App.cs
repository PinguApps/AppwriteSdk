using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Client;
using PinguApps.Appwrite.Server.Servers;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Playground;
internal class App
{
    private readonly IAppwriteClient _client;
    private readonly IAppwriteServer _server;
    private readonly string? _session;

    public App(IAppwriteClient client, IAppwriteServer server, IConfiguration config)
    {
        _client = client;
        _server = server;
        _session = config.GetValue<string>("Session");
    }

    public async Task Run(string[] args)
    {
        //_client.SetSession(_session);

        //var response = await _server.Account.CreateMagicUrlToken(new CreateMagicUrlTokenRequest
        //{
        //    UserId = "",
        //    Email = "pingu@example.com",
        //    Url = "https://localhost:1234/magic",
        //    Phrase = true
        //});
        Console.WriteLine($"Session: {_client.Session}");

        var response = await _client.Account.UpdateMagicUrlSession(new UpdateMagicUrlSessionRequest
        {
            UserId = "my Id",
            Secret = "My secret"
        });

        Console.WriteLine(response.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));

        Console.WriteLine($"Session: {_client.Session}");
    }
}
