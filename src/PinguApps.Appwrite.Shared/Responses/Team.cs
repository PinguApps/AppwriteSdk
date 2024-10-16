using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Team object
/// </summary>
/// <param name="Id">Team ID</param>
/// <param name="CreatedAt">Team creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Team update date in ISO 8601 format</param>
/// <param name="Name">Team name</param>
/// <param name="Total">Total number of team members</param>
/// <param name="Prefs">Team preferences as a key-value object</param>
public record Team(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$createdAt")] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt")] DateTime UpdatedAt,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("prefs")] IReadOnlyDictionary<string, string> Prefs
);
