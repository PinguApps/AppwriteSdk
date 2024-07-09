using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for updating a users email
/// </summary>
public class UpdateEmailRequest : BaseRequest<UpdateEmailRequest, UpdateEmailRequestValidator>
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
