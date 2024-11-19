using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Converters;
public class UpperCaseEnumConverter : JsonConverter<object>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum;
    }

    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return Enum.Parse(typeToConvert, value, true);
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString().ToUpper());
    }
}
