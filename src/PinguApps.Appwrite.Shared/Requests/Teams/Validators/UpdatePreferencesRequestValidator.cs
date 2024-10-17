using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class UpdatePreferencesRequestValidator : AbstractValidator<UpdatePreferencesRequest>
{
    public UpdatePreferencesRequestValidator()
    {
        Include(new TeamIdBaseRequestValidator<UpdatePreferencesRequest, UpdatePreferencesRequestValidator>());

        RuleFor(x => x.Preferences)
            .NotNull()
            .WithMessage("Preferences are required.");
    }
}
