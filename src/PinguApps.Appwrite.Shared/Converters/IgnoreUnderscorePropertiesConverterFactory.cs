using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Converters;

public class IgnoreUnderscorePropertiesConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        // Exclude primitive types, enums, strings, and object
        if (typeToConvert.IsPrimitive ||
            typeToConvert.IsEnum ||
            typeToConvert == typeof(string) ||
            typeToConvert == typeof(decimal) ||
            typeToConvert == typeof(DateTime) ||
            typeToConvert == typeof(DateTimeOffset) ||
            typeToConvert == typeof(TimeSpan) ||
            typeToConvert == typeof(Guid) ||
            typeToConvert == typeof(object))
        {
            return false;
        }

        // Apply to all other non-abstract classes
        return typeToConvert.IsClass && !typeToConvert.IsAbstract;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeof(IgnoreUnderscorePropertiesConverter<>).MakeGenericType(typeToConvert);

        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }

    private class IgnoreUnderscorePropertiesConverter<T> : JsonConverter<T> where T : class
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Delegate deserialization to the default serializer
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartObject();

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(prop => prop.CanRead && prop.GetMethod != null);

            foreach (var prop in properties)
            {
                var jsonPropertyName = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ??
                    (options.PropertyNamingPolicy?.ConvertName(prop.Name) ?? prop.Name);

                // Skip properties with JSON names starting with '_'
                if (jsonPropertyName.StartsWith("_"))
                    continue;

                var propValue = prop.GetValue(value);

                if (propValue is null && options.DefaultIgnoreCondition == JsonIgnoreCondition.WhenWritingNull)
                    continue;

                writer.WritePropertyName(jsonPropertyName);

                JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
            }

            writer.WriteEndObject();
        }
    }
}
