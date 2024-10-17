using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class UpdateTeamMembershipStatusRequestTests : TeamMembershipIdBaseRequestTests<UpdateTeamMembershipStatusRequest, UpdateTeamMembershipStatusRequestValidator>
{
    protected override UpdateTeamMembershipStatusRequest CreateValidTeamMembershipIdRequest => new()
    {
        UserId = IdUtils.GenerateUniqueId(),
        Secret = "123456"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateTeamMembershipStatusRequest();

        // Assert
        Assert.Equal(string.Empty, request.UserId);
        Assert.Equal(string.Empty, request.Secret);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var userId = "validUserId";
        var secret = "validSecret";
        var request = new UpdateTeamMembershipStatusRequest();

        // Act
        request.UserId = userId;
        request.Secret = secret;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(secret, request.Secret);
    }

    public static TheoryData<UpdateTeamMembershipStatusRequest> ValidRequestsData = new()
    {
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Secret = "validSecret"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Secret = "123456"
        }
    };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateTeamMembershipStatusRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateTeamMembershipStatusRequest> InvalidRequestsData = new()
    {
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = string.Empty,
            Secret = "123456"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = null!,
            Secret = "123456"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = "invalidUserId!",
            Secret = "validSecret"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = ".startsWithSymbol",
            Secret = "validSecret"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = new string('a', 37),
            Secret = "validSecret"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Secret = string.Empty
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Secret = null!
        }
    };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateTeamMembershipStatusRequest request)
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
        var request = new UpdateTeamMembershipStatusRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = string.Empty,
            Secret = string.Empty
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateTeamMembershipStatusRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = string.Empty,
            Secret = string.Empty
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
