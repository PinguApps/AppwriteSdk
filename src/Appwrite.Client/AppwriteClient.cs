using System.Threading.Tasks;
using Appwrite.Client.Internals;
using Refit;

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

    public async Task<IApiResponse<string>> GetAccount()
    {
        var result = await _accountApi.GetAccountAsync(Session);

        return result;
    }
}
