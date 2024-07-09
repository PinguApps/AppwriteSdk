using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for updating a users phone
/// </summary>
public class UpdatePhoneRequest
{
    /// <summary>
    /// Phone number. Format this number with a leading '+' and a country code, e.g., +16175551212
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// New user password. Must be at least 8 chars
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
