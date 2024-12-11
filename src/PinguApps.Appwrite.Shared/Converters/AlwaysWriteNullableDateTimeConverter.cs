using System;
using System.Text.Json;

namespace PinguApps.Appwrite.Shared.Converters;
public class AlwaysWriteNullableDateTimeConverter : NullableDateTimeConverter
{
    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
        }
        else
        {
            base.Write(writer, value, options);
        }
    }
}
