using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for creating an email token
/// </summary>
public class CreateEmailTokenRequest : BaseRequest<CreateEmailTokenRequest, CreateEmailTokenRequestValidator>
{
    /// <summary>
    /// User ID. Choose a custom ID or generate a random ID with <see cref="IdUtils.GenerateUniqueId(int)"/>. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// User email
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Toggle for security phrase. If enabled, email will be send with a randomly generated phrase and the phrase will also be included in the response. Confirming phrases match increases the security of your authentication flow.
    /// </summary>
    [JsonPropertyName("phrase")]
    public bool Phrase { get; set; } = false;
}
