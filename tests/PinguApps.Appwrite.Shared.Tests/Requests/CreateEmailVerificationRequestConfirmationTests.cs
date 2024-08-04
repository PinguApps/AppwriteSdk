using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class CreateEmailVerificationRequestConfirmationTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateEmailVerificationConfirmationRequest();

        // Assert
        Assert.Equal(string.Empty, request.UserId);
        Assert.Equal(string.Empty, request.Secret);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var userId = "123456";
        var secret = "test@example.com";

        // Arrange
        var request = new CreateEmailVerificationConfirmationRequest();

        // Act
        request.UserId = userId;
        request.Secret = secret;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(secret, request.Secret);
    }

    [Fact]
    public void IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = new CreateEmailVerificationConfirmationRequest
        {
            UserId = "123456",
            Secret = "654321"
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("badChar^", "654321")]
    [InlineData(".bad", "654321")]
    [InlineData("_bad", "654321")]
    [InlineData("-bad", "654321")]
    [InlineData("", "654321")]
    [InlineData("1234567890123456789012345678901234567", "654321")]
    [InlineData("123456", "")]
    public void IsValid_WithInvalidData_ReturnsFalse(string userId, string secret)
    {
        // Arrange
        var request = new CreateEmailVerificationConfirmationRequest
        {
            UserId = userId,
            Secret = secret
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
        var request = new CreateEmailVerificationConfirmationRequest
        {
            UserId = ".badChar^",
            Secret = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateEmailVerificationConfirmationRequest
        {
            UserId = ".badChar^",
            Secret = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
