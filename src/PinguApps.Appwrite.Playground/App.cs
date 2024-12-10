using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

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
        var request = new GetDocumentRequest()
        {
            DatabaseId = "67541a2800221703e717",
            CollectionId = "67541a37001514b81821",
            DocumentId = "67541af9000055e59e59"
        };

        var serverResponse = await _server.Databases.GetDocument(request);

        Console.WriteLine(serverResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));

        Console.WriteLine("###############################################################################");

        request.Queries = [Query.Select(["test"])];

        var clientResponse = await _client.Databases.GetDocument(request);

        Console.WriteLine(clientResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
