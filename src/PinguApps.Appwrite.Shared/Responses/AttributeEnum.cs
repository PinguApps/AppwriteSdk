using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite AttributeEnum object
/// </summary>
/// <param name="Key">Attribute Key</param>
/// <param name="Type">Attribute type</param>
/// <param name="Status">Attribute status</param>
/// <param name="Error">Error message. Displays error generated on failure of creating or deleting an attribute</param>
/// <param name="Required">Is attribute required?</param>
/// <param name="Array">Is attribute an array?</param>
/// <param name="CreatedAt">Attribute creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Attribute update date in ISO 8601 format</param>
/// <param name="Elements">Array of elements in enumerated type</param>
/// <param name="Format">String format</param>
/// <param name="Default">Default value for attribute when not provided. Cannot be set when attribute is required</param>
public record AttributeEnum(
    string Key,
    string Type,
    AttributeStatus Status,
    string? Error,
    bool Required,
    bool Array,
    DateTime CreatedAt,
    DateTime UpdatedAt,

    [property: JsonPropertyName("elements")] IReadOnlyList<string> Elements,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("default")] string? Default
) : Attribute(Key, Type, Status, Error, Required, Array, CreatedAt, UpdatedAt);
