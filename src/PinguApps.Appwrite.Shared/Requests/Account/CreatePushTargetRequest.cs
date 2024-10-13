using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for creating a push target
/// </summary>
public class CreatePushTargetRequest : BaseRequest<CreatePushTargetRequest, CreatePushTargetRequestValidator>
{
    /// <summary>
    /// Target ID. Choose a custom ID or generate a random ID with ID.unique(). Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("targetId")]
    public string TargetId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// The target identifier (token, email, phone etc.)
    /// </summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = string.Empty;

    /// <summary>
    /// Provider ID. Message will be sent to this target from the specified provider ID. If no provider ID is set the first setup provider will be used.
    /// </summary>
    [JsonPropertyName("providerId")]
    public string? ProviderId { get; set; }
}
