using System;
using System.Threading.Tasks;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Servers;
public class AccountServer : IAccountServer
{
    private readonly IAccountApi _accountApi;

    public AccountServer(IAccountApi accountApi)
    {
        _accountApi = accountApi;
    }

    public async Task<AppwriteResult<User>> Create(CreateAccountRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateAccount(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }
}
