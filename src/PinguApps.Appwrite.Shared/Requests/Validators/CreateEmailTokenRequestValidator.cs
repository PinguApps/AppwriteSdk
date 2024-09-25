using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;

/// <summary>
/// Validator for <see cref="CreateEmailTokenRequest"/>
/// </summary>
public class CreateEmailTokenRequestValidator : AbstractValidator<CreateEmailTokenRequest>
{
    public CreateEmailTokenRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("UserId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
    }
}
