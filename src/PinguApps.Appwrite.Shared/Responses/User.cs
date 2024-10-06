using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite User object
/// </summary>
/// <param name="Id">User ID</param>
/// <param name="CreatedAt">User creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">User update date in ISO 8601 format</param>
/// <param name="Name">User name</param>
/// <param name="Password">Hashed user password</param>
/// <param name="Hash">Password hashing algorithm</param>
/// <param name="HashOptions">Password hashing algorithm configuration. Can be one of:
///     <para>AlgoArgon2 model, AlgoScrypt model, AlgoScryptModified model, AlgoBcrypt model, AlgoPHPass model, AlgoSHA model, AlgoMD5 model</para></param>
/// <param name="Registration">User registration date in ISO 8601 format</param>
/// <param name="Status">User status. Pass `true` for enabled and `false` for disabled</param>
/// <param name="Labels">Labels for the user</param>
/// <param name="PasswordUpdate">Password update time in ISO 8601 format</param>
/// <param name="Email">User email address</param>
/// <param name="Phone">User phone number in E.164 format</param>
/// <param name="EmailVerification">Email verification status</param>
/// <param name="PhoneVerification">Phone verification status</param>
/// <param name="Mfa">Multi factor authentication status</param>
/// <param name="Prefs">User preferences as a key-value object</param>
/// <param name="Targets">A user-owned message receiver. A single user may have multiple e.g. emails, phones, and a browser. Each target is registered with a single provider. Can be one of: <see cref="Target"/></param>
/// <param name="AccessedAt">Most recent access date in ISO 8601 format. This attribute is only updated again after 24 hours</param>
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
    [property: JsonPropertyName("passwordUpdate"), JsonConverter(typeof(NullableDateTimeConverter))] DateTime? PasswordUpdate,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("phone")] string Phone,
    [property: JsonPropertyName("emailVerification")] bool EmailVerification,
    [property: JsonPropertyName("phoneVerification")] bool PhoneVerification,
    [property: JsonPropertyName("mfa")] bool Mfa,
    [property: JsonPropertyName("prefs")] IReadOnlyDictionary<string, string> Prefs,
    [property: JsonPropertyName("targets")] IReadOnlyList<Target> Targets,
    [property: JsonPropertyName("accessedAt"), JsonConverter(typeof(NullableDateTimeConverter))] DateTime? AccessedAt
);
