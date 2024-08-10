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

        Console.WriteLine(_client.Session);

        //var response = await _client.Account.AddAuthenticator();
        //var response = await _client.Account.Create2faChallenge(new Shared.Requests.Create2faChallengeRequest
        //{
        //    Factor = Shared.Enums.SecondFactor.Email
        //});

        var response = await _client.Account.Create2faChallengeConfirmation(new Shared.Requests.Create2faChallengeConfirmationRequest
        {
            ChallengeId = "66b771b7bdcb152aaa5b",
            Otp = "474376"
        });

        Console.WriteLine(response.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));

        Console.WriteLine(_client.Session);
    }
}
