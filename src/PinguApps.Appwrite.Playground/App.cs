using Microsoft.Extensions.Configuration;
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

        var request = new UpdateTeamMembershipStatusRequest()
        {
            TeamId = "67142b78001c379958cb",
            MembershipId = "671531b0251d3541ae46",
            UserId = "67143ec991a30b2a73cb",
            Secret = "43c2c5f0d3b2aa4f9a519be67f2b866ae8a44f132acd6dba32401cf7c7f1185e9389c8fce3bfa1e8675915bf06a2ccaedc4a756e10fac27f10103111d32a05046301fd689598bb6d25275832be90b4be682b9217ef648d1f01e97be8e10b0a8b4b424fa092e6d987e18fd65a431ed493edad846b2d3709a379e44d1df0870701"
        };

        //var clientResponse = await _client.Teams.UpdateTeamMembershipStatus(request);

        //var request = new CreateTeamMembershipRequest()
        //{
        //    TeamId = "67142b78001c379958cb",
        //    Email = "pingu@example.com",
        //    Name = "TEST",
        //    Url = "https://localhost:1234/abc"
        //};

        //var clientResponse = await _client.Teams.CreateTeamMembership(request);

        //Console.WriteLine(clientResponse.Result.Match(
        //    result => result.ToString(),
        //    appwriteError => appwriteError.Message,
        //    internalError => internalError.Message));

        Console.WriteLine("############################################################################");

        var serverResponse = await _server.Teams.UpdateTeamMembershipStatus(request);

        Console.WriteLine(serverResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
