namespace PinguApps.Appwrite.Client;

public interface IAppwriteClient
{
    IAccountClient Account { get; }

    void SetSession(string? session);
}
