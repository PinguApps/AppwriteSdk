using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class CreateUserWithScryptModifiedPasswordRequest : CreateUserWithPasswordBaseRequest<CreateUserWithScryptModifiedPasswordRequest, CreateUserWithScryptModifiedPasswordRequestValidator>
{
    /// <summary>
    /// Optional salt used to hash password
    /// </summary>
    [JsonPropertyName("passwordSalt")]
    public string PasswordSalt { get; set; } = string.Empty;

    /// <summary>
    /// Salt separator used to hash password
    /// </summary>
    [JsonPropertyName("passwordSaltSeparator")]
    public string PasswordSaltSeparator { get; set; } = string.Empty;

    /// <summary>
    /// Signer key used to hash password
    /// </summary>
    [JsonPropertyName("passwordSignerKey")]
    public string PasswordSignerKey { get; set; } = string.Empty;
}
