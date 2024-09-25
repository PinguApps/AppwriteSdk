using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Utils;

/// <summary>
/// Utilities for Appwrite Tokens
/// </summary>
public static class TokenUtils
{
    internal record SessionToken(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("secret")] string Secret
    );

    /// <summary>
    /// Gets the session token, given a user Id and secret
    /// </summary>
    /// <param name="userId">The user id</param>
    /// <param name="secret">The secret</param>
    /// <returns>The session token</returns>
    public static string GetSessionToken(string userId, string secret)
    {
        var session = new SessionToken(userId, secret);

        var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(session);

        return Convert.ToBase64String(jsonBytes);
    }
}
