using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class UpdateMembershipRequestTests : TeamMembershipIdBaseRequestTests<UpdateMembershipRequest, UpdateMembershipRequestValidator>
{
    protected override UpdateMembershipRequest CreateValidTeamMembershipIdRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateMembershipRequest();

        // Assert
        Assert.Empty(request.Roles);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var roles = new List<string> { "admin", "member" };
        var request = new UpdateMembershipRequest();

        // Act
        request.Roles = roles;

        // Assert
        Assert.Equal(roles, request.Roles);
    }

    public static TheoryData<UpdateMembershipRequest> ValidRequestsData =
    [
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            Roles = ["admin", "member"]
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            Roles = []
        }
    ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateMembershipRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateMembershipRequest> InvalidRequestsData = new()
    {
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            Roles = [new string('a', 33)]
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            Roles = new List<string>(new string[101])
        }
    };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateMembershipRequest request)
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
        var request = new UpdateMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            Roles = [new string('a', 33)]
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            Roles = [new string('a', 33)]
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
