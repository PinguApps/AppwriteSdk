using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for Verifying an authenticator
/// </summary>
public class VerifyAuthenticatorRequest : BaseRequest<VerifyAuthenticatorRequest, VerifyAuthenticatorRequestValidator>
{
    /// <summary>
    /// Valid verification token
    /// </summary>
    [JsonPropertyName("otp")]
    public string Otp { get; set; } = string.Empty;

    /// <summary>
    /// Type of authenticator
    /// </summary>
    [JsonIgnore]
    public string Type { get; set; } = "totp";
}
