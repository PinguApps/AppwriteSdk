using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class DeleteUserRequestTests : UserIdBaseRequestTests<DeleteUserRequest, DeleteUserRequestValidator>
{
    protected override DeleteUserRequest CreateValidRequest => new();
}
