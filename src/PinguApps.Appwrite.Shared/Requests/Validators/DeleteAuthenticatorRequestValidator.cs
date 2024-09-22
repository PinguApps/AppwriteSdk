using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class DeleteAuthenticatorRequestValidator : AbstractValidator<DeleteAuthenticatorRequest>
{
    public DeleteAuthenticatorRequestValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required.");

        RuleFor(x => x.Otp)
            .NotEmpty().WithMessage("Otp is required.");
    }
}
