using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite AttributeRelationship object
/// </summary>
/// <param name="Key">Attribute Key</param>
/// <param name="Type">Attribute type</param>
/// <param name="Status">Attribute status</param>
/// <param name="Error">Error message. Displays error generated on failure of creating or deleting an attribute</param>
/// <param name="Required">Is attribute required?</param>
/// <param name="Array">Is attribute an array?</param>
/// <param name="CreatedAt">Attribute creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Attribute update date in ISO 8601 format</param>
/// <param name="RelatedCollection">The ID of the related collection</param>
/// <param name="RelationType">The type of the relationship</param>
/// <param name="TwoWay">Is the relationship two-way?</param>
/// <param name="TwoWayKey">The key of the two-way relationship</param>
/// <param name="OnDelete">How deleting the parent document will propagate to child documents</param>
/// <param name="Side">Whether this is the parent or child side of the relationship</param>
public record AttributeRelationship(
    string Key,
    string Type,
    AttributeStatus Status,
    string? Error,
    bool Required,
    bool Array,
    DateTime CreatedAt,
    DateTime UpdatedAt,

    [property: JsonPropertyName("relatedCollection")] string RelatedCollection,
    [property: JsonPropertyName("relationType"), JsonConverter(typeof(CamelCaseEnumConverter))] RelationType RelationType,
    [property: JsonPropertyName("twoWay")] bool TwoWay,
    [property: JsonPropertyName("twoWayKey")] string TwoWayKey,
    [property: JsonPropertyName("onDelete"), JsonConverter(typeof(CamelCaseEnumConverter))] OnDelete OnDelete,
    [property: JsonPropertyName("side"), JsonConverter(typeof(CamelCaseEnumConverter))] RelationshipSide Side
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
