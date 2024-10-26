using System.Text.Encodings.Web;
using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class PermissionJsonConverterTests
{
    private readonly JsonSerializerOptions _options;
    private readonly PermissionJsonConverter _converter;

    public PermissionJsonConverterTests()
    {
        _converter = new PermissionJsonConverter();
        _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = { _converter, new RoleJsonConverter() }
        };
    }

    [Theory]
    [InlineData(PermissionType.Read, "read")]
    [InlineData(PermissionType.Write, "write")]
    [InlineData(PermissionType.Create, "create")]
    [InlineData(PermissionType.Update, "update")]
    [InlineData(PermissionType.Delete, "delete")]
    public void Write_AllPermissionTypes_SerializeCorrectly(PermissionType permissionType, string expectedPrefix)
    {
        // Arrange
        var permission = permissionType switch
        {
            PermissionType.Read => Permission.Read(Role.Any()),
            PermissionType.Write => Permission.Write(Role.Any()),
            PermissionType.Create => Permission.Create(Role.Any()),
            PermissionType.Update => Permission.Update(Role.Any()),
            PermissionType.Delete => Permission.Delete(Role.Any()),
            _ => throw new ArgumentException("Invalid permission type")
        };

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal($"\"{expectedPrefix}(\\\"any\\\")\"", json);
    }

    [Theory]
    [InlineData("read(\\\"any\\\")", PermissionType.Read, RoleType.Any)]
    [InlineData("write(\\\"user:123\\\")", PermissionType.Write, RoleType.User)]
    [InlineData("create(\\\"team:456/admin\\\")", PermissionType.Create, RoleType.Team)]
    [InlineData("update(\\\"users/verified\\\")", PermissionType.Update, RoleType.Users)]
    [InlineData("delete(\\\"label:test\\\")", PermissionType.Delete, RoleType.Label)]
    public void Read_ValidPermissions_DeserializeCorrectly(string json, PermissionType expectedPermissionType, RoleType expectedRoleType)
    {
        // Act
        var permission = JsonSerializer.Deserialize<Permission>($"\"{json}\"", _options);

        // Assert
        Assert.NotNull(permission);
        Assert.Equal(expectedPermissionType, permission.PermissionType);
        Assert.Equal(expectedRoleType, permission.Role.RoleType);
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
    [InlineData("read\"any\")")]
    [InlineData("read(\"any\"")]
    [InlineData("unknown(\"any\")")]
    public void Read_InvalidFormat_ThrowsJsonException(string invalidJson)
    {
        // Act & Assert
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<Permission>($"\"{invalidJson}\"", _options));
    }

    [Fact]
    public void Write_ComplexPermission_SerializesCorrectly()
    {
        // Arrange
        var role = Role.Team("123", "admin");
        var permission = Permission.Write(role);

        // Act
        var json = JsonSerializer.Serialize(permission, _options);

        // Assert
        Assert.Equal("\"write(\\\"team:123/admin\\\")\"", json);
    }

    [Fact]
    public void Read_ComplexPermission_DeserializesCorrectly()
    {
        // Arrange
        var json = "\"write(\\\"team:123/admin\\\")\"";

        // Act
        var permission = JsonSerializer.Deserialize<Permission>(json, _options);

        // Assert
        Assert.NotNull(permission);
        Assert.Equal(PermissionType.Write, permission.PermissionType);
        Assert.Equal(RoleType.Team, permission.Role.RoleType);
        Assert.Equal("123", permission.Role.Id);
        Assert.Equal("admin", permission.Role.TeamRole);
    }

    [Fact]
    public void Read_ThrowsJsonException_ForUnknownPermissionType()
    {
        // Arrange
        var json = "\"invalidPermissionType(\\\"any\\\")\"";

        // Act & Assert
        var exception = Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<Permission>(json, _options)
        );

        Assert.Equal("Unknown permission type: invalidpermissiontype", exception.Message);
    }
}
