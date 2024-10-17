using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class GetTeamMembershipRequestValidator : AbstractValidator<GetTeamMembershipRequest>
{
    public GetTeamMembershipRequestValidator()
    {
        Include(new TeamMembershipIdBaseRequestValidator<GetTeamMembershipRequest, GetTeamMembershipRequestValidator>());
    }
}
