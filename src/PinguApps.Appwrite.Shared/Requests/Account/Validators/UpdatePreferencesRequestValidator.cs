using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="UpdatePreferencesRequest"/>
/// </summary>
public class UpdatePreferencesRequestValidator : AbstractValidator<UpdatePreferencesRequest>
{
    public UpdatePreferencesRequestValidator()
    {
        RuleFor(x => x.Preferences)
            .NotNull().WithMessage("Preferences are required.");
    }
}
