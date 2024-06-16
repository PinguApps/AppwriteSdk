using Appwrite.Client;
using Microsoft.Extensions.Configuration;

namespace Appwrite.Playground;
internal class App
{
    private readonly AppwriteClient _client;
    private readonly string? _session;

    public App(AppwriteClient client, IConfiguration config)
    {
        _client = client;
        _session = config.GetValue<string>("Session");
    }

    public async Task Run(string[] args)
    {
        _client.SetSession(_session);

        var account = await _client.GetAccount();
    }
}
