using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserWithArgon2PasswordRequestTests : CreateUserWithPasswordBaseRequestTests<CreateUserWithArgon2PasswordRequest, CreateUserWithArgon2PasswordRequestValidator>
{
    protected override CreateUserWithArgon2PasswordRequest CreateValidRequest => new();
}
