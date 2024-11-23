using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class GetDatabaseRequestTests : DatabaseIdBaseRequestTests<GetDatabaseRequest, GetDatabaseRequestValidator>
{
    protected override GetDatabaseRequest CreateValidRequest => new();
}
