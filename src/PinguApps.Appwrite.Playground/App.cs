using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Shared.Requests.Databases;

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
        var key = "url";
        var newKey = $"new_{key}";

        var createRequest = new CreateRelationshipAttributeRequest()
        {
            DatabaseId = "6748b44d000b2b0e73ac",
            CollectionId = "6748bb30002a12d4708f",
            Key = key,
            RelatedCollectionId = "674f57a30011310c0b3c"
        };

        var createResponse = await _server.Databases.CreateRelationshipAttribute(createRequest);

        Console.WriteLine(createResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));

        Console.WriteLine("#############################################################################################");
        Console.ReadKey();

        var updateRequest = new UpdateRelationshipAttributeRequest()
        {
            DatabaseId = "6748b44d000b2b0e73ac",
            CollectionId = "6748bb30002a12d4708f",
            Key = key,
            NewKey = newKey
        };

        var updateResponse = await _server.Databases.UpdateRelationshipAttribute(updateRequest);

        Console.WriteLine(updateResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
