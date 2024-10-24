using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Document object
/// </summary>
/// <param name="Id">Document ID</param>
/// <param name="CollectionId">Collection ID</param>
/// <param name="DatabaseId">Database ID</param>
/// <param name="CreatedAt">Document creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Document update date in ISO 8601 format</param>
/// <param name="Permissions">Document permissions. <see href="https://appwrite.io/docs/permissions">Learn more about permissions</see></param>
/// <param name="Data">Document data</param>
[JsonConverter(typeof(DocumentConverter))]
public record Document(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$collectionId")] string CollectionId,
    [property: JsonPropertyName("$databaseId")] string DatabaseId,
    [property: JsonPropertyName("$createdAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime UpdatedAt,
    [property: JsonPropertyName("$permissions")] IReadOnlyList<string> Permissions,
    [property: JsonExtensionData] Dictionary<string, object?> Data
)
{
    /// <summary>
    /// Extract document data by key
    /// </summary>
    /// <param name="key">The attribute key</param>
    /// <returns>The attribute</returns>
    public object? this[string key] => Data.ContainsKey(key) ? Data[key] : null;

    /// <summary>
    /// Get the value of a given attribute
    /// </summary>
    /// <typeparam name="T">The type of the attribute value</typeparam>
    /// <param name="key">The attribute key</param>
    /// <returns>The attribute value</returns>
    public T GetValue<T>(string key)
    {
        if (Data.TryGetValue(key, out var value))
        {
            if (value is T tValue)
            {
                return tValue;
            }

            throw new InvalidCastException($"Value for '{key}' is not of type {typeof(T)}.");
        }
        throw new KeyNotFoundException($"Key '{key}' not found.");
    }

    // TODO: Write tests for this method
    /// <summary>
    /// Try get the value of a given attribute
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    /// <param name="key">The attribute key</param>
    /// <param name="value">The value of this attribute</param>
    /// <returns>Whether the attribute value could be successfully retrieved or not</returns>
    public bool TryGetValue<T>(string key, [NotNullWhen(true)] out T? value)
    {
        value = default;

        if (Data.TryGetValue(key, out var storedValue))
        {
            if (storedValue is T tValue)
            {
                value = tValue;
                return true;
            }
        }

        return false;
    }
}
