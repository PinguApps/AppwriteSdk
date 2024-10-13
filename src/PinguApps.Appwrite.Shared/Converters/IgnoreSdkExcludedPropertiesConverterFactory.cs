using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;

namespace PinguApps.Appwrite.Shared.Converters;

public class IgnoreSdkExcludedPropertiesConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
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

        if (typeof(IEnumerable).IsAssignableFrom(typeToConvert) && typeToConvert != typeof(string))
        {
            return false;
        }

        return typeToConvert.IsClass && !typeToConvert.IsAbstract;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeof(IgnoreSdkExcludedPropertiesConverter<>).MakeGenericType(typeToConvert);

        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }

    private class IgnoreSdkExcludedPropertiesConverter<T> : JsonConverter<T> where T : class
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);

            var json = jsonDoc.RootElement.GetRawText();

            var newOptions = new JsonSerializerOptions(options);

            var converterToRemove = newOptions.Converters.FirstOrDefault(x => x.GetType() == typeof(IgnoreSdkExcludedPropertiesConverterFactory));

            if (converterToRemove is not null)
            {
                newOptions.Converters.Remove(converterToRemove);
            }

            return JsonSerializer.Deserialize<T>(json, newOptions);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (value is null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStartObject();

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                      .Where(x => x.CanRead && x.GetMethod is not null);

            foreach (var prop in properties)
            {
                if (prop.GetCustomAttribute<SdkExcludeAttribute>() is not null)
                    continue;

                var jsonPropertyNameAttr = prop.GetCustomAttribute<JsonPropertyNameAttribute>();

                var jsonPropertyName = jsonPropertyNameAttr is not null
                    ? jsonPropertyNameAttr.Name
                    : (options.PropertyNamingPolicy?.ConvertName(prop.Name) ?? prop.Name);

                var propValue = prop.GetValue(value);

                if (propValue is null && options.DefaultIgnoreCondition == JsonIgnoreCondition.WhenWritingNull)
                    continue;

                writer.WritePropertyName(jsonPropertyName);

                var jsonConverterAttr = prop.GetCustomAttribute<JsonConverterAttribute>();
                if (jsonConverterAttr is not null && jsonConverterAttr.ConverterType is not null)
                {
                    // Instantiate the specified converter
                    var converterInstance = (JsonConverter?)Activator.CreateInstance(jsonConverterAttr.ConverterType)!;

                    // Create a new JsonSerializerOptions instance without the custom converter factory to prevent recursion
                    var newOptions = new JsonSerializerOptions(options);

                    // Remove the custom converter factory to prevent it from being invoked again
                    var converterToRemove = newOptions.Converters
                        .FirstOrDefault(c => c.GetType() == typeof(IgnoreSdkExcludedPropertiesConverterFactory));

                    if (converterToRemove != null)
                        newOptions.Converters.Remove(converterToRemove);

                    newOptions.Converters.Add(converterInstance);

                    // Serialize the property value using the specified converter and the new options
                    JsonSerializer.Serialize(writer, propValue, prop.PropertyType, newOptions);

                    // Move to the next property after handling with the custom converter
                    continue;
                }

                // If no custom converter is specified, serialize normally
                JsonSerializer.Serialize(writer, propValue, prop.PropertyType, options);
            }

            writer.WriteEndObject();
        }
    }
}
