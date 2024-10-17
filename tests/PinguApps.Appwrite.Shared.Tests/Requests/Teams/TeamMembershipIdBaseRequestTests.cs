using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Teams;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public abstract class TeamMembershipIdBaseRequestTests<TRequest, TValidator> : TeamIdBaseRequestTests<TRequest, TValidator>
        where TRequest : TeamMembershipIdBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    [Fact]
    public void TeamMembershipIdBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidRequest;

        // Assert
        Assert.Equal(string.Empty, request.MembershipId);
    }

    [Fact]
    public void TeamMembershipIdBase_Properties_CanBeSet()
    {
        // Arrange
        var membershipIdValue = "validId";
        var request = CreateValidRequest;

        // Act
        request.MembershipId = membershipIdValue;

        // Assert
        Assert.Equal(membershipIdValue, request.MembershipId);
    }

    [Fact]
    public void TeamMembershipIdBase_IsValid_WithValidTeamId_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidRequest;
        request.TeamId = "valid_Team-Id.";
        request.MembershipId = "valid_-Id.";

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("invalid chars!")]
    [InlineData(".startsWithSymbol")]
    [InlineData("ThisIdHasTooManyCharactersAsTheLimitIs36")]
    public void TeamMembershipIdBase_IsValid_WithInvalidData_ReturnsFalse(string? membershipId)
    {
        // Arrange
        var request = CreateValidRequest;
        request.MembershipId = membershipId!;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void TeamMembershipIdBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.MembershipId = string.Empty; // Invalid MembershipId

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void TeamMembershipIdBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.MembershipId = string.Empty; // Invalid MembershipId

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
