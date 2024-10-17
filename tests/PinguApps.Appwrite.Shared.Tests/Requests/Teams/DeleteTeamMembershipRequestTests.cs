using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class DeleteTeamMembershipRequestTests : TeamMembershipIdBaseRequestTests<DeleteTeamMembershipRequest, DeleteTeamMembershipRequestValidator>
{
    protected override DeleteTeamMembershipRequest CreateValidTeamMembershipIdRequest => new();
}
