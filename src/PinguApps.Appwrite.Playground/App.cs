﻿using Microsoft.Extensions.Configuration;
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
        //_client.SetSession(_session);

        Console.WriteLine(_client.Session);

        var response = _client.Account.CreateOauth2Session(new Shared.Requests.CreateOauth2SessionRequest
        {
            Provider = "google",
            SuccessUri = "https://localhost:5001/success",
            FailureUri = "https://localhost:5001/fail",
            Scopes = ["scope1", "scope2"]
        });

        Console.WriteLine(response.Result.Match(
            account => account.ToString(),
            appwriteError => appwriteError.Message,
            internalERror => internalERror.Message));

        Console.WriteLine(_client.Session);
    }
}
