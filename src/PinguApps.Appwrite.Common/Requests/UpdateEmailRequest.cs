using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for updating a users email
/// </summary>
public class UpdateEmailRequest
{
    /// <summary>
    /// User email
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User password. Must be at least 8 chars
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
