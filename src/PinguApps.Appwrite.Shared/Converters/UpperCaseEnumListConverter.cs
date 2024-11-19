using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Converters;
public class UpperCaseEnumListConverter<T> : JsonConverter<List<T>> where T : Enum
{
    public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.StartArray)
        {
            throw new JsonException("Expected start of array");
        }

        var list = new List<T>();

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
            {
                return list;
            }

            var value = reader.GetString();
            list.Add((T)Enum.Parse(typeof(T), value, true));
        }

        throw new JsonException("Expected end of array");
    }

    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var item in value)
        {
            writer.WriteStringValue(item.ToString().ToUpper());
        }

        writer.WriteEndArray();
    }
}
