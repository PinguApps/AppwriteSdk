using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class DeleteUserSessionsRequestTests : UserIdBaseRequestTests<DeleteUserSessionsRequest, DeleteUserSessionsRequestValidator>
{
    protected override DeleteUserSessionsRequest CreateValidRequest => new();
}
