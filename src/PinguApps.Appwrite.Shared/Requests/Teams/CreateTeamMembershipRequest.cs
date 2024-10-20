using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The request to create a team membership
/// </summary>
public class CreateTeamMembershipRequest : TeamIdBaseRequest<CreateTeamMembershipRequest, CreateTeamMembershipRequestValidator>
{
    /// <summary>
    /// Array of strings. Use this param to set the user roles in the team. A role can be any string. Learn more about <see href="https://appwrite.io/docs/permissions">roles and permissions</see>. Maximum of 100 roles are allowed, each 32 characters long.
    /// </summary>
    [JsonPropertyName("roles")]
    public List<string> Roles { get; set; } = [];

    /// <summary>
    /// Email of the new team member
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// ID of the user to be added to a team
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>
    /// Phone number. Format this number with a leading '+' and a country code, e.g., +16175551212
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// URL to redirect the user back to your app from the invitation email. This parameter is not required when an API key is supplied. Only URLs from hostnames in your project platform list are allowed. This requirement helps to prevent an <see href="https://cheatsheetseries.owasp.org/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.html">open redirect</see> attack against your project API
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Name of the new team member. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
