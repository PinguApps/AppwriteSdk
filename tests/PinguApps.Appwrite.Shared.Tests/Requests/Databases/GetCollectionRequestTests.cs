using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class GetCollectionRequestTests : DatabaseCollectionIdBaseRequestTests<GetCollectionRequest, GetCollectionRequestValidator>
{
    protected override GetCollectionRequest CreateValidDatabaseCollectionIdRequest => new();
}
