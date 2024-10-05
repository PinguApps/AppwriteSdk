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
        var response = await _client.Account.UpdatePhoneVerificationConfirmation(new UpdatePhoneVerificationConfirmationRequest
        {
            UserId = "664aac1a00113f82e620",
            Secret = "325437"
        });

        Console.WriteLine(response.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
