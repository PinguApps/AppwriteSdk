﻿using System.Text.Encodings.Web;
using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class PermissionListConverterTests
{
    private readonly JsonSerializerOptions _options;

    public PermissionListConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters =
            {
                new PermissionListConverter(),
                new RoleJsonConverter(),
                new PermissionJsonConverter()
            }
        };
    }

    [Fact]
    public void Read_EmptyArray_ReturnsEmptyList()
    {
        // Arrange
        var json = "[]";

        // Act
        var result = JsonSerializer.Deserialize<List<Permission>>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
        Assert.IsType<List<Permission>>(result);
    }

    [Fact]
    public void Read_SinglePermission_DeserializesCorrectly()
    {
        // Arrange
        var json = "[\"read(\\\"any\\\")\"]";

        // Act
        var result = JsonSerializer.Deserialize<List<Permission>>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(PermissionType.Read, result[0].PermissionType);
        Assert.Equal(RoleType.Any, result[0].Role.RoleType);
    }

    [Fact]
    public void Read_MultiplePermissions_DeserializesCorrectly()
    {
        // Arrange
        var json = """
            [
                "read(\"any\")",
                "write(\"user:123/verified\")",
                "create(\"team:456/admin\")"
            ]
            """;

        // Act
        var result = JsonSerializer.Deserialize<List<Permission>>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);

        Assert.Equal(PermissionType.Read, result[0].PermissionType);
        Assert.Equal(RoleType.Any, result[0].Role.RoleType);

        Assert.Equal(PermissionType.Write, result[1].PermissionType);
        Assert.Equal(RoleType.User, result[1].Role.RoleType);
        Assert.Equal("123", result[1].Role.Id);
        Assert.Equal(RoleStatus.Verified, result[1].Role.Status);

        Assert.Equal(PermissionType.Create, result[2].PermissionType);
        Assert.Equal(RoleType.Team, result[2].Role.RoleType);
        Assert.Equal("456", result[2].Role.Id);
        Assert.Equal("admin", result[2].Role.TeamRole);
    }

    [Theory]
    [InlineData("")]
    [InlineData("{}")]
    [InlineData("\"not-an-array\"")]
    [InlineData("[")]
    [InlineData("]")]
    public void Read_InvalidJson_ThrowsJsonException(string invalidJson)
    {
        // Act & Assert
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<List<Permission>>(invalidJson, _options));
    }

    [Fact]
    public void Read_NullValueInArray_ThrowsJsonException()
    {
        // Arrange
        var json = "[\"read(\\\"any\\\")\", null]";

        // Act & Assert
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<List<Permission>>(json, _options));
    }

    [Fact]
    public void Write_EmptyList_SerializesCorrectly()
    {
        // Arrange
        var permissions = new List<Permission>();

        // Act
        var json = JsonSerializer.Serialize(permissions, _options);

        // Assert
        Assert.Equal("[]", json);
    }

    [Fact]
    public void Write_SinglePermission_SerializesCorrectly()
    {
        // Arrange
        var permissions = new List<Permission>
        {
            Permission.Read(Role.Any())
        };

        // Act
        var json = JsonSerializer.Serialize(permissions, _options);

        // Assert
        Assert.Equal("[\"read(\\\"any\\\")\"]", json);
    }

    [Fact]
    public void Write_MultiplePermissions_SerializesCorrectly()
    {
        // Arrange
        var permissions = new List<Permission>
        {
            Permission.Read(Role.Any()),
            Permission.Write(Role.User("123", RoleStatus.Verified)),
            Permission.Create(Role.Team("456", "admin"))
        };

        // Act
        var json = JsonSerializer.Serialize(permissions, _options);

        // Assert
        var expectedJson = "[\"read(\\\"any\\\")\",\"write(\\\"user:123/verified\\\")\",\"create(\\\"team:456/admin\\\")\"]";
        Assert.Equal(expectedJson, json);
    }
}