using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Teams;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public abstract class TeamIdBaseRequestTests<TRequest, TValidator>
        where TRequest : TeamIdBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected abstract TRequest CreateValidRequest { get; }

    [Fact]
    public void TeamIdBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidRequest;

        // Assert
        Assert.Equal(string.Empty, request.TeamId);
    }

    [Fact]
    public void TeamIdBase_Properties_CanBeSet()
    {
        // Arrange
        var TeamIdValue = "validTeamId";
        var request = CreateValidRequest;

        // Act
        request.TeamId = TeamIdValue;

        // Assert
        Assert.Equal(TeamIdValue, request.TeamId);
    }

    [Fact]
    public void TeamIdBase_IsValid_WithValidTeamId_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidRequest;
        request.TeamId = "valid_Team-Id.";

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
    public void TeamIdBase_IsValid_WithInvalidData_ReturnsFalse(string? TeamId)
    {
        // Arrange
        var request = CreateValidRequest;
        request.TeamId = TeamId!;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void TeamIdBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.TeamId = string.Empty; // Invalid TeamId

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void TeamIdBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.TeamId = string.Empty; // Invalid TeamId

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
