using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Client;
using PinguApps.Appwrite.Server.Servers;

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

        Console.WriteLine("Getting Session...");

        //var response = await _client.Account.CreateEmailToken(new CreateEmailTokenRequest
        //{
        //    Email = "pingu@pinguapps.com",
        //    UserId = "664aac1a00113f82e620"
        //});

        //var response = await _client.Account.CreateSession(new CreateSessionRequest
        //{
        //    UserId = "664aac1a00113f82e620",
        //    Secret = "623341"
        //});

        var response = await _client.Account.GetSession("66a810f2e55b1329e25b");

        var response2 = await _client.Account.UpdateSession("66a810f2e55b1329e25b");

        Console.WriteLine(response.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));

        Console.WriteLine(response2.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));
    }
}
