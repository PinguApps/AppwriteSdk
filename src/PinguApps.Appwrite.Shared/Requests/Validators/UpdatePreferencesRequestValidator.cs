using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class UpdatePreferencesRequestValidator : AbstractValidator<UpdatePreferencesRequest>
{
    public UpdatePreferencesRequestValidator()
    {
        RuleFor(x => x.Preferences).NotNull();
    }
}
