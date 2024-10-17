using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Reqests.Teams;

/// <summary>
/// The reuqest for removing a user from a team
/// </summary>
public class DeleteTeamMembershipRequest : TeamMembershipIdBaseRequest<DeleteTeamMembershipRequest, DeleteTeamMembershipRequestValidator>
{
}
