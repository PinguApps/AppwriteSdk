using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Utils;
public class PermissionTests
{
    [Fact]
    public void Read_Any_CreatesCorrectPermission()
    {
        // Act
        var permission = Permission.Read().Any();

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Any, permission.RoleType);
        Assert.Null(permission.Id);
        Assert.Null(permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Theory]
    [InlineData("user123")]
    [InlineData("user456")]
    public void Read_User_CreatesCorrectPermission(string userId)
    {
        // Act
        var permission = Permission.Read().User(userId);

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.User, permission.RoleType);
        Assert.Equal(userId, permission.Id);
        Assert.Null(permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Theory]
    [InlineData("user123", RoleStatus.Verified)]
    [InlineData("user456", RoleStatus.Unverified)]
    public void Read_UserWithStatus_CreatesCorrectPermission(string userId, RoleStatus status)
    {
        // Act
        var permission = Permission.Read().User(userId, status);

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.User, permission.RoleType);
        Assert.Equal(userId, permission.Id);
        Assert.Equal(status, permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Fact]
    public void Read_Users_CreatesCorrectPermission()
    {
        // Act
        var permission = Permission.Read().Users();

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Users, permission.RoleType);
        Assert.Null(permission.Id);
        Assert.Null(permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Theory]
    [InlineData(RoleStatus.Verified)]
    [InlineData(RoleStatus.Unverified)]
    public void Read_UsersWithStatus_CreatesCorrectPermission(RoleStatus status)
    {
        // Act
        var permission = Permission.Read().Users(status);

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Users, permission.RoleType);
        Assert.Null(permission.Id);
        Assert.Equal(status, permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Fact]
    public void Read_Guests_CreatesCorrectPermission()
    {
        // Act
        var permission = Permission.Read().Guests();

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Guests, permission.RoleType);
        Assert.Null(permission.Id);
        Assert.Null(permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Theory]
    [InlineData("team123")]
    [InlineData("team456")]
    public void Read_Team_CreatesCorrectPermission(string teamId)
    {
        // Act
        var permission = Permission.Read().Team(teamId);

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Team, permission.RoleType);
        Assert.Equal(teamId, permission.Id);
        Assert.Null(permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Theory]
    [InlineData("team123", "admin")]
    [InlineData("team456", "member")]
    public void Read_TeamWithRole_CreatesCorrectPermission(string teamId, string teamRole)
    {
        // Act
        var permission = Permission.Read().Team(teamId, teamRole);

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Team, permission.RoleType);
        Assert.Equal(teamId, permission.Id);
        Assert.Null(permission.Status);
        Assert.Equal(teamRole, permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Theory]
    [InlineData("member123")]
    [InlineData("member456")]
    public void Read_Member_CreatesCorrectPermission(string memberId)
    {
        // Act
        var permission = Permission.Read().Member(memberId);

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Member, permission.RoleType);
        Assert.Equal(memberId, permission.Id);
        Assert.Null(permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Null(permission.Label);
    }

    [Theory]
    [InlineData("label1")]
    [InlineData("label2")]
    public void Read_Label_CreatesCorrectPermission(string labelName)
    {
        // Act
        var permission = Permission.Read().Label(labelName);

        // Assert
        Assert.Equal(PermissionType.Read, permission.PermissionType);
        Assert.Equal(RoleType.Label, permission.RoleType);
        Assert.Null(permission.Id);
        Assert.Null(permission.Status);
        Assert.Null(permission.TeamRole);
        Assert.Equal(labelName, permission.Label);
    }

    // Test all permission types with a sample role
    [Theory]
    [InlineData(PermissionType.Read)]
    [InlineData(PermissionType.Write)]
    [InlineData(PermissionType.Create)]
    [InlineData(PermissionType.Update)]
    [InlineData(PermissionType.Delete)]
    public void AllPermissionTypes_CreateCorrectPermissions(PermissionType permissionType)
    {
        // Arrange
        var builder = permissionType switch
        {
            PermissionType.Read => Permission.Read(),
            PermissionType.Write => Permission.Write(),
            PermissionType.Create => Permission.Create(),
            PermissionType.Update => Permission.Update(),
            PermissionType.Delete => Permission.Delete(),
            _ => throw new ArgumentException("Invalid permission type")
        };

        // Act
        var permission = builder.User("123", RoleStatus.Verified);

        // Assert
        Assert.Equal(permissionType, permission.PermissionType);
        Assert.Equal(RoleType.User, permission.RoleType);
        Assert.Equal("123", permission.Id);
        Assert.Equal(RoleStatus.Verified, permission.Status);
    }
}
