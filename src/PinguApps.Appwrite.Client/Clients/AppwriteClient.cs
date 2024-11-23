using PinguApps.Appwrite.Client.Clients;

namespace PinguApps.Appwrite.Client;

/// <inheritdoc/>
public class AppwriteClient : IAppwriteClient, ISessionAware
{
    /// <inheritdoc/>
    public IAccountClient Account { get; }

    /// <inheritdoc/>
    public ITeamsClient Teams { get; }

    /// <inheritdoc/>
    public IDatabasesClient DatabasesClient { get; }

    public AppwriteClient(IAccountClient accountClient, ITeamsClient teams, IDatabasesClient databasesClient)
    {
        Account = accountClient;
        Teams = teams;
        DatabasesClient = databasesClient;
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
        (DatabasesClient as ISessionAware)!.UpdateSession(session);
    }
}
