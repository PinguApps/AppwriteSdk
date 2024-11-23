﻿namespace PinguApps.Appwrite.Server.Clients;

/// <inheritdoc/>
public class AppwriteClient : IAppwriteClient
{
    public IAccountClient Account { get; }
    public IUsersClient Users { get; }
    public ITeamsClient Teams { get; }
    public IDatabasesClient DatabasesClient { get; }

    public AppwriteClient(IAccountClient accountClient, IUsersClient usersClient, ITeamsClient teamsClient, IDatabasesClient databasesClient)
    {
        Account = accountClient;
        Users = usersClient;
        Teams = teamsClient;
        DatabasesClient = databasesClient;
    }
}
