using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;
public record User(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$createdAt")] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt")] DateTime UpdatedAt,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("password")] string? Password,
    [property: JsonPropertyName("hash")] string? Hash,
    [property: JsonPropertyName("hashOptions")] HashOptions? HashOptions,
    [property: JsonPropertyName("registration")] DateTime Registration,
    [property: JsonPropertyName("status")] bool Status,
    [property: JsonPropertyName("labels")] IReadOnlyList<string> Labels,
    [property: JsonPropertyName("passwordUpdate")] DateTime PasswordUpdate,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("phone")] string Phone,
    [property: JsonPropertyName("emailVerification")] bool EmailVerification,
    [property: JsonPropertyName("phoneVerification")] bool PhoneVerification,
    [property: JsonPropertyName("mfa")] bool Mfa,
    [property: JsonPropertyName("prefs")] IReadOnlyDictionary<string, string> Prefs,
    [property: JsonPropertyName("targets")] IReadOnlyList<Target> Targets,
    [property: JsonPropertyName("accessedAt")] DateTime AccessedAt
);
