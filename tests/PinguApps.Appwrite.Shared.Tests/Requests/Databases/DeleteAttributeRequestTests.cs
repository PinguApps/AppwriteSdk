using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class DeleteAttributeRequestTests : DatabaseCollectionIdAttributeKeyBaseRequestTests<DeleteAttributeRequest, DeleteAttributeRequestValidator>
{
    protected override DeleteAttributeRequest CreateValidDatabaseCollectionIdAttributeKeyRequest => new();
}
