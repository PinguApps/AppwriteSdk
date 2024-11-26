using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Converters;

public class DocumentGenericConverter<TData> : JsonConverter<Doocument<TData>>
        where TData : class, new()
{
    public override Doocument<TData> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? id = null;
        string? collectionId = null;
        string? databaseId = null;
        DateTime? createdAt = null;
        DateTime? updatedAt = null;
        List<Permission>? permissions = null;
        TData data = new();

        var dataProperties = new Dictionary<string, object?>();

        var dateTimeConverter = new MultiFormatDateTimeConverter();
        var permissionListConverter = new PermissionListConverter();

        if (reader.TokenType is not JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token");
        }

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            string propertyName = reader.GetString()!;

            reader.Read();

            switch (propertyName)
            {
                case "$id":
                    id = reader.GetString();
                    break;
                case "$collectionId":
                    collectionId = reader.GetString();
                    break;
                case "$databaseId":
                    databaseId = reader.GetString();
                    break;
                case "$createdAt":
                    createdAt = dateTimeConverter.Read(ref reader, typeof(DateTime), options);
                    break;
                case "$updatedAt":
                    updatedAt = dateTimeConverter.Read(ref reader, typeof(DateTime), options);
                    break;
                case "$permissions":
                    permissions = permissionListConverter.Read(ref reader, typeof(List<Permission>), options);
                    break;
                default:
                    var value = ReadValue(ref reader, options);
                    dataProperties[propertyName] = value;
                    break;
            }
        }

        if (id is null)
        {
            throw new JsonException("Unable to find a value for Id");
        }

        if (collectionId is null)
        {
            throw new JsonException("Unable to find a value for CollectionId");
        }

        if (databaseId is null)
        {
            throw new JsonException("Unable to find a value for DatabaseId");
        }

        if (createdAt is null)
        {
            throw new JsonException("Unable to find a value for CreatedAt");
        }

        if (updatedAt is null)
        {
            throw new JsonException("Unable to find a value for UpdatedAt");
        }

        if (permissions is null)
        {
            throw new JsonException("Unable to find a value for Permissions");
        }

        // Deserialize the remaining properties into TData
        var dataJson = JsonSerializer.Serialize(dataProperties, options);
        data = JsonSerializer.Deserialize<TData>(dataJson, options) ?? new TData();

        return new Doocument<TData>(id, collectionId, databaseId, createdAt.Value, updatedAt.Value, permissions, data);
    }

    internal object? ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var str = reader.GetString();

                if ((DateTime.TryParse(str, out var dateTime)))
                {
                    return dateTime;
                }
                return str;

            case JsonTokenType.Number:
                if (reader.TryGetInt64(out var longValue))
                {
                    return longValue;
                }
                return reader.GetSingle();

            case JsonTokenType.True:
            case JsonTokenType.False:
                return reader.GetBoolean();

            case JsonTokenType.Null:
                return null;

            case JsonTokenType.StartArray:
                return ReadArray(ref reader, options);

            case JsonTokenType.StartObject:
                return ReadObject(ref reader, options);

            default:
                throw new JsonException($"Unsupported token type: {reader.TokenType}");
        }
    }

    private IReadOnlyCollection<object?> ReadArray(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var list = new List<object?>();

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
            {
                break;
            }

            var item = ReadValue(ref reader, options);
            list.Add(item);
        }

        return list;
    }

    private Dictionary<string, object?> ReadObject(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var dict = new Dictionary<string, object?>();

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndObject)
            {
                break;
            }

            var propertyName = reader.GetString()!;

            reader.Read();

            var value = ReadValue(ref reader, options);

            dict[propertyName] = value;
        }

        return dict;
    }

    public override void Write(Utf8JsonWriter writer, Doocument<TData> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("$id", value.Id);
        writer.WriteString("$collectionId", value.CollectionId);
        writer.WriteString("$databaseId", value.DatabaseId);

        // Use MultiFormatDateTimeConverter for DateTime properties
        var dateTimeConverter = new MultiFormatDateTimeConverter();

        writer.WritePropertyName("$createdAt");
        dateTimeConverter.Write(writer, value.CreatedAt, options);

        writer.WritePropertyName("$updatedAt");
        dateTimeConverter.Write(writer, value.UpdatedAt, options);

        writer.WritePropertyName("$permissions");
        JsonSerializer.Serialize(writer, value.Permissions, options);

        // Serialize the data object into individual properties.
        var dataProperties = JsonSerializer.SerializeToElement(value.Data, options);
        foreach (var property in dataProperties.EnumerateObject())
        {
            writer.WritePropertyName(property.Name);
            WriteValue(writer, property, options);
        }

        writer.WriteEndObject();
    }

    private void WriteValue(Utf8JsonWriter writer, JsonProperty property, JsonSerializerOptions options)
    {
        // Handle null values
        if (property.Value.ValueKind is JsonValueKind.Null)
        {
            writer.WriteNullValue();
            return;
        }

        // TODO - Complete the implementation using DocumentConverter as a guide
    }
}
