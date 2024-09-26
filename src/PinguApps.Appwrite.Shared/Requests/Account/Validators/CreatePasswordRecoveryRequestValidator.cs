using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="CreatePasswordRecoveryRequest"/>
/// </summary>
public class CreatePasswordRecoveryRequestValidator : AbstractValidator<CreatePasswordRecoveryRequest>
{
    public CreatePasswordRecoveryRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Url is required.")
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Invalid URL format.");
    }
}
