using PinguApps.Appwrite.Client.Clients;

namespace PinguApps.Appwrite.Client;

public interface IAppwriteClient : ISessionAware
{
    IAccountClient Account { get; }

    void SetSession(string? session);
}
