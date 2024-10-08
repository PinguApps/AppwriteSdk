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
        var request = new CreateUserWithScryptModifiedPasswordRequest()
        {
            Email = "pingu@example.com",
            Password = "dbb97714c09bad417bb51288abd2c049c557e5e617839a7bc8c615492db859b57624366de72f04b9d4c3e6452a497a67a36f1afcc481d6d69f6da9e5f03598d7",
            PasswordSalt = "MySuperSalt",
            PasswordSaltSeparator = ";",
            PasswordSignerKey = "MySuperSignerKey"
        };

        var response = await _server.Users.CreateUserWithScryptModifiedPassword(request);

        Console.WriteLine(response.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
