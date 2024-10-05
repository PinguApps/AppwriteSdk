using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for deleting a user's session
/// </summary>
public class DeleteUserSessionRequest : UserIdBaseRequest<DeleteUserSessionRequest, DeleteUserSessionRequestValidator>
{
    /// <summary>
    /// Session Id
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = string.Empty;
}
