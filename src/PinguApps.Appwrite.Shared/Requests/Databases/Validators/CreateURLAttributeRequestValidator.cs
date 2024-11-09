using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateURLAttributeRequestValidator : AbstractValidator<CreateURLAttributeRequest>
{
    public CreateURLAttributeRequestValidator()
    {
        Include(new CreateStringAttributeBaseRequestValidator<CreateURLAttributeRequest, CreateURLAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _))
            .WithMessage("Default should be formatted as a URL");
    }
}
