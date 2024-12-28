namespace PinguApps.Appwrite.Server.Clients;

/// <inheritdoc/>
public class ServerAppwriteClient : IServerAppwriteClient
{
    /// <inheritdoc/>
    public IServerAccountClient Account { get; }

    /// <inheritdoc/>
    public IServerUsersClient Users { get; }

    /// <inheritdoc/>
    public IServerTeamsClient Teams { get; }

    /// <inheritdoc/>
    public IServerDatabasesClient Databases { get; }

    public ServerAppwriteClient(IServerAccountClient accountClient, IServerUsersClient usersClient, IServerTeamsClient teamsClient, IServerDatabasesClient databasesClient)
    {
        Account = accountClient;
        Users = usersClient;
        Teams = teamsClient;
        Databases = databasesClient;
    }
}
