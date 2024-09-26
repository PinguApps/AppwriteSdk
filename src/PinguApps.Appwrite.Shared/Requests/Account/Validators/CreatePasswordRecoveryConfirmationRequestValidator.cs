using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="CreatePasswordRecoveryConfirmationRequest"/>
/// </summary>
public class CreatePasswordRecoveryConfirmationRequestValidator : AbstractValidator<CreatePasswordRecoveryConfirmationRequest>
{
    public CreatePasswordRecoveryConfirmationRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("UserId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");

        RuleFor(x => x.Secret)
            .NotEmpty().WithMessage("Secret is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(8, 256).WithMessage("Password must be between 8 and 256 characters.");
    }
}
