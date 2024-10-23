using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Converters;
public class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    private readonly MultiFormatDateTimeConverter _dateTimeConverter = new();

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString();
            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }

            return _dateTimeConverter.Read(ref reader, typeof(DateTime), options);
        }

        throw new JsonException("Unexpected token type.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            _dateTimeConverter.Write(writer, value.Value, options);
        }
    }
}
