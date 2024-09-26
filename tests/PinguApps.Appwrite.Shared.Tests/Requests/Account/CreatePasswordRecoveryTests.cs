using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class CreatePasswordRecoveryTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreatePasswordRecoveryRequest();

        // Assert
        Assert.Equal(string.Empty, request.Email);
        Assert.Equal(string.Empty, request.Url);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var url = "https://localhost:1234/abc";
        var email = "test@example.com";

        // Arrange
        var request = new CreatePasswordRecoveryRequest();

        // Act
        request.Url = url;
        request.Email = email;

        // Assert
        Assert.Equal(url, request.Url);
        Assert.Equal(email, request.Email);
    }

    [Fact]
    public void IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = new CreatePasswordRecoveryRequest
        {
            Email = "test@example.com",
            Url = "https://localhost:1234/abc"
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null, "https://localhost:1234/abc")]
    [InlineData("", "https://localhost:1234/abc")]
    [InlineData("Not an email", "https://localhost:1234/abc")]
    [InlineData("pingu@example.com", null)]
    [InlineData("pingu@example.com", "")]
    [InlineData("pingu@example.com", "Not a URL")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? email, string? url)
    {
        // Arrange
        var request = new CreatePasswordRecoveryRequest
        {
            Email = email!,
            Url = url!
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
        var request = new CreatePasswordRecoveryRequest
        {
            Email = "",
            Url = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreatePasswordRecoveryRequest
        {
            Email = "",
            Url = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
