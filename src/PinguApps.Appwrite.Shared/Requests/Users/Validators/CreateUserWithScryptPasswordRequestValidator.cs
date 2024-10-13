using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserWithScryptPasswordRequestValidator : AbstractValidator<CreateUserWithScryptPasswordRequest>
{
    public CreateUserWithScryptPasswordRequestValidator()
    {
        Include(new CreateUserWithPasswordBaseRequestValidator<CreateUserWithScryptPasswordRequest, CreateUserWithScryptPasswordRequestValidator>());

        RuleFor(x => x.PasswordSalt)
            .NotEmpty()
            .WithMessage("PasswordSalt is required.");
    }
}
