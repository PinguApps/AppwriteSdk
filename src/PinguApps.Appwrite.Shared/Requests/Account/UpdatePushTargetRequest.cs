using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;
public class UpdatePushTargetRequest : BaseRequest<UpdatePushTargetRequest, UpdatePushTargetRequestValidator>
{
    /// <summary>
    /// Target ID.
    /// </summary>
    [JsonPropertyName("targetId")]
    [SdkExclude]
    public string TargetId { get; set; } = string.Empty;

    /// <summary>
    /// The target identifier (token, email, phone etc.)
    /// </summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = string.Empty;
}
