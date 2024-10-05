using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for creating an email verification confirmation
/// </summary>
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
