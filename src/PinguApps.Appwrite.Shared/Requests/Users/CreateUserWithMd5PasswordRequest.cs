using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for creating a user with md5 password
/// </summary>
public class CreateUserWithMd5PasswordRequest : CreateUserWithPasswordBaseRequest<CreateUserWithMd5PasswordRequest, CreateUserWithMd5PasswordRequestValidator>
{
}
