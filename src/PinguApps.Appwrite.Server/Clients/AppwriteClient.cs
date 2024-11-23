namespace PinguApps.Appwrite.Server.Clients;

/// <inheritdoc/>
public class AppwriteClient : IAppwriteClient
{
    /// <inheritdoc/>
    public IAccountClient Account { get; }

    /// <inheritdoc/>
    public IUsersClient Users { get; }

    /// <inheritdoc/>
    public ITeamsClient Teams { get; }

    /// <inheritdoc/>
    public IDatabasesClient DatabasesClient { get; }

    public AppwriteClient(IAccountClient accountClient, IUsersClient usersClient, ITeamsClient teamsClient, IDatabasesClient databasesClient)
    {
        Account = accountClient;
        Users = usersClient;
        Teams = teamsClient;
        DatabasesClient = databasesClient;
    }
}
