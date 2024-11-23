using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Mfa Challenge object
/// </summary>
/// <param name="Id">Token ID</param>
/// <param name="CreatedAt">Token creation date in ISO 8601 format</param>
/// <param name="UserId">User ID</param>
/// <param name="Expire">Token expiration date in ISO 8601 format</param>
public record MfaChallenge(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$createdAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime CreatedAt,
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("expire"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime Expire
);
