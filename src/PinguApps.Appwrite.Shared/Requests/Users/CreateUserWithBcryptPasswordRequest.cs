using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for creating a user with bcrypt password
/// </summary>
public class CreateUserWithBcryptPasswordRequest : CreateUserWithPasswordBaseRequest<CreateUserWithBcryptPasswordRequest, CreateUserWithBcryptPasswordRequestValidator>
{
}
