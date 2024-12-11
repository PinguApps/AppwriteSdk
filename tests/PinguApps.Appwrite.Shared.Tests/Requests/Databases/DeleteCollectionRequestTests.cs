using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class DeleteCollectionRequestTests : DatabaseCollectionIdBaseRequestTests<DeleteCollectionRequest, DeleteCollectionRequestValidator>
{
    protected override DeleteCollectionRequest CreateValidDatabaseCollectionIdRequest => new();
}
