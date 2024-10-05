using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class CreatePasswordRecoveryConfirmationRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreatePasswordRecoveryConfirmationRequest();

        // Assert
        Assert.Equal(string.Empty, request.UserId);
        Assert.Equal(string.Empty, request.Secret);
        Assert.Equal(string.Empty, request.Password);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var userId = "userId";
        var secret = "secret";
        var password = "password";

        // Arrange
        var request = new CreatePasswordRecoveryConfirmationRequest();

        // Act
        request.UserId = userId;
        request.Secret = secret;
        request.Password = password;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(secret, request.Secret);
        Assert.Equal(password, request.Password);
    }

    [Fact]
    public void IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = new CreatePasswordRecoveryConfirmationRequest
        {
            UserId = "userId",
            Secret = "secret",
            Password = "password"
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null, "secret", "password")]
    [InlineData("", "secret", "password")]
    [InlineData("userId", null, "password")]
    [InlineData("userId", "", "password")]
    [InlineData("userId", "secret", null)]
    [InlineData("userId", "secret", "")]
    [InlineData("userId", "secret", "short")]
    [InlineData("userId", "secret", "A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. \", \"A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. ")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? userId, string? secret, string? password)
    {
        // Arrange
        var request = new CreatePasswordRecoveryConfirmationRequest
        {
            UserId = userId!,
            Secret = secret!,
            Password = password!
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new CreatePasswordRecoveryConfirmationRequest
        {
            UserId = "",
            Secret = "",
            Password = "short"
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreatePasswordRecoveryConfirmationRequest
        {
            UserId = "",
            Secret = "",
            Password = "short"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
