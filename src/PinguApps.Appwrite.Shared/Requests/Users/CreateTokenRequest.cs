using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for creating a token
/// </summary>
public class CreateTokenRequest : UserIdBaseRequest<CreateTokenRequest, CreateTokenRequestValidator>
{
    /// <summary>
    /// Token length in characters. The default length is 6 characters
    /// </summary>
    [JsonPropertyName("length")]
    public int? Length { get; set; }

    /// <summary>
    /// Token expiration period in seconds. The default expiration is 15 minutes
    /// </summary>
    [JsonPropertyName("expire")]
    public int? Expire { get; set; }
}
