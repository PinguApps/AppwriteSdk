using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class CreateTeamRequestValidator : AbstractValidator<CreateTeamRequest>
{
    public CreateTeamRequestValidator()
    {
        RuleFor(x => x.TeamId)
            .NotEmpty()
            .WithMessage("TeamId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("TeamId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Team name is required.")
            .MaximumLength(128)
            .WithMessage("Team name must be less than or equal to 128 characters.");

        RuleFor(x => x.Roles)
            .Must(x => x == null || x.Count <= 100)
            .WithMessage("A maximum of 100 roles are allowed.")
            .ForEach(x => x.NotEmpty()
                .WithMessage("Each role must have a non empty string value")
                .MaximumLength(32)
                .WithMessage("Each role must be less than or equal to 32 characters."));
    }
}
