using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Converters;
public class DocumentListGenericConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
        {
            return false;
        }

        var documentType = typeToConvert.GetGenericArguments()[0];
        if (!documentType.IsGenericType || documentType.GetGenericTypeDefinition() != typeof(Document<>))
        {
            return false;
        }

        return typeToConvert.GetGenericTypeDefinition() == typeof(IReadOnlyList<>);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var documentType = typeToConvert.GetGenericArguments()[0];
        if (!documentType.IsGenericType || documentType.GetGenericTypeDefinition() != typeof(Document<>))
        {
            return null;
        }

        var dataType = documentType.GetGenericArguments()[0];
        var converterType = typeof(DocumentListGenericConverterInner<>).MakeGenericType(dataType);
        return (JsonConverter?)Activator.CreateInstance(converterType);
    }

    private class DocumentListGenericConverterInner<TData> : JsonConverter<IReadOnlyList<Document<TData>>>
        where TData : class, new()
    {
        private readonly DocumentGenericConverter<TData> _documentConverter = new();

        public override IReadOnlyList<Document<TData>>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var documents = new List<Document<TData>>();

            if (reader.TokenType is not JsonTokenType.StartArray)
            {
                throw new JsonException("Expected start of array");
            }

            reader.Read();

            while (reader.TokenType is not JsonTokenType.EndArray)
            {
                var document = _documentConverter.Read(ref reader, typeof(Document<TData>), options);

                if (document is not null)
                {
                    documents.Add(document);
                }

                reader.Read();
            }

            return documents;
        }

        public override void Write(Utf8JsonWriter writer, IReadOnlyList<Document<TData>> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var document in value)
            {
                _documentConverter.Write(writer, document, options);
            }

            writer.WriteEndArray();
        }
    }
}
