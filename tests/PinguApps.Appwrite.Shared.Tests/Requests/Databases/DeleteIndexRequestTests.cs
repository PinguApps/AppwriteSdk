using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class DeleteIndexRequestTests : DatabaseCollectionIdIndexKeyBaseRequestTests<DeleteIndexRequest, DeleteIndexRequestValidator>
{
    protected override DeleteIndexRequest CreateValidDatabaseCollectionIdIndexKeyRequest => new();
}
