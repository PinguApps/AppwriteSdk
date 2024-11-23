using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class ListDatabasesRequestTests : QuerySearchBaseRequestTests<ListDatabasesRequest, ListDatabasesRequestValidator>
{
    protected override ListDatabasesRequest CreateValidRequest => new();
}
