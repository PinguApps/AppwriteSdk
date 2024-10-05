using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="Create2faChallengeConfirmationRequest"/>
/// </summary>
public class Create2faChallengeConfirmationRequestValidator : AbstractValidator<Create2faChallengeConfirmationRequest>
{
    public Create2faChallengeConfirmationRequestValidator()
    {
        RuleFor(x => x.ChallengeId)
            .NotEmpty().WithMessage("ChallengeId is required.");

        RuleFor(x => x.Otp)
            .NotEmpty().WithMessage("Otp is required.");
    }
}
