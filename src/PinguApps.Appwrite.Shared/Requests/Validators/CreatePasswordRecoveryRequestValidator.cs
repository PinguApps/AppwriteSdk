using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreatePasswordRecoveryRequestValidator : AbstractValidator<CreatePasswordRecoveryRequest>
{
    public CreatePasswordRecoveryRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Url).NotEmpty().Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _));
    }
}
