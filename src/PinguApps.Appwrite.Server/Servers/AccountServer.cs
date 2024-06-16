using PinguApps.Appwrite.Server.Internals;

namespace PinguApps.Appwrite.Server.Servers;
public class AccountServer : IAccountServer
{
    private readonly IAccountApi _accountApi;

    public AccountServer(IAccountApi accountApi)
    {
        _accountApi = accountApi;
    }
}
