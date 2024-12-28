using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Shared.Requests.Databases;

namespace PinguApps.Appwrite.Playground;
internal class App
{
    private readonly Client.IClientAppwriteClient _client;
    private readonly Server.Clients.IAppwriteClient _server;
    private readonly string? _session;

    public App(Client.IClientAppwriteClient client, Server.Clients.IAppwriteClient server, IConfiguration config)
    {
        _client = client;
        _server = server;
        _session = config.GetValue<string>("Session");
    }

    private class Rec
    {
        [JsonPropertyName("test")]
        public string Test { get; set; } = string.Empty;

        [JsonPropertyName("boolAttribute")]
        public bool BoolAttribute { get; set; }
    }

    public async Task Run(string[] args)
    {
        var before = new Rec { Test = "test", BoolAttribute = false };
        var after = new Rec { Test = "test", BoolAttribute = true };

        var request = UpdateDocumentRequest.CreateBuilder()
            .WithDatabaseId("67541a2800221703e717")
            .WithCollectionId("67541a37001514b81821")
            .WithDocumentId("67541af9000055e59e59")
            .WithChanges(before, after)
            .Build();

        var serverResponse = await _server.Databases.UpdateDocument(request);

        Console.WriteLine(serverResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));

        Console.WriteLine("###############################################################################");

        //Console.ReadKey();
        //request.Data["test"] = "Client Update";

        //var clientResponse = await _client.Databases.UpdateDocument(request);

        //Console.WriteLine(clientResponse.Result.Match(
        //    result => result.ToString(),
        //    appwriteError => appwriteError.Message,
        //    internalError => internalError.Message));
    }
}
