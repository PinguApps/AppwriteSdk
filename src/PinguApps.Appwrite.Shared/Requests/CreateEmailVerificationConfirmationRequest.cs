using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;
public class CreateEmailVerificationConfirmationRequest : BaseRequest<CreateEmailVerificationConfirmationRequest, CreateEmailVerificationConfirmationRequestValidator>
{
    /// <summary>
    /// User ID.
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Valid verification token.
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; } = string.Empty;
}
