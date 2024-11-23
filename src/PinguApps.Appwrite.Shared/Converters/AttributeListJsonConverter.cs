using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;

namespace PinguApps.Appwrite.Shared.Converters;
public class AttributeListJsonConverter : JsonConverter<IReadOnlyList<Attribute>>
{
    private readonly AttributeJsonConverter _attributeConverter = new();

    public override IReadOnlyList<Attribute>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var attributes = new List<Attribute>();

        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("Expected start of array");
        }

        reader.Read();

        while (reader.TokenType != JsonTokenType.EndArray)
        {
            var attribute = _attributeConverter.Read(ref reader, typeof(Attribute), options);

            if (attribute is not null)
            {
                attributes.Add(attribute);
            }

            reader.Read();
        }

        return attributes;
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyList<Attribute> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var attribute in value)
        {
            _attributeConverter.Write(writer, attribute, options);
        }

        writer.WriteEndArray();
    }
}
