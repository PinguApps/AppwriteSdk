using System;
using System.Text.Json;
using System.Threading.Tasks;
using Appwrite.Client.Internals;
using Appwrite.Client.Models;

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

    public async Task<AppwriteResult<User>> GetAccount()
    {
        try
        {
            var result = await _accountApi.GetAccountAsync(Session);

            if (result.IsSuccessStatusCode)
            {
                if (result.Content is null)
                {
                    return new AppwriteResult<User>(new InternalError("Response content was null"));
                }

                return new AppwriteResult<User>(result.Content);
            }

            if (result.Error?.Content is null)
            {
                throw new Exception("Unknown error encountered.");
            }

            var error = JsonSerializer.Deserialize<AppwriteError>(result.Error.Content);

            return new AppwriteResult<User>(error!);

        }
        catch (Exception e)
        {
            return new AppwriteResult<User>(new InternalError(e.Message));
        }
    }
}
