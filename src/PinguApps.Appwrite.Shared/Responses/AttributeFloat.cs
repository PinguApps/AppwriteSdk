﻿using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite AttributeFloat object
/// </summary>
/// <param name="Key">Attribute Key</param>
/// <param name="Type">Attribute type</param>
/// <param name="Status">Attribute status</param>
/// <param name="Error">Error message. Displays error generated on failure of creating or deleting an attribute</param>
/// <param name="Required">Is attribute required?</param>
/// <param name="Array">Is attribute an array?</param>
/// <param name="CreatedAt">Attribute creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Attribute update date in ISO 8601 format</param>
/// <param name="Min">Minimum value to enforce for new documents</param>
/// <param name="Max">Maximum value to enforce for new documents</param>
/// <param name="Default">Default value for attribute when not provided. Cannot be set when attribute is required</param>
public record AttributeFloat(
    string Key,
    string Type,
    DatabaseElementStatus Status,
    string? Error,
    bool Required,
    bool Array,
    DateTime CreatedAt,
    DateTime UpdatedAt,

    [property: JsonPropertyName("min")] float? Min,
    [property: JsonPropertyName("max")] float? Max,
    [property: JsonPropertyName("default")] float? Default
) : Attribute(Key, Type, Status, Error, Required, Array, CreatedAt, UpdatedAt)
{
    /// <inheritdoc/>
    public override void Accept(IAttributeVisitor visitor)
    {
        visitor.Visit(this);
    }

    /// <inheritdoc/>
    public override T Accept<T>(IAttributeVisitor<T> visitor)
    {
        return visitor.Visit(this);
    }
}
