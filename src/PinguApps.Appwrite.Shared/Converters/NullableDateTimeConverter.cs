using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Converters;
internal class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString();
            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }

            if (DateTime.TryParse(stringValue, out var dateTime))
            {
                return dateTime;
            }

            throw new JsonException($"Unable to parse '{stringValue}' to DateTime.");
        }

        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        throw new JsonException("Unexpected token type.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString("o"));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
