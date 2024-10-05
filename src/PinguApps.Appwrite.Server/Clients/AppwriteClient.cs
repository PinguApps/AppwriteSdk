namespace PinguApps.Appwrite.Server.Clients;
public class AppwriteClient : IAppwriteClient
{
    public IAccountClient Account { get; }
    public IUsersClient Users { get; }

    public AppwriteClient(IAccountClient accountClient, IUsersClient usersClient)
    {
        Account = accountClient;
        Users = usersClient;
    }
}
