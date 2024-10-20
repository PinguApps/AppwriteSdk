using System;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Database object
/// </summary>
/// <param name="Id">Database ID</param>
/// <param name="Name">Database Name</param>
/// <param name="CreatedAt">Database creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Database update date in ISO 8601 format</param>
/// <param name="Enabled">If database is enabled. Can be 'enabled' or 'disabled'. When disabled, the database is inaccessible to users, but remains accessible to Server SDKs using API keys</param>
public record Database(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("$createdAt")] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt")] DateTime UpdatedAt,
    [property: JsonPropertyName("enabled")] bool Enabled
);
