using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for deleting an authenticator
/// </summary>
public class DeleteAuthenticatorRequest : BaseRequest<DeleteAuthenticatorRequest, DeleteAuthenticatorRequestValidator>
{
    /// <summary>
    /// Type of authenticator
    /// </summary>
    [JsonIgnore]
    public string Type { get; set; } = "totp";

    /// <summary>
    /// Valid verification token
    /// </summary>
    [JsonPropertyName("otp")]
    public string Otp { get; set; } = string.Empty;
}
