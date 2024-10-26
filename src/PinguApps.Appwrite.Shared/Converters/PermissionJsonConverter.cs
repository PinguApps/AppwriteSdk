using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Converters;
public class PermissionJsonConverter : JsonConverter<Permission>
{
    public override Permission? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException("Expected string value for Permission");
        }

        var value = reader.GetString()!;

        // Format is "permissionType(\"roleString\")"
        var openParenIndex = value.IndexOf('(');
        var closeParenIndex = value.LastIndexOf(')');

        if (openParenIndex == -1 || closeParenIndex == -1)
        {
            throw new JsonException("Invalid Permission format");
        }

        var permissionTypeStr = value[..openParenIndex].ToLower();
        // Remove the quotes from the role string
        var roleString = value[(openParenIndex + 2)..(closeParenIndex - 1)];

        // Deserialize the role first
        var role = JsonSerializer.Deserialize<Role>(JsonSerializer.Serialize(roleString), options)!;

        return permissionTypeStr switch
        {
            "read" => Permission.Read(role),
            "write" => Permission.Write(role),
            "create" => Permission.Create(role),
            "update" => Permission.Update(role),
            "delete" => Permission.Delete(role),
            _ => throw new JsonException($"Unknown permission type: {permissionTypeStr}")
        };
    }

    public override void Write(Utf8JsonWriter writer, Permission value, JsonSerializerOptions options)
    {
        var roleString = JsonSerializer.Deserialize<string>(JsonSerializer.Serialize(value.Role, options))!;
        var result = value.PermissionType.ToString().ToLower() + $"(\"{roleString}\")";
        writer.WriteStringValue(result);
    }
}

