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

        var request = new CreateSessionRequest
        {
            UserId = "664aac1a00113f82e620",
            Secret = "524366"
        };

        Console.WriteLine($"Session: {_client.Session}");

        var result = await _client.Account.CreateSession(request);

        Console.WriteLine($"Session: {_client.Session}");

        result.Result.Switch(
            account => Console.WriteLine(string.Join(',', account)),
            appwriteError => Console.WriteLine(appwriteError.Message),
            internalError => Console.WriteLine(internalError.Message)
        );

        Console.WriteLine("Getting Account...");

        var account = await _client.Account.Get();

        Console.WriteLine(account.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));
    }
}
