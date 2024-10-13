using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserWithMd5PasswordRequestTests : CreateUserWithPasswordBaseRequestTests<CreateUserWithMd5PasswordRequest, CreateUserWithMd5PasswordRequestValidator>
{
    protected override CreateUserWithMd5PasswordRequest CreateValidRequest => new();
}
