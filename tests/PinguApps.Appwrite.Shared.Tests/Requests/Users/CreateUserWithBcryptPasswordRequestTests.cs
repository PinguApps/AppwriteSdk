using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserWithBcryptPasswordRequestTests : CreateUserWithPasswordBaseRequestTests<CreateUserWithBcryptPasswordRequest, CreateUserWithBcryptPasswordRequestValidator>
{
    protected override CreateUserWithBcryptPasswordRequest CreateValidRequest => new();
}
