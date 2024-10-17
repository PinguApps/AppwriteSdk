using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The request for updating a teams name
/// </summary>
public class UpdateNameRequest : TeamIdBaseRequest<UpdateNameRequest, UpdateNameRequestValidator>
{
    /// <summary>
    /// New team name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
