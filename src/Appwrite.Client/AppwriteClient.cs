using System.Threading.Tasks;
using Appwrite.Client.Internals;

namespace Appwrite.Client;
public class AppwriteClient
{
    private readonly IAccountApi _accountApi;

    public AppwriteClient(IAccountApi accountApi)
    {
        _accountApi = accountApi;
    }

    public string? Session { get; private set; }

    public void SetSession(string? session) => Session = session;

    public async Task GetAccount()
    {
        var result = await _accountApi.GetAccountAsync(Session);
    }
}
