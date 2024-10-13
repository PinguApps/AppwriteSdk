using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserWithMd5PasswordRequestValidator : AbstractValidator<CreateUserWithMd5PasswordRequest>
{
    public CreateUserWithMd5PasswordRequestValidator()
    {
        Include(new CreateUserWithPasswordBaseRequestValidator<CreateUserWithMd5PasswordRequest, CreateUserWithMd5PasswordRequestValidator>());
    }
}
