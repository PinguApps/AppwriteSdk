using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for creating an account
/// </summary>
public class CreateAccountRequest : BaseRequest<CreateAccountRequest, CreateAccountRequestValidator>
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
    /// New user password. Must be between 8 and 256 chars
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// User name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}


