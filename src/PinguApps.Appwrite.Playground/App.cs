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

        var request = new UpdatePhoneRequest
        {
            Password = "sword",
            Phone = "14155552671"
        };

        var f = request.IsValid();

        var result = await _client.Account.UpdatePhone(request);

        result.Result.Switch(
            account => Console.WriteLine(account.Email),
            appwriteError => Console.WriteLine(appwriteError.Message),
            internalError => Console.WriteLine(internalError.Message)
        );
    }
}
