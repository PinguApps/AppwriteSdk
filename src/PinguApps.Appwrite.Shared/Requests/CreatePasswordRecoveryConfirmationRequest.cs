using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for creating a password recovery confirmation
/// </summary>
public class CreatePasswordRecoveryConfirmationRequest : BaseRequest<CreatePasswordRecoveryConfirmationRequest, CreatePasswordRecoveryConfirmationRequestValidator>
{
    /// <summary>
    /// User ID
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Valid reset token
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; } = string.Empty;

    /// <summary>
    /// New user password. Must be between 8 and 256 chars
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
