﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Converters;
public class DocumentConverter : JsonConverter<Document>
{
    public override Document? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? id = null;
        string? collectionId = null;
        string? databaseId = null;
        DateTime? createdAt = null;
        DateTime? updatedAt = null;
        List<Permission>? permissions = null;
        var data = new Dictionary<string, object?>();

        var dateTimeConverter = new MultiFormatDateTimeConverter();
        var permissionListConverter = new PermissionListConverter();

        if (reader.TokenType is not JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token");
        }

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndObject)
            {
                break;
            }

            var propertyName = reader.GetString()!;

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
                    data[propertyName] = value;
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

        if (permissions is null)
        {
            throw new JsonException("Unable to find a value for Permissions");
        }

        return new Document(id, collectionId, databaseId, createdAt, updatedAt, permissions, data);
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

    public override void Write(Utf8JsonWriter writer, Document value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        // Write known properties
        writer.WriteString("$id", value.Id);
        writer.WriteString("$collectionId", value.CollectionId);
        writer.WriteString("$databaseId", value.DatabaseId);

        // Use MultiFormatDateTimeConverter for DateTime properties
        var dateTimeConverter = new NullableDateTimeConverter();

        writer.WritePropertyName("$createdAt");
        dateTimeConverter.Write(writer, value.CreatedAt, options);

        writer.WritePropertyName("$updatedAt");
        dateTimeConverter.Write(writer, value.UpdatedAt, options);

        writer.WritePropertyName("$permissions");
        if (value.Permissions is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            JsonSerializer.Serialize(writer, value.Permissions, options);
        }

        // Write dynamic properties from the Data dictionary
        foreach (var kvp in value.Data)
        {
            writer.WritePropertyName(kvp.Key);
            WriteValue(writer, kvp.Value, options);
        }

        writer.WriteEndObject();
    }

    private void WriteValue(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
    {
        // Handle null values
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        // Determine the type of the value and write accordingly
        switch (value)
        {
            case string s:
                writer.WriteStringValue(s);
                break;
            case int i:
                writer.WriteNumberValue(i);
                break;
            case long l:
                writer.WriteNumberValue(l);
                break;
            case float f:
                writer.WriteNumberValue(f);
                break;
            case double d:
                writer.WriteNumberValue(d);
                break;
            case decimal dec:
                writer.WriteNumberValue(dec);
                break;
            case bool b:
                writer.WriteBooleanValue(b);
                break;
            case DateTime dt:
                var dateTimeConverter = new MultiFormatDateTimeConverter();
                dateTimeConverter.Write(writer, dt, options);
                break;
            case IReadOnlyList<object?> list:
                writer.WriteStartArray();
                foreach (var item in list)
                {
                    WriteValue(writer, item, options);
                }
                writer.WriteEndArray();
                break;
            case Dictionary<string, object?> dict:
                writer.WriteStartObject();
                foreach (var kvp in dict)
                {
                    writer.WritePropertyName(kvp.Key);
                    WriteValue(writer, kvp.Value, options);
                }
                writer.WriteEndObject();
                break;
            default:
                // Fallback to default serialization
                JsonSerializer.Serialize(writer, value, value.GetType(), options);
                break;
        }
    }
}
