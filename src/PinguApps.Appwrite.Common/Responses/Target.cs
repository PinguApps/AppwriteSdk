using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Responses;
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
