using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateURLAttributeRequestValidator : AbstractValidator<UpdateURLAttributeRequest>
{
    public UpdateURLAttributeRequestValidator()
    {
        Include(new UpdateStringAttributeBaseRequestValidator<UpdateURLAttributeRequest, UpdateURLAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _))
            .WithMessage("Default should be formatted as a URL")
            .When(x => x.Default is not null);
    }
}
