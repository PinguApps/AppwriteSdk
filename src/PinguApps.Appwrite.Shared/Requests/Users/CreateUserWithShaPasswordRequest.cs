using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for creating a user with sha password
/// </summary>
public class CreateUserWithShaPasswordRequest : CreateUserWithPasswordBaseRequest<CreateUserWithShaPasswordRequest, CreateUserWithShaPasswordRequestValidator>
{
    /// <summary>
    /// Optional SHA version used to hash password. Allowed values are: <c>sha1</c>, <c>sha224</c>, <c>sha256</c>, <c>sha384</c>, <c>sha512/224</c>, <c>sha512/256</c>, <c>sha512</c>, <c>sha3-224</c>, <c>sha3-256</c>, <c>sha3-384</c>, <c>sha3-512</c>
    /// </summary>
    [JsonPropertyName("passwordVersion")]
    public string? PasswordVersion { get; set; }
}
