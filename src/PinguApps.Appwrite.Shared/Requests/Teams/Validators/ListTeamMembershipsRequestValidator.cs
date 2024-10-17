using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class ListTeamMembershipsRequestValidator : AbstractValidator<ListTeamMembershipsRequest>
{
    public ListTeamMembershipsRequestValidator()
    {
        Include(new QuerySearchBaseRequestValidator<ListTeamMembershipsRequest, ListTeamMembershipsRequestValidator>());

        RuleFor(x => x.TeamId)
            .NotEmpty()
            .WithMessage("TeamId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("TeamId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");
    }
}
