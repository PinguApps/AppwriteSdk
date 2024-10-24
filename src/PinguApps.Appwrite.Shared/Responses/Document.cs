using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Responses;

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
    public object? this[string key] => Data.ContainsKey(key) ? Data[key] : null;

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
}
