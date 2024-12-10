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
        var request = CreateDocumentRequest.CreateBuilder()
            .WithDatabaseId("67541a2800221703e717")
            .WithCollectionId("67541a37001514b81821")
            .WithData(new
            {
                test = "TEST",
                boolAttribute = false
            })
            .Build();

        var serverResponse = await _server.Databases.CreateDocument(request);

        Console.WriteLine(serverResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));

        Console.WriteLine("###############################################################################");

        request.DocumentId = IdUtils.GenerateUniqueId();

        var clientResponse = await _client.Databases.CreateDocument(request);

        Console.WriteLine(clientResponse.Result.Match(
            result => result.ToString(),
            appwriteError => appwriteError.Message,
            internalError => internalError.Message));
    }
}
