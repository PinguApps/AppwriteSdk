using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for creating user's JWT
/// </summary>
public class CreateUserJwtRequest : UserIdBaseRequest<CreateUserJwtRequest, CreateUserJwtRequestValidator>
{
    /// <summary>
    /// Session ID. Use the string <c>recent</c> to use the most recent session. Defaults to the most recent session
    /// </summary>
    [JsonPropertyName("sessionId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SessionId { get; set; }

    /// <summary>
    /// Time in seconds before JWT expires. Default duration is 900 seconds, and maximum is 3600 seconds
    /// </summary>
    [JsonPropertyName("duration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Duration { get; set; }
}
