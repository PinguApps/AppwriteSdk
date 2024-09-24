using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;
public class GetSessionRequest : BaseRequest<GetSessionRequest, GetSessionRequestValidator>
{
    /// <summary>
    /// Session ID. Use the string 'current' to get the current device session
    /// </summary>
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = "current";
}
