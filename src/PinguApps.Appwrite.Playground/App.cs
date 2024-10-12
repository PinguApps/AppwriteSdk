using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Playground;
internal class App
{
    private readonly Client.IAppwriteClient _client;
    private readonly Server.Clients.IAppwriteClient _server;
    private readonly string? _session;

    public App(Client.IAppwriteClient client, Server.Clients.IAppwriteClient server, IConfiguration config)
    {
        _client = client;
        _server = server;
        _session = config.GetValue<string>("Session");
    }

    public async Task Run(string[] args)
    {
        var request = new CreateSessionRequest()
        {
            UserId = "664aac1a00113f82e620",
            Secret = "80af6605407a3918cd9bb1796b6bfdc5d4b2dc57dad4677432d902e8bef9ba6f"
        };

        var response = await _client.Account.CreateSession(request);

        Console.WriteLine(response.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
