using FluentValidation;
using PinguApps.Appwrite.Shared.Reqests.Teams;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class DeleteTeamMembershipRequestValidator : AbstractValidator<DeleteTeamMembershipRequest>
{
    public DeleteTeamMembershipRequestValidator()
    {
        Include(new TeamMembershipIdBaseRequestValidator<DeleteTeamMembershipRequest, DeleteTeamMembershipRequestValidator>());
    }
}
