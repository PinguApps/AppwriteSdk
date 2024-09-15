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
        _client.SetSession(_session);

        var response = await _client.Account.Get();

        Console.WriteLine(response.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));

        var r2 = await _client.Account.DeleteSession(new DeleteSessionRequest());

        Console.WriteLine(r2.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));

        var r3 = await _client.Account.Get();

        Console.WriteLine(r3.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));
    }
}
