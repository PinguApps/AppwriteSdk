using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for Creating a user
/// </summary>
public class CreateUserRequest : BaseRequest<CreateUserRequest, CreateUserRequestValidator>
{
    /// <summary>
    /// User ID. Choose a custom ID or generate a random ID with <see cref="Utils.IdUtils.GenerateUniqueId(int)"/>. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// User Email
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Phone number. Format this number with a leading '+' and a country code, e.g., +16175551212
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// User password hashed
    /// </summary>
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    /// <summary>
    /// User name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
