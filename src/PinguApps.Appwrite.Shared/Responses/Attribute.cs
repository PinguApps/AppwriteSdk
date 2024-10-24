using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

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
    [property: JsonPropertyName("status"), JsonConverter(typeof(CamelCaseEnumConverter))] DatabaseElementStatus Status,
    [property: JsonPropertyName("error")] string? Error,
    [property: JsonPropertyName("required")] bool Required,
    [property: JsonPropertyName("array")] bool Array,
    [property: JsonPropertyName("$createdAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime UpdatedAt
)
{
    /// <summary>
    /// Useful for iterating a mixed list of Attributes using the <see href="https://en.wikipedia.org/wiki/Visitor_pattern">Visitor pattern</see>
    /// </summary>
    /// <param name="visitor">Your own implementation of <see cref="IAttributeVisitor"/></param>
    public abstract void Accept(IAttributeVisitor visitor);

    /// <summary>
    /// Useful for iterating a mixed list of Attributes using the <see href="https://en.wikipedia.org/wiki/Visitor_pattern">Visitor pattern</see>
    /// </summary>
    /// <typeparam name="T">The return type</typeparam>
    /// <param name="visitor">Your own implementation of <see cref="IAttributeVisitor{T}"/></param>
    /// <returns>T</returns>
    public abstract T Accept<T>(IAttributeVisitor<T> visitor);
}
