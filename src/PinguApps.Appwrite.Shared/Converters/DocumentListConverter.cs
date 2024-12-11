using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Converters;
public class DocumentListConverter : JsonConverter<IReadOnlyList<Document>>
{
    private readonly DocumentConverter _documentConverter = new();

    public override IReadOnlyList<Document>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var documents = new List<Document>();

        if (reader.TokenType is not JsonTokenType.StartArray)
        {
            throw new JsonException("Expected start of array");
        }

        reader.Read();

        while (reader.TokenType is not JsonTokenType.EndArray)
        {
            var document = _documentConverter.Read(ref reader, typeof(Document), options);

            if (document is not null)
            {
                documents.Add(document);
            }

            reader.Read();
        }

        return documents;
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyList<Document> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var document in value)
        {
            _documentConverter.Write(writer, document, options);
        }

        writer.WriteEndArray();
    }
}
