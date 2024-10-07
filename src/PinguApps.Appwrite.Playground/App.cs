using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Shared.Requests.Users;

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
        var request = new CreateUserWithMd5PasswordRequest()
        {
            Email = "pingu@example.com",
            Password = "34819d7beeabb9260a5c854bc85b3e44"
        };

        var response = await _server.Users.CreateUserWithMd5Password(request);

        Console.WriteLine(response.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
