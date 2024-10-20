using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The request for creating a team
/// </summary>
public class CreateTeamRequest : BaseRequest<CreateTeamRequest, CreateTeamRequestValidator>
{
    /// <summary>
    /// Team ID. Choose a custom ID or generate a random ID with ID.unique(). Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("teamId")]
    public string TeamId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// Team name. Max length: 128 chars.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Array of strings. Use this param to set the roles in the team for the user who created it. The default role is <c>owner</c>. A role can be any string. Learn more about <see href="https://appwrite.io/docs/permissions">roles and permissions</see>. Maximum of 100 roles are allowed, each 32 characters long.
    /// </summary>
    [JsonPropertyName("roles")]
    public List<string>? Roles { get; set; }
}
