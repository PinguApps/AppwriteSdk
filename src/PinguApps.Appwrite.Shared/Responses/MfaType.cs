using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Mfa Type object
/// </summary>
/// <param name="Secret">Secret token used for TOTP factor</param>
/// <param name="Uri">URI for authenticator apps</param>
public record MfaType(
    [property: JsonPropertyName("secret")] string Secret,
    [property: JsonPropertyName("uri")] string Uri
);
