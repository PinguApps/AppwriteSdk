using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public abstract class DatabaseIdBaseRequestTests<TRequest, TValidator>
        where TRequest : DatabaseIdBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected abstract TRequest CreateValidRequest { get; }

    [Fact]
    public void TeamIdBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidRequest;

        // Assert
        Assert.Equal(string.Empty, request.DatabaseId);
    }

    [Fact]
    public void TeamIdBase_Properties_CanBeSet()
    {
        // Arrange
        var teamIdValue = "validId";
        var request = CreateValidRequest;

        // Act
        request.DatabaseId = teamIdValue;

        // Assert
        Assert.Equal(teamIdValue, request.DatabaseId);
    }

    [Fact]
    public void TeamIdBase_IsValid_WithValidTeamId_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidRequest;
        request.DatabaseId = "valid_Team-Id.";

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void TeamIdBase_IsValid_WithInvalidData_ReturnsFalse(string? id)
    {
        // Arrange
        var request = CreateValidRequest;
        request.DatabaseId = id!;

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
        request.DatabaseId = string.Empty; // Invalid Id

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void TeamIdBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.DatabaseId = string.Empty; // Invalid Id

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
