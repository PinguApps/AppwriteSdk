using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Converters;
public class RoleJsonConverter : JsonConverter<Role>
{
    public override Role? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException("Expected string value for Role");
        }

        var value = reader.GetString()!;

        // Handle the simple cases first
        return value switch
        {
            "any" => Role.Any(),
            "users" => Role.Users(),
            "guests" => Role.Guests(),
            _ => ParseComplexRole(value)
        };
    }

    private static Role ParseComplexRole(string value)
    {
        if (value.StartsWith("user:"))
        {
            var parts = value[5..].Split('/');
            return parts.Length == 2
                ? Role.User(parts[0], Enum.Parse<RoleStatus>(parts[1], true))
                : Role.User(parts[0]);
        }

        if (value.StartsWith("users/"))
        {
            return Role.Users(Enum.Parse<RoleStatus>(value[6..], true));
        }

        if (value.StartsWith("team:"))
        {
            var parts = value[5..].Split('/');
            return parts.Length == 2
                ? Role.Team(parts[0], parts[1])
                : Role.Team(parts[0]);
        }

        if (value.StartsWith("member:"))
        {
            return Role.Member(value[7..]);
        }

        if (value.StartsWith("label:"))
        {
            return Role.Label(value[6..]);
        }

        throw new JsonException($"Unknown role format: {value}");
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        string result = value.RoleType switch
        {
            RoleType.Any => "any",
            RoleType.User => FormatUserRole(value),
            RoleType.Users => FormatUsersRole(value),
            RoleType.Guests => "guests",
            RoleType.Team => FormatTeamRole(value),
            RoleType.Member => $"member:{value.Id}",
            RoleType.Label => $"label:{value.LabelName}",
            _ => throw new JsonException($"Unknown role type: {value.RoleType}")
        };

        writer.WriteStringValue(result);
    }

    private static string FormatUserRole(Role role)
    {
        return role.Status.HasValue
            ? $"user:{role.Id}/{role.Status.ToString()!.ToLower()}"
            : $"user:{role.Id}";
    }

    private static string FormatUsersRole(Role role)
    {
        return role.Status.HasValue
            ? $"users/{role.Status.ToString()!.ToLower()}"
            : "users";
    }

    private static string FormatTeamRole(Role role)
    {
        return string.IsNullOrEmpty(role.TeamRole)
            ? $"team:{role.Id}"
            : $"team:{role.Id}/{role.TeamRole}";
    }
}

