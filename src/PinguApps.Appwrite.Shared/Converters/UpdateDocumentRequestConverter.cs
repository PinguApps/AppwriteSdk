using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Converters;
public class UpdateDocumentRequestConverter : JsonConverter<UpdateDocumentRequest>
{
    public override UpdateDocumentRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, UpdateDocumentRequest value, JsonSerializerOptions options)
    {
        var permissionsListConverter = new PermissionListConverter();

        writer.WriteStartObject();

        if (!options.IsInsideSdk())
        {
            writer.WriteString("$collectionId", value.CollectionId);
            writer.WriteString("$databaseId", value.DatabaseId);
        }

        if (value.Permissions is not null)
        {
            writer.WritePropertyName("permissions");
            permissionsListConverter.Write(writer, [.. value.Permissions], options);
        }

        if (value.Data.Count > 0)
        {
            writer.WritePropertyName("data");
            writer.WriteStartObject();
            foreach (var kvp in value.Data)
            {
                writer.WritePropertyName(kvp.Key);
                JsonSerializer.Serialize(writer, kvp.Value, options);
            }
            writer.WriteEndObject();
        }

        writer.WriteEndObject();
    }
}
