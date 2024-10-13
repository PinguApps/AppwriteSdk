using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;
public class DeletePushTargetRequest : BaseRequest<DeletePushTargetRequest, DeletePushTargetRequestValidator>
{
    /// <summary>
    /// Target ID.
    /// </summary>
    [JsonPropertyName("targetId")]
    [SdkExclude]
    public string TargetId { get; set; } = string.Empty;
}
