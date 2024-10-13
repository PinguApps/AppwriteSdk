using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class CreateEmailTokenRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateEmailTokenRequest();

        // Assert
        Assert.NotEmpty(request.UserId);
        Assert.Equal(string.Empty, request.Email);
        Assert.False(request.Phrase);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var userId = "123456";
        var email = "test@example.com";
        var phrase = true;

        // Arrange
        var request = new CreateEmailTokenRequest();

        // Act
        request.UserId = userId;
        request.Email = email;
        request.Phrase = phrase;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(email, request.Email);
        Assert.Equal(phrase, request.Phrase);
    }

    [Theory]
    [InlineData("321654987", "pingu@example.com", true)]
    [InlineData("321654987", "pingu@example.com", false)]
    public void IsValid_WithValidData_ReturnsTrue(string userId, string email, bool phrase)
    {
        // Arrange
        var request = new CreateEmailTokenRequest
        {
            UserId = userId,
            Email = email,
            Phrase = phrase
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("badChar^", "pingu@example.com", true)]
    [InlineData(".bad", "pingu@example.com", true)]
    [InlineData("_bad", "pingu@example.com", true)]
    [InlineData("-bad", "pingu@example.com", true)]
    [InlineData("", "pingu@example.com", true)]
    [InlineData("1234567890123456789012345678901234567", "pingu@example.com", true)]
    [InlineData("123456", "not an email", true)]
    [InlineData("123456", "", true)]
    public void IsValid_WithInvalidData_ReturnsFalse(string userId, string email, bool phrase)
    {
        // Arrange
        var request = new CreateEmailTokenRequest
        {
            UserId = userId,
            Email = email,
            Phrase = phrase
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
        var request = new CreateEmailTokenRequest
        {
            UserId = ".badChar^",
            Email = "not an email"
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateEmailTokenRequest
        {
            UserId = ".badChar^",
            Email = "not an email"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
