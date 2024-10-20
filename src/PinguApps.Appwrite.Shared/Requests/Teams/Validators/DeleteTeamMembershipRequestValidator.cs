using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class DeleteTeamMembershipRequestValidator : AbstractValidator<DeleteTeamMembershipRequest>
{
    public DeleteTeamMembershipRequestValidator()
    {
        Include(new TeamMembershipIdBaseRequestValidator<DeleteTeamMembershipRequest, DeleteTeamMembershipRequestValidator>());
    }
}
