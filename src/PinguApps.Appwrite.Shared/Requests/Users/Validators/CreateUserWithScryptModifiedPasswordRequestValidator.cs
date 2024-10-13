using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserWithScryptModifiedPasswordRequestValidator : AbstractValidator<CreateUserWithScryptModifiedPasswordRequest>
{
    public CreateUserWithScryptModifiedPasswordRequestValidator()
    {
        Include(new CreateUserWithPasswordBaseRequestValidator<CreateUserWithScryptModifiedPasswordRequest, CreateUserWithScryptModifiedPasswordRequestValidator>());

        RuleFor(x => x.PasswordSalt)
            .NotEmpty()
            .WithMessage("PasswordSalt is required.");

        RuleFor(x => x.PasswordSaltSeparator)
            .NotEmpty()
            .WithMessage("PasswordSaltSeparator is required.");

        RuleFor(x => x.PasswordSignerKey)
            .NotEmpty()
            .WithMessage("PasswordSignerKey is required.");
    }
}
