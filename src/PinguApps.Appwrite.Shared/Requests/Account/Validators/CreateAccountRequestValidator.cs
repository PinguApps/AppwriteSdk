using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="CreateAccountRequest"/>
/// </summary>
public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAccountRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("UserId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(8, 256).WithMessage("Password must be between 8 and 256 characters.");

        RuleFor(x => x.Name)
            .MaximumLength(128).WithMessage("Name can be at most 128 characters long.");
    }
}
