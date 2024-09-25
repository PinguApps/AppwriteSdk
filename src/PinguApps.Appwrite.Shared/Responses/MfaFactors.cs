using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Mfa Factors object
/// </summary>
/// <param name="Totp">Can TOTP be used for MFA challenge for this account</param>
/// <param name="Phone">Can phone (SMS) be used for MFA challenge for this account</param>
/// <param name="Email">Can email be used for MFA challenge for this account</param>
/// <param name="RecoveryCode">Can recovery code be used for MFA challenge for this account</param>
public record MfaFactors(
    [property: JsonPropertyName("totp")] bool Totp,
    [property: JsonPropertyName("phone")] bool Phone,
    [property: JsonPropertyName("email")] bool Email,
    [property: JsonPropertyName("recoveryCode")] bool RecoveryCode
);
