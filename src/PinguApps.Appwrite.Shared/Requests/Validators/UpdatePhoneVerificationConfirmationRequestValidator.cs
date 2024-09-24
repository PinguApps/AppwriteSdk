using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class UpdatePhoneVerificationConfirmationRequestValidator : AbstractValidator<UpdatePhoneVerificationConfirmationRequest>
{
    public UpdatePhoneVerificationConfirmationRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("The user ID is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("The user ID must be between 1 and 36 characters long and can only contain a-z, A-Z, 0-9, period, hyphen, and underscore.");

        RuleFor(x => x.Secret)
            .NotEmpty().WithMessage("The secret is required.");
    }
}
