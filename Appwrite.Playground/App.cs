using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Client;

namespace PinguApps.Appwrite.Playground;
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
        _client.SetSession("_session");

        var result = await _client.Account.Get();

        result.Result.Switch(
            account => Console.WriteLine(account.Email),
            appwriteError => Console.WriteLine(appwriteError.Message),
            internalError => Console.WriteLine(internalError.Message)
        );
    }
}
