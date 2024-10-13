using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserWithBcryptPasswordRequestValidator : AbstractValidator<CreateUserWithBcryptPasswordRequest>
{
    public CreateUserWithBcryptPasswordRequestValidator()
    {
        Include(new CreateUserWithPasswordBaseRequestValidator<CreateUserWithBcryptPasswordRequest, CreateUserWithBcryptPasswordRequestValidator>());
    }
}
