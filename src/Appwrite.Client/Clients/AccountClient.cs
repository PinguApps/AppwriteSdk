using System;
using System.Text.Json;
using System.Threading.Tasks;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client;
public class AccountClient : IAccountClient, ISessionAware
{
    private readonly IAccountApi _accountApi;

    public AccountClient(IAccountApi accountApi)
    {
        _accountApi = accountApi;
    }

    string? ISessionAware.Session { get; set; }

    ISessionAware? _sessionAware;
    public string? Session => GetSession();
    private string? GetSession()
    {
        if (_sessionAware is null)
        {
            _sessionAware = this;
        }

        return _sessionAware.Session;
    }

    public async Task<AppwriteResult<User>> Get()
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
