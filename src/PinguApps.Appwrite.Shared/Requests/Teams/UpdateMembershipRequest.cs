using System.Collections.Generic;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The request to update the roles of a team member
/// </summary>
public class UpdateMembershipRequest : TeamMembershipIdBaseRequest<UpdateMembershipRequest, UpdateMembershipRequestValidator>
{
    /// <summary>
    /// Modify the roles of a team member. Only team members with the owner role have access to this endpoint. Learn more about <see href="https://appwrite.io/docs/permissions">roles and permissions</see>.
    /// </summary>
    public List<string> Roles { get; set; } = [];
}
