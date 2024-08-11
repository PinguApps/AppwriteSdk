using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreateOauth2SessionRequestValidator : AbstractValidator<CreateOauth2SessionRequest>
{
    public CreateOauth2SessionRequestValidator()
    {
        RuleFor(x => x.Provider).NotEmpty().Must(x => string.Equals(x, x.ToLower(), StringComparison.Ordinal)).WithMessage("Provider must be all lower case.");
        RuleFor(x => x.SuccessUri).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => x is not null);
        RuleFor(x => x.FailureUri).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => x is not null);
        When(x => x.Scopes is not null, () =>
        {
            RuleFor(x => x.Scopes).Must(x => x!.Count <= 100);
            RuleFor(x => x.Scopes).Must(x => x!.Count > 0);
        });
        RuleForEach(x => x.Scopes).MaximumLength(4096);
    }
}
