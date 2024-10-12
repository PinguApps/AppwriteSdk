using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

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
    [JsonPropertyName("_type")]
    public string Type { get; set; } = "totp";
}
