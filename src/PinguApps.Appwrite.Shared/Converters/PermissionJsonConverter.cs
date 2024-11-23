using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Converters;
public class PermissionJsonConverter : JsonConverter<Permission>
{
    public override Permission? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.String)
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

        var permissionBuilder = permissionTypeStr switch
        {
            "read" => Permission.Read(),
            "write" => Permission.Write(),
            "create" => Permission.Create(),
            "update" => Permission.Update(),
            "delete" => Permission.Delete(),
            _ => throw new JsonException($"Unknown permission type: {permissionTypeStr}")
        };

        // Parse the role string
        return roleString switch
        {
            "any" => permissionBuilder.Any(),
            "users" => permissionBuilder.Users(),
            "guests" => permissionBuilder.Guests(),
            var s when s.StartsWith("user:") => ParseUserRole(permissionBuilder, s[5..]),
            var s when s.StartsWith("users/") => ParseUsersRole(permissionBuilder, s[6..]),
            var s when s.StartsWith("team:") => ParseTeamRole(permissionBuilder, s[5..]),
            var s when s.StartsWith("member:") => permissionBuilder.Member(s[7..]),
            var s when s.StartsWith("label:") => permissionBuilder.Label(s[6..]),
            _ => throw new JsonException($"Unknown role format: {roleString}")
        };
    }

    private static Permission ParseUserRole(Permission.PermissionBuilder builder, string value)
    {
        var parts = value.Split('/');
        return parts.Length == 2
            ? builder.User(parts[0], Enum.Parse<RoleStatus>(parts[1], true))
            : builder.User(parts[0]);
    }

    private static Permission ParseUsersRole(Permission.PermissionBuilder builder, string value)
    {
        return builder.Users(Enum.Parse<RoleStatus>(value, true));
    }

    private static Permission ParseTeamRole(Permission.PermissionBuilder builder, string value)
    {
        var parts = value.Split('/');
        return parts.Length == 2
            ? builder.Team(parts[0], parts[1])
            : builder.Team(parts[0]);
    }

    public override void Write(Utf8JsonWriter writer, Permission value, JsonSerializerOptions options)
    {
        var roleString = value.RoleType switch
        {
            RoleType.Any => "any",
            RoleType.User => FormatUserRole(value),
            RoleType.Users => FormatUsersRole(value),
            RoleType.Guests => "guests",
            RoleType.Team => FormatTeamRole(value),
            RoleType.Member => $"member:{value.Id}",
            RoleType.Label => $"label:{value.Label}",
            _ => throw new JsonException($"Unknown role type: {value.RoleType}")
        };

        var permissionString = value.PermissionType.ToString().ToLower() + $"(\"{roleString}\")";
        writer.WriteStringValue(permissionString);
    }

    private static string FormatUserRole(Permission permission)
    {
        return permission.Status.HasValue
            ? $"user:{permission.Id}/{permission.Status.ToString()!.ToLower()}"
            : $"user:{permission.Id}";
    }

    private static string FormatUsersRole(Permission permission)
    {
        return permission.Status.HasValue
            ? $"users/{permission.Status.ToString()!.ToLower()}"
            : "users";
    }

    private static string FormatTeamRole(Permission permission)
    {
        return string.IsNullOrEmpty(permission.TeamRole)
            ? $"team:{permission.Id}"
            : $"team:{permission.Id}/{permission.TeamRole}";
    }
}

