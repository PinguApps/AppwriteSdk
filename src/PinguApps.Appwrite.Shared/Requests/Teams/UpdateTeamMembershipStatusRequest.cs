using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The request for accepting a users invitation to join a team
/// </summary>
public class UpdateTeamMembershipStatusRequest : TeamMembershipIdBaseRequest<UpdateTeamMembershipStatusRequest, UpdateTeamMembershipStatusRequestValidator>
{
    /// <summary>
    /// User ID
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Secret Key
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; } = string.Empty;
}
