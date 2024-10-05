using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserWithArgon2PasswordRequestValidator : AbstractValidator<CreateUserWithArgon2PasswordRequest>
{
    public CreateUserWithArgon2PasswordRequestValidator()
    {
        Include(new CreateUserWithPasswordBaseRequestValidator<CreateUserWithArgon2PasswordRequest, CreateUserWithArgon2PasswordRequestValidator>());
    }
}
