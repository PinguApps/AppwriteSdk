using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class DeleteDatabaseRequestTests : DatabaseIdBaseRequestTests<DeleteDatabaseRequest, DeleteDatabaseRequestValidator>
{
    protected override DeleteDatabaseRequest CreateValidRequest => new();
}
