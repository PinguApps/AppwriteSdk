using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;

namespace PinguApps.Appwrite.Shared.Converters;
public class AttributeJsonConverter : JsonConverter<Attribute>
{
    public override Attribute? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDoc.RootElement;

        if (!jsonObject.TryGetProperty("type", out var typeProperty))
        {
            throw new JsonException("Missing `Type` property");
        }

        var type = typeProperty.GetString();
        jsonObject.TryGetProperty("format", out var formatProperty);
        var format = formatProperty.ValueKind == JsonValueKind.String ? formatProperty.GetString() : null;

        var derivedType = type switch
        {
            "boolean" => typeof(AttributeBoolean),
            "integer" => typeof(AttributeInteger),
            "double" => typeof(AttributeFloat),
            "datetime" => typeof(AttributeDatetime),
            "string" => format switch
            {
                "email" => typeof(AttributeEmail),
                "url" => typeof(AttributeUrl),
                "ip" => typeof(AttributeIp),
                "enum" => typeof(AttributeEnum),
                null or "" => jsonObject.TryGetProperty("relatedCollection", out _) ? typeof(AttributeRelationship) : typeof(AttributeString),
                _ => throw new JsonException($"Unknown format: {format}")
            },
            _ => throw new JsonException($"Unknown type: {type}")
        };

        return (Attribute?)JsonSerializer.Deserialize(jsonObject.GetRawText(), derivedType, options);
    }

    public override void Write(Utf8JsonWriter writer, Attribute value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
