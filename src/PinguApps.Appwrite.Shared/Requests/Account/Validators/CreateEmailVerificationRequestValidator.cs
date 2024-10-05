using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="CreateEmailVerificationRequest"/>
/// </summary>
public class CreateEmailVerificationRequestValidator : AbstractValidator<CreateEmailVerificationRequest>
{
    public CreateEmailVerificationRequestValidator()
    {
        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Url is required.")
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL format.");
    }
}
