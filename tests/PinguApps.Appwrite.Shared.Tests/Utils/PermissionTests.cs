using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Utils;
public class PermissionTests
{
    private readonly Role _testRole = Role.Any();

    [Fact]
    public void Read_CreatesCorrectPermission()
    {
        // Act
        var permission = Permission.Read(_testRole);

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Same(_testRole, permission.Role);
    }

    [Fact]
    public void Write_CreatesCorrectPermission()
    {
        // Act
        var permission = Permission.Write(_testRole);

        // Assert
        Assert.Equal(PermissionType.Write, permission.PermissionType);
        Assert.Same(_testRole, permission.Role);
    }

    [Fact]
    public void Create_CreatesCorrectPermission()
    {
        // Act
        var permission = Permission.Create(_testRole);

        // Assert
        Assert.Equal(PermissionType.Create, permission.PermissionType);
        Assert.Same(_testRole, permission.Role);
    }

    [Fact]
    public void Update_CreatesCorrectPermission()
    {
        // Act
        var permission = Permission.Update(_testRole);

        // Assert
        Assert.Equal(PermissionType.Update, permission.PermissionType);
        Assert.Same(_testRole, permission.Role);
    }

    [Fact]
    public void Delete_CreatesCorrectPermission()
    {
        // Act
        var permission = Permission.Delete(_testRole);

        // Assert
        Assert.Equal(PermissionType.Delete, permission.PermissionType);
        Assert.Same(_testRole, permission.Role);
    }

    [Theory]
    [InlineData(PermissionType.Read)]
    [InlineData(PermissionType.Write)]
    [InlineData(PermissionType.Create)]
    [InlineData(PermissionType.Update)]
    [InlineData(PermissionType.Delete)]
    public void Permission_StoresRoleReference(PermissionType permissionType)
    {
        // Arrange
        var role = Role.User("123", RoleStatus.Verified);

        // Act
        var permission = permissionType switch
        {
            PermissionType.Read => Permission.Read(role),
            PermissionType.Write => Permission.Write(role),
            PermissionType.Create => Permission.Create(role),
            PermissionType.Update => Permission.Update(role),
            PermissionType.Delete => Permission.Delete(role),
            _ => throw new ArgumentException("Invalid permission type")
        };

        // Assert
        Assert.Same(role, permission.Role);
        Assert.Equal(permissionType, permission.PermissionType);
    }
}
