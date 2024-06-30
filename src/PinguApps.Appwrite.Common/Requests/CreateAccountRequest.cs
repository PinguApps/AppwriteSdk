using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests;
public class CreateAccountRequest
{
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = IdUtils.GenerateUniqueId();

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
