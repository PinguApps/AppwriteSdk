using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class CreateUserJwtRequest : UserIdBaseRequest<CreateUserJwtRequest, CreateUserJwtRequestValidator>
{
    /// <summary>
    /// Session ID. Use the string <c>recent</c> to use the most recent session. Defaults to the most recent session
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    /// <summary>
    /// Time in seconds before JWT expires. Default duration is 900 seconds, and maximum is 3600 seconds
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }
}
