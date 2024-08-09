using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class VerifyAuthenticatorRequestValidator : AbstractValidator<VerifyAuthenticatorRequest>
{
    public VerifyAuthenticatorRequestValidator()
    {
        RuleFor(x => x.Otp).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
    }
}
