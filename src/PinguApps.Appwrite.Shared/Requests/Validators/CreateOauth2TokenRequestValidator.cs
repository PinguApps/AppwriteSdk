using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;

/// <summary>
/// Validator for <see cref="CreateOauth2TokenRequest"/>
/// </summary>
public class CreateOauth2TokenRequestValidator : AbstractValidator<CreateOauth2TokenRequest>
{
    public CreateOauth2TokenRequestValidator()
    {
        RuleFor(x => x.Provider)
            .NotEmpty().WithMessage("Provider is required.")
            .Must(provider => provider == provider.ToLower()).WithMessage("Provider must be in lowercase.");

        RuleFor(x => x.SuccessUri)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => x.SuccessUri is not null)
            .WithMessage("Invalid SuccessUri format.");

        RuleFor(x => x.FailureUri)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => x.FailureUri is not null)
            .WithMessage("Invalid FailureUri format.");

        RuleFor(x => x.Scopes)
            .Must(scopes => scopes == null || scopes.Count <= 100).WithMessage("A maximum of 100 scopes are allowed.")
            .ForEach(scope => scope.MaximumLength(4096).WithMessage("Each scope can be at most 4096 characters long."));
    }
}
