using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Utils;
public static class TokenUtils
{
    internal record SessionToken(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("secret")] string Secret
    );

    public static string GetSessionToken(string userId, string secret)
    {
        var session = new SessionToken(userId, secret);

        var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(session);

        return Convert.ToBase64String(jsonBytes);
    }
}
