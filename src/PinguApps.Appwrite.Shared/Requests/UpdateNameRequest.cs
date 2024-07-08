using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for updating a users name
/// </summary>
public class UpdateNameRequest
{
    /// <summary>
    /// User name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
