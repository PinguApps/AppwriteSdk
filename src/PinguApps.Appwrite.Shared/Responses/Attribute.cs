using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite base Attribute object
/// </summary>
/// <param name="Key">Attribute Key</param>
/// <param name="Type">Attribute type</param>
/// <param name="Status">Attribute status</param>
/// <param name="Error">Error message. Displays error generated on failure of creating or deleting an attribute</param>
/// <param name="Required">Is attribute required?</param>
/// <param name="Array">Is attribute an array?</param>
/// <param name="CreatedAt">Attribute creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Attribute update date in ISO 8601 format</param>
public abstract record Attribute(
    [property: JsonPropertyName("key")] string Key,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("status"), JsonConverter(typeof(JsonStringEnumConverter))] AttributeStatus Status,
    [property: JsonPropertyName("error")] string? Error,
    [property: JsonPropertyName("required")] bool Required,
    [property: JsonPropertyName("array")] bool Array,
    [property: JsonPropertyName("$createdAt")] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt")] DateTime UpdatedAt
);
