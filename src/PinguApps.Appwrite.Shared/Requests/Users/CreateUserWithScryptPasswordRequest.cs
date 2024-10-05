using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for creating a user with scrypt password
/// </summary>
public class CreateUserWithScryptPasswordRequest : CreateUserWithPasswordBaseRequest<CreateUserWithScryptPasswordRequest, CreateUserWithScryptPasswordRequestValidator>
{
    /// <summary>
    /// Optional salt used to hash password
    /// </summary>
    [JsonPropertyName("passwordSalt")]
    public string PasswordSalt { get; set; } = string.Empty;

    /// <summary>
    /// Optional CPU cost used to hash password
    /// </summary>
    [JsonPropertyName("passwordCpu")]
    public int PasswordCpu { get; set; }

    /// <summary>
    /// Optional memory cost used to hash password
    /// </summary>
    [JsonPropertyName("passwordMemory")]
    public int PasswordMemory { get; set; }

    /// <summary>
    /// Optional parallelization cost used to hash password
    /// </summary>
    [JsonPropertyName("passwordParallel")]
    public int PasswordParallel { get; set; }

    /// <summary>
    /// Optional hash length used to hash password
    /// </summary>
    [JsonPropertyName("passwordLength")]
    public int PasswordLength { get; set; }

}
