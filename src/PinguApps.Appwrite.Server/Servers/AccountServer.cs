using System;
using System.Text.Json;
using System.Threading.Tasks;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Servers;
public class AccountServer : IAccountServer
{
    private readonly IAccountApi _accountApi;

    public AccountServer(IAccountApi accountApi)
    {
        _accountApi = accountApi;
    }

    public async Task<AppwriteResult<User>> Get(string? session)
    {
        try
        {
            var result = await _accountApi.GetAccountAsync(session);

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
