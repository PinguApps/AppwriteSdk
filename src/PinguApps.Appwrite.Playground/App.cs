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
        var request = new CreateUserWithArgon2PasswordRequest()
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "p@example.com",
            Password = "$argon2i$v=19$m=16,t=2,p=1$ck5UdVZSeEVEZHFDc1VTZA$Ru/mskiTeTfoBlGqkMcKSA"
        };

        var response = await _server.Users.CreateUserWithArgon2Password(request);

        Console.WriteLine(response.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
