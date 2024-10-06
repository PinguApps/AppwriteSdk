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
        var request = new CreateUserWithBcryptPasswordRequest()
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "$2y$10$I1A85SWJhLzjIFatLK7/SuFFBDML1J7RQzWzF5/38bMPPOWK/gsqC"
        };

        var response = await _server.Users.CreateUserWithBcryptPassword(request);

        Console.WriteLine(response.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
