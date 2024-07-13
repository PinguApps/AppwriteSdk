using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Servers;
public class AccountServer : IAccountServer
{
    private readonly IAccountApi _accountApi;

    public AccountServer(IServiceProvider services)
    {
        _accountApi = services.GetRequiredService<IAccountApi>();
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<AppwriteResult<Token>> CreateEmailToken(CreateEmailTokenRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateEmailToken(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Token>();
        }
    }
}
