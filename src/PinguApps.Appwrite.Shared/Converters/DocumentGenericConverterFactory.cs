using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Converters;
public class DocumentGenericConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        // Ensure the type is a generic type of Document<>
        return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Document<>);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        // Extract the TData type from Doocument<TData>
        Type dataType = typeToConvert.GetGenericArguments()[0];

        // Create a specific generic converter for Doocument<TData>
        var converterType = typeof(DocumentGenericConverter<>).MakeGenericType(dataType);
        return (JsonConverter?)Activator.CreateInstance(converterType);
    }
}
