using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;

/// <summary>
/// Validator for <see cref="CreateMagicUrlTokenRequest"/>
/// </summary>
public class CreateMagicUrlTokenRequestValidator : AbstractValidator<CreateMagicUrlTokenRequest>
{
    public CreateMagicUrlTokenRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("UserId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Url)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => x.Url is not null)
            .WithMessage("Invalid URL format.");

        RuleFor(x => x.Phrase)
            .NotNull().WithMessage("Phrase is required.");
    }
}
