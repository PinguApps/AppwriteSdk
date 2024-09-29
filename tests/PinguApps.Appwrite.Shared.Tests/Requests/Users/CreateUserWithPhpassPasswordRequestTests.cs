using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserWithPhpassPasswordRequestTests : CreateUserWithPasswordBaseRequestTests<CreateUserWithPhpassPasswordRequest, CreateUserWithPhpassPasswordRequestValidator>
{
    protected override CreateUserWithPhpassPasswordRequest CreateValidRequest => new();
}
