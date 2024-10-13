using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public abstract class UserIdBaseRequestTests<TRequest, TValidator>
        where TRequest : UserIdBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected abstract TRequest CreateValidRequest { get; }

    [Fact]
    public void UserIdBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidRequest;

        // Assert
        Assert.Equal(string.Empty, request.UserId);
    }

    [Fact]
    public void UserIdBase_Properties_CanBeSet()
    {
        // Arrange
        var userIdValue = "validUserId";
        var request = CreateValidRequest;

        // Act
        request.UserId = userIdValue;

        // Assert
        Assert.Equal(userIdValue, request.UserId);
    }

    [Fact]
    public void UserIdBase_IsValid_WithValidUserId_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = "valid_User-Id.";

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
    public void UserIdBase_IsValid_WithInvalidData_ReturnsFalse(string? userId)
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = userId!;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void UserIdBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = string.Empty; // Invalid UserId

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void UserIdBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = string.Empty; // Invalid UserId

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
