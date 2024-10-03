using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class DeleteUserSessionRequest : UserIdBaseRequest<DeleteUserSessionRequest, DeleteUserSessionRequestValidator>
{
    /// <summary>
    /// Session Id
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = string.Empty;
}
