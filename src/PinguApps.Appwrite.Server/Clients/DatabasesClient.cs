using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Clients;

/// <inheritdoc/>
public class DatabasesClient
{
    private readonly IDatabasesApi _databasesApi;

    public DatabasesClient(IServiceProvider services)
    {
        _databasesApi = services.GetRequiredService<IDatabasesApi>();
    }

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public async Task<AppwriteResult<DatabasesList>> ListDatabases(ListDatabasesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public async Task<AppwriteResult<Database>> CreateDatabase(CreateDatabaseRequest request) => throw new NotImplementedException();
}
