using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class GetIndexRequestTests : DatabaseCollectionIdIndexKeyBaseRequestTests<GetIndexRequest, GetIndexRequestValidator>
{
    protected override GetIndexRequest CreateValidDatabaseCollectionIdIndexKeyRequest => new();
}
