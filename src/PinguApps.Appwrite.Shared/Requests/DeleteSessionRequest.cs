using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for deleting a session (logging out of current session)
/// </summary>
public class DeleteSessionRequest : BaseRequest<DeleteSessionRequest, DeleteSessionRequestValidator>
{
    /// <summary>
    /// Session ID. Use the string 'current' to delete the current device session.
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = "current";
}
