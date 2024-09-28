using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public abstract class UserIdBaseRequestTests<TRequest, TValidator> : IClassFixture<TRequest>
        where TRequest : UserIdBaseRequest<TRequest, TValidator>, new()
        where TValidator : AbstractValidator<TRequest>, new()
{
    [Fact]
    public void UserIdBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new TRequest();

        // Assert
        Assert.Equal(string.Empty, request.UserId);
    }

    [Fact]
    public void UserIdBase_Properties_CanBeSet()
    {
        // Arrange
        var userIdValue = "validUserId";
        var request = new TRequest();

        // Act
        request.UserId = userIdValue;

        // Assert
        Assert.Equal(userIdValue, request.UserId);
    }

    [Fact]
    public void UserIdBase_IsValid_WithValidUserId_ReturnsTrue()
    {
        // Arrange
        var request = new TRequest
        {
            UserId = "valid_User-Id."
        };

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
        var request = new TRequest
        {
            UserId = userId!
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void UserIdBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new TRequest
        {
            UserId = string.Empty // Invalid UserId
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void UserIdBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new TRequest
        {
            UserId = string.Empty // Invalid UserId
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
