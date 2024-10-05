using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class GetUserRequestTests : UserIdBaseRequestTests<GetUserRequest, GetUserRequestValidator>
{
    protected override GetUserRequest CreateValidRequest => new();
}
