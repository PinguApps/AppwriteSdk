﻿using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Shared.Requests.Teams;

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
        _client.SetSession(_session);

        var request = new GetTeamPreferencesRequest()
        {
            TeamId = "67142b78001c379958cb"
        };

        var clientResponse = await _client.Teams.GetTeamPreferences(request);

        Console.WriteLine(clientResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));

        Console.WriteLine("############################################################################");

        var serverResponse = await _server.Teams.GetTeamPreferences(request);

        Console.WriteLine(serverResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
