using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class GetAttributeRequestTests : DatabaseCollectionIdAttributeKeyBaseRequestTests<GetAttributeRequest, GetAttributeRequestValidator>
{
    protected override GetAttributeRequest CreateValidDatabaseCollectionIdAttributeKeyRequest => new();
}
