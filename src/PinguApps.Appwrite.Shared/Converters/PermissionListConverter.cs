using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Converters;
public class PermissionListConverter : JsonConverter<List<Permission>>
{
    private readonly PermissionJsonConverter _permissionConverter = new();

    public override List<Permission>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType is not JsonTokenType.StartArray)
        {
            throw new JsonException("Expected start of array");
        }

        var permissions = new List<Permission>();

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
            {
                break;
            }

            var permission = _permissionConverter.Read(ref reader, typeof(Permission), options);

            if (permission is not null)
            {
                permissions.Add(permission);
            }
        }

        return permissions;
    }

    public override void Write(Utf8JsonWriter writer, List<Permission> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var permission in value)
        {
            _permissionConverter.Write(writer, permission, options);
        }

        writer.WriteEndArray();
    }
}
