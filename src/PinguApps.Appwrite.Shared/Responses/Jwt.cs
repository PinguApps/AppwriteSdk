using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// A JWT response object
/// </summary>
/// <param name="token">JWT encoded string</param>
public record Jwt(
    [property: JsonPropertyName("jwt")] string Token
);
