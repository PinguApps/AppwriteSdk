using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class GetTeamMembershipRequestTests : TeamMembershipIdBaseRequestTests<GetTeamMembershipRequest, GetTeamMembershipRequestValidator>
{
    protected override GetTeamMembershipRequest CreateValidTeamMembershipIdRequest => new();
}
