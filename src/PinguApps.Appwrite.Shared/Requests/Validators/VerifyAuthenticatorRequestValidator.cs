using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
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
