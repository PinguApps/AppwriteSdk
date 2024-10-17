using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The request for listing users that are members of a team
/// </summary>
public class ListTeamMembershipsRequest : QuerySearchBaseRequest<ListTeamMembershipsRequest, ListTeamMembershipsRequestValidator>
{
    /// <summary>
    /// Team ID. Choose a custom ID or generate a random ID with <see cref="Utils.IdUtils.GenerateUniqueId(int)"/>. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("teamId")]
    [SdkExclude]
    public string TeamId { get; set; } = string.Empty;
}
