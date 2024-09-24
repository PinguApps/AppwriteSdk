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
        //_client.SetSession(_session);

        Console.WriteLine(_client.Session);

        var response = await _server.Account.UpdatePhoneSession(new UpdatePhoneSessionRequest
        {
            UserId = "664aac1a00113f82e620",
            //PhoneNumber = "+44123456",
            Secret = "816076"
        });

        Console.WriteLine(response.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));


        Console.WriteLine(_client.Session);
    }
}
