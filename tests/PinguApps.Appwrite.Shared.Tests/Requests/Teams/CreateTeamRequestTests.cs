using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class CreateTeamRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateTeamRequest();

        // Assert
        Assert.NotEmpty(request.TeamId);
        Assert.Equal(string.Empty, request.Name);
        Assert.Null(request.Roles);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var teamId = IdUtils.GenerateUniqueId();
        var name = "My Team";
        var roles = new List<string> { "owner", "admin" };

        var request = new CreateTeamRequest();

        // Act
        request.TeamId = teamId;
        request.Name = name;
        request.Roles = roles;

        // Assert
        Assert.Equal(teamId, request.TeamId);
        Assert.Equal(name, request.Name);
        Assert.Equal(roles, request.Roles);
    }

    public static TheoryData<CreateTeamRequest> ValidRequestsData = new()
    {
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = "Valid Team Name",
            Roles = ["owner", "admin"]
        },
        new()
        {
            TeamId = "validTeamId123",
            Name = "Another Valid Team",
            Roles = null
        }
    };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateTeamRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateTeamRequest> InvalidRequestsData = new()
    {
        new()
        {
            TeamId = null!,
            Name = "Pingu"
        },
        new()
        {
            TeamId = "",
            Name = "Pingu"
        },
        new()
        {
            TeamId = "invalid chars!",
            Name = "Pingu"
        },
        new()
        {
            TeamId = ".startsWithSymbol",
            Name = "Pingu"
        },
        new()
        {
            TeamId = new string('a', 37),
            Name = "Pingu"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = null!
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = ""
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = new string('a', 129)
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = "Pingu",
            Roles = ["", "admin"]
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = "Pingu",
            Roles = [new string('a', 33)]
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = "Pingu",
            Roles = new List<string>(new string[101])
        }
    };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateTeamRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new CreateTeamRequest
        {
            TeamId = "",
            Name = "",
            Roles = [""]
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateTeamRequest
        {
            TeamId = "",
            Name = "",
            Roles = [""]
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
