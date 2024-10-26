using System.Reflection;
using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class RoleJsonConverterTests
{
    private readonly JsonSerializerOptions _options;
    private readonly RoleJsonConverter _converter;

    public RoleJsonConverterTests()
    {
        _converter = new();
        _options = new()
        {
            Converters = { _converter }
        };
    }

    [Theory]
    [InlineData("any", RoleType.Any)]
    [InlineData("users", RoleType.Users)]
    [InlineData("guests", RoleType.Guests)]
    public void Read_SimpleRoles_DeserializesCorrectly(string json, RoleType expectedType)
    {
        // Act
        var role = JsonSerializer.Deserialize<Role>($"\"{json}\"", _options);

        // Assert
        Assert.NotNull(role);
        Assert.Equal(expectedType, role.RoleType);
    }

    [Theory]
    [InlineData("user:123", "123", null)]
    [InlineData("user:123/verified", "123", RoleStatus.Verified)]
    [InlineData("user:456/unverified", "456", RoleStatus.Unverified)]
    public void Read_UserRoles_DeserializesCorrectly(string json, string expectedId, RoleStatus? expectedStatus)
    {
        // Act
        var role = JsonSerializer.Deserialize<Role>($"\"{json}\"", _options);

        // Assert
        Assert.NotNull(role);
        Assert.Equal(RoleType.User, role.RoleType);
        Assert.Equal(expectedId, role.Id);
        Assert.Equal(expectedStatus, role.Status);
    }

    [Theory]
    [InlineData("users/verified", RoleStatus.Verified)]
    [InlineData("users/unverified", RoleStatus.Unverified)]
    public void Read_UsersWithStatus_DeserializesCorrectly(string json, RoleStatus expectedStatus)
    {
        // Act
        var role = JsonSerializer.Deserialize<Role>($"\"{json}\"", _options);

        // Assert
        Assert.NotNull(role);
        Assert.Equal(RoleType.Users, role.RoleType);
        Assert.Equal(expectedStatus, role.Status);
    }

    [Theory]
    [InlineData("team:123", "123", null)]
    [InlineData("team:456/admin", "456", "admin")]
    [InlineData("team:789/member", "789", "member")]
    public void Read_TeamRoles_DeserializesCorrectly(string json, string expectedId, string? expectedTeamRole)
    {
        // Act
        var role = JsonSerializer.Deserialize<Role>($"\"{json}\"", _options);

        // Assert
        Assert.NotNull(role);
        Assert.Equal(RoleType.Team, role.RoleType);
        Assert.Equal(expectedId, role.Id);
        Assert.Equal(expectedTeamRole, role.TeamRole);
    }

    [Fact]
    public void Read_MemberRole_DeserializesCorrectly()
    {
        // Arrange
        var json = "\"member:123\"";

        // Act
        var role = JsonSerializer.Deserialize<Role>(json, _options);

        // Assert
        Assert.NotNull(role);
        Assert.Equal(RoleType.Member, role.RoleType);
        Assert.Equal("123", role.Id);
    }

    [Fact]
    public void Read_LabelRole_DeserializesCorrectly()
    {
        // Arrange
        var json = "\"label:testLabel\"";

        // Act
        var role = JsonSerializer.Deserialize<Role>(json, _options);

        // Assert
        Assert.NotNull(role);
        Assert.Equal(RoleType.Label, role.RoleType);
        Assert.Equal("testLabel", role.LabelName);
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
            JsonSerializer.Deserialize<Role>(json, _options));
    }

    [Theory]
    [InlineData("")]
    [InlineData("invalid")]
    public void Read_InvalidFormat_ThrowsJsonException(string invalidJson)
    {
        // Act & Assert
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<Role>($"\"{invalidJson}\"", _options));
    }

    [Fact]
    public void Write_Any_SerializesCorrectly()
    {
        // Arrange
        var role = Role.Any();

        // Act
        var json = JsonSerializer.Serialize(role, _options);

        // Assert
        Assert.Equal("\"any\"", json);
    }

    [Fact]
    public void Write_Guests_SerializesCorrectly()
    {
        // Arrange
        var role = Role.Guests();

        // Act
        var json = JsonSerializer.Serialize(role, _options);

        // Assert
        Assert.Equal("\"guests\"", json);
    }

    [Theory]
    [InlineData(null, "user:123")]
    [InlineData(RoleStatus.Verified, "user:123/verified")]
    [InlineData(RoleStatus.Unverified, "user:123/unverified")]
    public void Write_User_SerializesCorrectly(RoleStatus? status, string expected)
    {
        // Arrange
        var role = status.HasValue ? Role.User("123", status.Value) : Role.User("123");

        // Act
        var json = JsonSerializer.Serialize(role, _options);

        // Assert
        Assert.Equal($"\"{expected}\"", json);
    }

    [Theory]
    [InlineData(null, "users")]
    [InlineData(RoleStatus.Verified, "users/verified")]
    [InlineData(RoleStatus.Unverified, "users/unverified")]
    public void Write_Users_SerializesCorrectly(RoleStatus? status, string expected)
    {
        // Arrange
        var role = status.HasValue ? Role.Users(status.Value) : Role.Users();

        // Act
        var json = JsonSerializer.Serialize(role, _options);

        // Assert
        Assert.Equal($"\"{expected}\"", json);
    }

    [Theory]
    [InlineData(null, "team:123")]
    [InlineData("admin", "team:123/admin")]
    [InlineData("member", "team:123/member")]
    public void Write_Team_SerializesCorrectly(string? teamRole, string expected)
    {
        // Arrange
        var role = teamRole != null ? Role.Team("123", teamRole) : Role.Team("123");

        // Act
        var json = JsonSerializer.Serialize(role, _options);

        // Assert
        Assert.Equal($"\"{expected}\"", json);
    }

    [Fact]
    public void Write_Member_SerializesCorrectly()
    {
        // Arrange
        var role = Role.Member("123");

        // Act
        var json = JsonSerializer.Serialize(role, _options);

        // Assert
        Assert.Equal("\"member:123\"", json);
    }

    [Fact]
    public void Write_Label_SerializesCorrectly()
    {
        // Arrange
        var role = Role.Label("testLabel");

        // Act
        var json = JsonSerializer.Serialize(role, _options);

        // Assert
        Assert.Equal("\"label:testLabel\"", json);
    }

    [Fact]
    public void Write_ThrowsJsonException_ForUnknownRoleType()
    {
        // Arrange
        var options = new JsonSerializerOptions
        {
            Converters = { new RoleJsonConverter() }
        };

        // Use reflection to create a Role object with an unknown RoleType
        var roleType = (RoleType)999; // Assuming 999 is not a valid RoleType
        var role = CreateRoleWithInvalidRoleType(roleType);

        // Act & Assert
        var exception = Assert.Throws<JsonException>(() =>
            JsonSerializer.Serialize(role, options)
        );

        Assert.Equal($"Unknown role type: {roleType}", exception.Message);
    }

    private Role CreateRoleWithInvalidRoleType(RoleType roleType)
    {
        // Use reflection to create an instance of Role
        var roleTypeInstance = typeof(Role);
        var constructor = roleTypeInstance.GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            [typeof(RoleType)],
            null
        );

        if (constructor is null)
        {
            throw new InvalidOperationException("Role constructor not found.");
        }

        var role = (Role)constructor.Invoke([roleType]);
        return role;
    }
}
