using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class PermissionJsonConverterTests
{
    private readonly JsonSerializerOptions _options;

    public PermissionJsonConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = { new PermissionJsonConverter() }
        };
    }

    [Theory]
    [InlineData("read(\\\"any\\\")", PermissionType.Read, RoleType.Any)]
    [InlineData("write(\\\"any\\\")", PermissionType.Write, RoleType.Any)]
    [InlineData("create(\\\"any\\\")", PermissionType.Create, RoleType.Any)]
    [InlineData("update(\\\"any\\\")", PermissionType.Update, RoleType.Any)]
    [InlineData("delete(\\\"any\\\")", PermissionType.Delete, RoleType.Any)]
    public void Read_SimplePermissions_DeserializeCorrectly(string json, PermissionType expectedPermType, RoleType expectedRoleType)
    {
        // Act
        var permission = JsonSerializer.Deserialize<Permission>($"\"{json}\"", _options);

        // Assert
        Assert.NotNull(permission);
        Assert.Equal(expectedPermType, permission.PermissionType);
        Assert.Equal(expectedRoleType, permission.RoleType);
    }

    [Theory]
    [InlineData("user:123", "123", null)]
    [InlineData("user:123/verified", "123", RoleStatus.Verified)]
    [InlineData("user:456/unverified", "456", RoleStatus.Unverified)]
    public void Read_UserPermissions_DeserializeCorrectly(string roleStr, string expectedId, RoleStatus? expectedStatus)
    {
        // Arrange
        var json = $"\"read(\\\"{roleStr}\\\")\"";

        // Act
        var permission = JsonSerializer.Deserialize<Permission>(json, _options);

        // Assert
        Assert.NotNull(permission);
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.User, permission.RoleType);
        Assert.Equal(expectedId, permission.Id);
        Assert.Equal(expectedStatus, permission.Status);
    }

    [Fact]
    public void Read_Guests_DeserializeCorrectly()
    {
        // Arrange
        var json = $"\"read(\\\"guests\\\")\"";

        // Act
        var permission = JsonSerializer.Deserialize<Permission>(json, _options);

        // Assert
        Assert.NotNull(permission);
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Guests, permission.RoleType);
    }

    [Theory]
    [InlineData("users")]
    [InlineData("users/verified")]
    [InlineData("users/unverified")]
    public void Read_UsersPermissions_DeserializeCorrectly(string roleStr)
    {
        // Arrange
        var json = $"\"read(\\\"{roleStr}\\\")\"";

        // Act
        var permission = JsonSerializer.Deserialize<Permission>(json, _options);

        // Assert
        Assert.NotNull(permission);
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Users, permission.RoleType);

        if (roleStr.Contains('/'))
        {
            Assert.Equal(
                Enum.Parse<RoleStatus>(roleStr.Split('/')[1], true),
                permission.Status);
        }
    }

    [Theory]
    [InlineData("team:123", "123", null)]
    [InlineData("team:456/admin", "456", "admin")]
    [InlineData("team:789/member", "789", "member")]
    public void Read_TeamPermissions_DeserializeCorrectly(string roleStr, string expectedId, string? expectedRole)
    {
        // Arrange
        var json = $"\"write(\\\"{roleStr}\\\")\"";

        // Act
        var permission = JsonSerializer.Deserialize<Permission>(json, _options);

        // Assert
        Assert.NotNull(permission);
        Assert.Equal(PermissionType.Write, permission.PermissionType);
        Assert.Equal(RoleType.Team, permission.RoleType);
        Assert.Equal(expectedId, permission.Id);
        Assert.Equal(expectedRole, permission.TeamRole);
    }

    [Theory]
    [InlineData("member:123")]
    [InlineData("label:testLabel")]
    public void Read_MemberAndLabelPermissions_DeserializeCorrectly(string roleStr)
    {
        // Arrange
        var json = $"\"read(\\\"{roleStr}\\\")\"";

        // Act
        var permission = JsonSerializer.Deserialize<Permission>(json, _options);

        // Assert
        Assert.NotNull(permission);
        Assert.Equal(PermissionType.Read, permission.PermissionType);

        if (roleStr.StartsWith("member:"))
        {
            Assert.Equal(RoleType.Member, permission.RoleType);
            Assert.Equal(roleStr[7..], permission.Id);
        }
        else
        {
            Assert.Equal(RoleType.Label, permission.RoleType);
            Assert.Equal(roleStr[6..], permission.Label);
        }
    }

    [Theory]
    [InlineData(42)]
    [InlineData(true)]
    public void Read_NonStringToken_ThrowsJsonException(object? invalidValue)
    {
        // Arrange
        var json = JsonSerializer.Serialize(invalidValue);

        // Act & Assert
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<Permission>(json, _options));
    }

    [Theory]
    [InlineData("")]
    [InlineData("invalid")]
    [InlineData("read")]
    [InlineData("read(any)")]
    [InlineData("read\\\"any\\\")")]
    [InlineData("read(\\\"any\\\"")]
    [InlineData("unknown(\\\"any\\\")")]
    public void Read_InvalidFormat_ThrowsJsonException(string invalidJson)
    {
        // Act & Assert
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<Permission>($"\"{invalidJson}\"", _options));
    }

    [Fact]
    public void Write_Any_SerializesCorrectly()
    {
        // Arrange
        var permission = Permission.Read().Any();

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal("\"read(\\\"any\\\")\"", json);
    }

    [Theory]
    [InlineData(null, "users")]
    [InlineData(RoleStatus.Verified, "users/verified")]
    [InlineData(RoleStatus.Unverified, "users/unverified")]
    public void Write_Users_SerializesCorrectly(RoleStatus? status, string expectedRole)
    {
        // Arrange
        var permission = status.HasValue
            ? Permission.Read().Users(status.Value)
            : Permission.Read().Users();

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal($"\"read(\\\"{expectedRole}\\\")\"", json);
    }

    [Fact]
    public void Write_Guests_SerializesCorrectly()
    {
        // Arrange
        var permission = Permission.Read().Guests();

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal("\"read(\\\"guests\\\")\"", json);
    }

    [Theory]
    [InlineData(null, "user:123")]
    [InlineData(RoleStatus.Verified, "user:123/verified")]
    [InlineData(RoleStatus.Unverified, "user:123/unverified")]
    public void Write_User_SerializesCorrectly(RoleStatus? status, string expectedRole)
    {
        // Arrange
        var permission = status.HasValue
            ? Permission.Write().User("123", status.Value)
            : Permission.Write().User("123");

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal($"\"write(\\\"{expectedRole}\\\")\"", json);
    }

    [Theory]
    [InlineData(null, "team:123")]
    [InlineData("admin", "team:123/admin")]
    public void Write_Team_SerializesCorrectly(string? teamRole, string expectedRole)
    {
        // Arrange
        var permission = teamRole != null
            ? Permission.Create().Team("123", teamRole)
            : Permission.Create().Team("123");

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal($"\"create(\\\"{expectedRole}\\\")\"", json);
    }

    [Fact]
    public void Write_Member_SerializesCorrectly()
    {
        // Arrange
        var permission = Permission.Create().Member("123");

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal("\"create(\\\"member:123\\\")\"", json);
    }

    [Fact]
    public void Write_Label_SerializesCorrectly()
    {
        // Arrange
        var permission = Permission.Write().Label("writer");

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal("\"write(\\\"label:writer\\\")\"", json);
    }

    [Fact]
    public void Write_ThrowsJsonException_ForUnknownRoleType()
    {
        // Arrange
        var invalidRoleType = (RoleType)999;

        var permission = CreatePermissionWithCustomProperties(PermissionType.Create, invalidRoleType, null, null, null, null);

        // Act & Assert
        var exception = Assert.Throws<JsonException>(() =>
            JsonSerializer.Serialize(permission, _options)
        );

        Assert.Equal("Unknown role type: 999", exception.Message);
    }

    private Permission CreatePermissionWithCustomProperties(PermissionType permissionType, RoleType roleType, string? id, RoleStatus? status, string? teamRole, string? label)
    {
        // Use reflection to create an instance of Permission
        var permissionT = typeof(Permission);
        var constructor = permissionT.GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
        null,
            [typeof(PermissionType), typeof(RoleType), typeof(string), typeof(RoleStatus?), typeof(string), typeof(string)],
            null
        );

        if (constructor == null)
        {
            throw new InvalidOperationException("Permission constructor not found.");
        }

        var permission = (Permission)constructor.Invoke([permissionType, roleType, id, status, teamRole, label]);
        return permission;
    }
}
