using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for updating a session
/// </summary>
public class UpdateSessionRequest : BaseRequest<UpdateSessionRequest, UpdateSessionRequestValidator>
{
    /// <summary>
    /// Session ID. Use the string 'current' to get the current device session
    /// </summary>
    [JsonPropertyName("_sessionId")]
    public string SessionId { get; set; } = "current";
}
