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

        var attributeType = ResolveAttributeType(jsonObject);

        return DeserializeAttribute(jsonObject, attributeType, options);
    }

    private static Type ResolveAttributeType(JsonElement jsonObject)
    {
        var type = GetRequiredTypeProperty(jsonObject);
        var format = GetOptionalFormatProperty(jsonObject);

        return DetermineAttributeType(type, format, jsonObject);
    }

    private static string GetRequiredTypeProperty(JsonElement jsonObject)
    {
        if (!jsonObject.TryGetProperty("type", out var typeProperty))
        {
            throw new JsonException("Missing `Type` property");
        }

        return typeProperty.GetString()!;
    }

    private static string? GetOptionalFormatProperty(JsonElement jsonObject)
    {
        jsonObject.TryGetProperty("format", out var formatProperty);

        return formatProperty.ValueKind is JsonValueKind.String ? formatProperty.GetString() : null;
    }

    private static Type DetermineAttributeType(string type, string? format, JsonElement jsonObject)
    {
        return type switch
        {
            "boolean" => typeof(AttributeBoolean),
            "integer" => typeof(AttributeInteger),
            "double" => typeof(AttributeFloat),
            "datetime" => typeof(AttributeDatetime),
            "string" => ResolveStringAttributeType(format, jsonObject),
            _ => throw new JsonException($"Unknown type: {type}")
        };
    }

    private static Type ResolveStringAttributeType(string? format, JsonElement jsonObject)
    {
        return format switch
        {
            "email" => typeof(AttributeEmail),
            "url" => typeof(AttributeUrl),
            "ip" => typeof(AttributeIp),
            "enum" => typeof(AttributeEnum),
            null or "" => ResolveBasicStringAttributeType(jsonObject),
            _ => throw new JsonException($"Unknown format: {format}")
        };
    }

    private static Type ResolveBasicStringAttributeType(JsonElement jsonObject)
    {
        return jsonObject.TryGetProperty("relatedCollection", out _) ? typeof(AttributeRelationship) : typeof(AttributeString);
    }

    private static Attribute? DeserializeAttribute(JsonElement jsonObject, Type attributeType, JsonSerializerOptions options)
    {
        return (Attribute?)JsonSerializer.Deserialize(jsonObject.GetRawText(), attributeType, options);
    }

    public override void Write(Utf8JsonWriter writer, Attribute value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
