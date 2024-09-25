using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Converters;

/// <summary>
/// This is only required temporarily as a workaround for #8447 on Appwrite.
/// <para><see href="https://github.com/appwrite/appwrite/issues/8447"/></para>
/// </summary>
public class MultiFormatDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string[] _formats = [
        "yyyy-MM-ddTHH:mm:ss.fffK",
        "yyyy-MM-dd HH:mm:ss.fff"
    ];

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var dateString = reader.GetString();

            foreach (var format in _formats)
            {
                if (DateTime.TryParseExact(dateString, format, null, System.Globalization.DateTimeStyles.None, out var dateTime))
                {
                    return dateTime;
                }
            }
            throw new JsonException($"Unable to parse date: {dateString}");
        }
        throw new JsonException("Invalid token type");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_formats[0])); // Use the first format for serialization
    }
}
