using PinguApps.Appwrite.Client.Clients;

namespace PinguApps.Appwrite.Client;

/// <inheritdoc/>
public class ClientAppwriteClient : IClientAppwriteClient, ISessionAware
{
    /// <inheritdoc/>
    public IClientAccountClient Account { get; }

    /// <inheritdoc/>
    public IClientTeamsClient Teams { get; }

    /// <inheritdoc/>
    public IClientDatabasesClient Databases { get; }

    public ClientAppwriteClient(IClientAccountClient accountClient, IClientTeamsClient teams, IClientDatabasesClient databasesClient)
    {
        Account = accountClient;
        Teams = teams;
        Databases = databasesClient;
    }

    string? ISessionAware.Session { get; set; }

    ISessionAware? _sessionAware;
    /// <inheritdoc/>
    public string? Session => GetSession();
    private string? GetSession()
    {
        if (_sessionAware is null)
        {
            _sessionAware = this;
        }

        return _sessionAware.Session;
    }

    /// <inheritdoc/>
    public void SetSession(string? session)
    {
        (this as ISessionAware).UpdateSession(session);
        (Account as ISessionAware)!.UpdateSession(session);
        (Teams as ISessionAware)!.UpdateSession(session);
        (Databases as ISessionAware)!.UpdateSession(session);
    }
}
