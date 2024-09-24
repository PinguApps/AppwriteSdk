using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Requests;
public class UpdatePhoneVerificationConfirmationRequest : BaseRequest<UpdatePhoneVerificationConfirmationRequest, UpdatePhoneVerificationConfirmationRequestValidator>
{
    /// <summary>
    /// User ID. Choose a custom ID or generate a random ID with <see cref="Utils.IdUtils.GenerateUniqueId(int)"/>. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Valid verification token.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; } = string.Empty;
}
