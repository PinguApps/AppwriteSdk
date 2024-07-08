using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for updating a users password
/// </summary>
public class UpdatePasswordRequest
{
    /// <summary>
    /// New user password. Must be at least 8 chars
    /// </summary>
    [JsonPropertyName("password")]
    public string NewPassword { get; set; } = string.Empty;

    /// <summary>
    /// Current user password. Must be at least 8 chars
    /// </summary>
    [JsonPropertyName("oldPassword")]
    public string? OldPassword { get; set; }
}
