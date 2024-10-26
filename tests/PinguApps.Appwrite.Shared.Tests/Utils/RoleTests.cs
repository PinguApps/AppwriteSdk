using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Utils;
public class RoleTests
{
    [Fact]
    public void Any_CreatesCorrectRole()
    {
        // Act
        var role = Role.Any();

        // Assert
        Assert.Equal(RoleType.Any, role.RoleType);
        Assert.Null(role.Id);
        Assert.Null(role.Status);
        Assert.Null(role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Fact]
    public void User_WithId_CreatesCorrectRole()
    {
        // Arrange
        var userId = "123";

        // Act
        var role = Role.User(userId);

        // Assert
        Assert.Equal(RoleType.User, role.RoleType);
        Assert.Equal(userId, role.Id);
        Assert.Null(role.Status);
        Assert.Null(role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Theory]
    [InlineData("123", RoleStatus.Verified)]
    [InlineData("456", RoleStatus.Unverified)]
    public void User_WithIdAndStatus_CreatesCorrectRole(string userId, RoleStatus status)
    {
        // Act
        var role = Role.User(userId, status);

        // Assert
        Assert.Equal(RoleType.User, role.RoleType);
        Assert.Equal(userId, role.Id);
        Assert.Equal(status, role.Status);
        Assert.Null(role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Fact]
    public void Users_CreatesCorrectRole()
    {
        // Act
        var role = Role.Users();

        // Assert
        Assert.Equal(RoleType.Users, role.RoleType);
        Assert.Null(role.Id);
        Assert.Null(role.Status);
        Assert.Null(role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Theory]
    [InlineData(RoleStatus.Verified)]
    [InlineData(RoleStatus.Unverified)]
    public void Users_WithStatus_CreatesCorrectRole(RoleStatus status)
    {
        // Act
        var role = Role.Users(status);

        // Assert
        Assert.Equal(RoleType.Users, role.RoleType);
        Assert.Null(role.Id);
        Assert.Equal(status, role.Status);
        Assert.Null(role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Fact]
    public void Guests_CreatesCorrectRole()
    {
        // Act
        var role = Role.Guests();

        // Assert
        Assert.Equal(RoleType.Guests, role.RoleType);
        Assert.Null(role.Id);
        Assert.Null(role.Status);
        Assert.Null(role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Fact]
    public void Team_WithId_CreatesCorrectRole()
    {
        // Arrange
        var teamId = "team123";

        // Act
        var role = Role.Team(teamId);

        // Assert
        Assert.Equal(RoleType.Team, role.RoleType);
        Assert.Equal(teamId, role.Id);
        Assert.Null(role.Status);
        Assert.Null(role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Theory]
    [InlineData("team123", "admin")]
    [InlineData("team456", "member")]
    public void Team_WithIdAndRole_CreatesCorrectRole(string teamId, string teamRole)
    {
        // Act
        var role = Role.Team(teamId, teamRole);

        // Assert
        Assert.Equal(RoleType.Team, role.RoleType);
        Assert.Equal(teamId, role.Id);
        Assert.Null(role.Status);
        Assert.Equal(teamRole, role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Fact]
    public void Member_CreatesCorrectRole()
    {
        // Arrange
        var memberId = "member123";

        // Act
        var role = Role.Member(memberId);

        // Assert
        Assert.Equal(RoleType.Member, role.RoleType);
        Assert.Equal(memberId, role.Id);
        Assert.Null(role.Status);
        Assert.Null(role.TeamRole);
        Assert.Null(role.LabelName);
    }

    [Fact]
    public void Label_CreatesCorrectRole()
    {
        // Arrange
        var labelName = "testLabel";

        // Act
        var role = Role.Label(labelName);

        // Assert
        Assert.Equal(RoleType.Label, role.RoleType);
        Assert.Null(role.Id);
        Assert.Null(role.Status);
        Assert.Null(role.TeamRole);
        Assert.Equal(labelName, role.LabelName);
    }
}
