using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdateUserPreferencesRequestValidator : AbstractValidator<UpdateUserPreferencesRequest>
{
    public UpdateUserPreferencesRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdateUserPreferencesRequest, UpdateUserPreferencesRequestValidator>());

        RuleFor(x => x.Preferences)
            .NotNull()
            .WithMessage("Preferences cannot be null.");
    }
}
