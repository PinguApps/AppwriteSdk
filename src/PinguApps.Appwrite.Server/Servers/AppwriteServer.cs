namespace PinguApps.Appwrite.Server.Servers;
public class AppwriteServer : IAppwriteServer
{
    public IAccountServer Account { get; }

    public AppwriteServer(IAccountServer accountServer)
    {
        Account = accountServer;
    }
}
