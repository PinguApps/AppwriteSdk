using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Converters;

public class DocumentGenericConverter<TData> : JsonConverter<Document<TData>>
        where TData : class, new()
{
    private class DocumentFields
    {
        public string? Id { get; set; }
        public string? CollectionId { get; set; }
        public string? DatabaseId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<Permission>? Permissions { get; set; }
        public Dictionary<string, object?> DataProperties { get; set; } = new();
    }

    public override Document<TData> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ValidateStartObject(ref reader);

        var documentFields = ReadDocumentFields(ref reader, options);

        ValidateRequiredFields(documentFields);

        var data = DeserializeCustomData(documentFields.DataProperties, options);

        return new Document<TData>(documentFields.Id!, documentFields.CollectionId!, documentFields.DatabaseId!, documentFields.CreatedAt,
            documentFields.UpdatedAt, documentFields.Permissions!, data);
    }

    private static void ValidateStartObject(ref Utf8JsonReader reader)
    {
        if (reader.TokenType is not JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token");
        }
    }

    private DocumentFields ReadDocumentFields(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var dateTimeConverter = new MultiFormatDateTimeConverter();
        var permissionListConverter = new PermissionListConverter();
        var fields = new DocumentFields();

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndObject)
            {
                break;
            }

            var propertyName = reader.GetString()!;
            reader.Read();

            ProcessProperty(ref reader, propertyName, fields, dateTimeConverter, permissionListConverter, options);
        }

        return fields;
    }

    private static void ProcessProperty(ref Utf8JsonReader reader, string propertyName, DocumentFields fields,
        MultiFormatDateTimeConverter dateTimeConverter, PermissionListConverter permissionListConverter, JsonSerializerOptions options)
    {
        switch (propertyName)
        {
            case "$id":
                fields.Id = reader.GetString();
                break;
            case "$collectionId":
                fields.CollectionId = reader.GetString();
                break;
            case "$databaseId":
                fields.DatabaseId = reader.GetString();
                break;
            case "$createdAt":
                fields.CreatedAt = dateTimeConverter.Read(ref reader, typeof(DateTime), options);
                break;
            case "$updatedAt":
                fields.UpdatedAt = dateTimeConverter.Read(ref reader, typeof(DateTime), options);
                break;
            case "$permissions":
                fields.Permissions = permissionListConverter.Read(ref reader, typeof(List<Permission>), options);
                break;
            default:
                var value = ReadValue(ref reader, options);
                fields.DataProperties[propertyName] = value;
                break;
        }
    }

    internal static object? ReadValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
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

    private static IReadOnlyCollection<object?> ReadArray(ref Utf8JsonReader reader, JsonSerializerOptions options)
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

    private static Dictionary<string, object?> ReadObject(ref Utf8JsonReader reader, JsonSerializerOptions options)
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

    private static void ValidateRequiredFields(DocumentFields fields)
    {
        if (fields.Id is null)
            throw new JsonException("Unable to find a value for Id");

        if (fields.CollectionId is null)
            throw new JsonException("Unable to find a value for CollectionId");

        if (fields.DatabaseId is null)
            throw new JsonException("Unable to find a value for DatabaseId");

        if (fields.Permissions is null)
            throw new JsonException("Unable to find a value for Permissions");
    }

    private static TData DeserializeCustomData(Dictionary<string, object?> dataProperties, JsonSerializerOptions options)
    {
        var dataJson = JsonSerializer.Serialize(dataProperties, options);
        return JsonSerializer.Deserialize<TData>(dataJson, options) ?? new TData();
    }

    public override void Write(Utf8JsonWriter writer, Document<TData> value, JsonSerializerOptions options)
    {
        var permissionsListConverter = new PermissionListConverter();

        writer.WriteStartObject();

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
        permissionsListConverter.Write(writer, value.Permissions.ToList(), options);

        // Serialize the Data property
        if (value.Data is not null)
        {
            var dataProperties = JsonSerializer.SerializeToElement(value.Data, options);
            foreach (var property in dataProperties.EnumerateObject())
            {
                writer.WritePropertyName(property.Name);
                WriteValue(writer, property.Value, options);
            }
        }

        writer.WriteEndObject();
    }

    internal void WriteValue(Utf8JsonWriter writer, JsonElement element, JsonSerializerOptions options)
    {
        var dateTimeConverter = new MultiFormatDateTimeConverter();

        switch (element.ValueKind)
        {
            case JsonValueKind.String:
                var stringValue = element.GetString();
                if (DateTime.TryParse(stringValue, out var dateTimeValue))
                {
                    // Write DateTime using the MultiFormatDateTimeConverter
                    dateTimeConverter.Write(writer, dateTimeValue, options);
                }
                else
                {
                    writer.WriteStringValue(stringValue);
                }
                break;
            case JsonValueKind.Number:
                if (element.TryGetInt32(out var intValue))
                    writer.WriteNumberValue(intValue);
                else if (element.TryGetInt64(out var longValue))
                    writer.WriteNumberValue(longValue);
                else if (element.TryGetDouble(out var doubleValue))
                    writer.WriteNumberValue(doubleValue);
                break;
            case JsonValueKind.True:
            case JsonValueKind.False:
                writer.WriteBooleanValue(element.GetBoolean());
                break;
            case JsonValueKind.Null:
                writer.WriteNullValue();
                break;
            case JsonValueKind.Array:
                writer.WriteStartArray();
                foreach (var item in element.EnumerateArray())
                {
                    WriteValue(writer, item, options);
                }
                writer.WriteEndArray();
                break;
            case JsonValueKind.Object:
                writer.WriteStartObject();
                foreach (var property in element.EnumerateObject())
                {
                    writer.WritePropertyName(property.Name);
                    WriteValue(writer, property.Value, options);
                }
                writer.WriteEndObject();
                break;
            case JsonValueKind.Undefined:
                throw new JsonException("Cannot serialize undefined JsonElement");
        }
    }
}
