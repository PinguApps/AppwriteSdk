using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Responses;
/// <summary>
/// A user-owned message receiver. A single user may have multiple e.g. emails, phones, and a browser. Each target is registered with a single provider.
/// </summary>
/// <param name="Id">Target ID</param>
/// <param name="CreatedAt">Target creation time in ISO 8601 format</param>
/// <param name="UpdatedAt">Target update date in ISO 8601 format</param>
/// <param name="Name">Target Name</param>
/// <param name="UserId">User ID</param>
/// <param name="ProviderId">Provider ID</param>
/// <param name="ProviderType">The target provider type. Can be one of the following: `email`, `sms` or `push`</param>
/// <param name="Identifier">The target identifier</param>
public record Target(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$createdAt")] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt")] DateTime UpdatedAt,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("providerId")] string? ProviderId,
    [property: JsonPropertyName("providerType"), JsonConverter(typeof(JsonStringEnumConverter))] TargetProviderType ProviderType,
    [property: JsonPropertyName("identifier")] string Identifier
);
