using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="DeleteAuthenticatorRequest"/>
/// </summary>
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
