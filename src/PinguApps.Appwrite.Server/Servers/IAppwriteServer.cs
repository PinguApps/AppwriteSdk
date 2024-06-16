namespace PinguApps.Appwrite.Server.Servers;

public interface IAppwriteServer
{
    IAccountServer Account { get; }
}