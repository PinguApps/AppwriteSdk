using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="UpdateMagicUrlSessionRequest"/>
/// </summary>
public class UpdateMagicUrlSessionRequestValidator : AbstractValidator<UpdateMagicUrlSessionRequest>
{
    public UpdateMagicUrlSessionRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("UserId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");

        RuleFor(x => x.Secret)
            .NotEmpty().WithMessage("Secret is required.");
    }
}
