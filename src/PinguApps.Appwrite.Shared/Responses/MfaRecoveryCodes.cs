using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Mfa Recovery Codes object
/// </summary>
/// <param name="RecoveryCodes">Recovery codes</param>
public record MfaRecoveryCodes(
    [property: JsonPropertyName("recoveryCodes")] IReadOnlyList<string> RecoveryCodes
);
