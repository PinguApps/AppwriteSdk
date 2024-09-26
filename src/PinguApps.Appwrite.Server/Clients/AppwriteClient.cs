namespace PinguApps.Appwrite.Server.Clients;
public class AppwriteClient : IAppwriteClient
{
    public IAccountClient Account { get; }

    public AppwriteClient(IAccountClient accountServer)
    {
        Account = accountServer;
    }
}
