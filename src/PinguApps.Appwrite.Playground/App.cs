using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Utils;

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
            UserId = "664aac1a00113f82e620"
        };

        var response = await _server.Users.CreateSession(request);

        Console.WriteLine(response.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));

        _client.SetSession(TokenUtils.GetSessionToken("664aac1a00113f82e620", response.Result.AsT0.Secret));
        Console.WriteLine(_client.Session);
        var acc = await _client.Account.Get();

    }
}
