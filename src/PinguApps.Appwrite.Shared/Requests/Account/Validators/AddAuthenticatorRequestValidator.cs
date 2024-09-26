using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="AddAuthenticatorRequest"/>
/// </summary>
public class AddAuthenticatorRequestValidator : AbstractValidator<AddAuthenticatorRequest>
{
    public AddAuthenticatorRequestValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required.");
    }
}
