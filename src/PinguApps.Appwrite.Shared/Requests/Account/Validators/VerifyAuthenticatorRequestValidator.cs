using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="VerifyAuthenticatorRequest"/>
/// </summary>
public class VerifyAuthenticatorRequestValidator : AbstractValidator<VerifyAuthenticatorRequest>
{
    public VerifyAuthenticatorRequestValidator()
    {
        RuleFor(x => x.Otp)
            .NotEmpty().WithMessage("Otp is required.");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required.");
    }
}
