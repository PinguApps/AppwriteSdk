using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for creating a user with argon2 password
/// </summary>
public class CreateUserWithArgon2PasswordRequest : CreateUserWithPasswordBaseRequest<CreateUserWithArgon2PasswordRequest, CreateUserWithArgon2PasswordRequestValidator>
{
}
