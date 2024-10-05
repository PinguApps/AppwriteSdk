using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class UpdateEmailRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateEmailRequest();

        // Assert
        Assert.NotNull(request.Email);
        Assert.NotNull(request.Password);
        Assert.Equal(string.Empty, request.Email);
        Assert.Equal(string.Empty, request.Password);
    }

    [Theory]
    [InlineData("test@example.com", "password123")]
    [InlineData("another@example.com", "diffPassword")]
    public void Properties_CanBeSet(string email, string password)
    {
        // Arrange
        var request = new UpdateEmailRequest();

        // Act
        request.Email = email;
        request.Password = password;

        // Assert
        Assert.Equal(email, request.Email);
        Assert.Equal(password, request.Password);
    }

    [Theory]
    [InlineData("pingu@example.com", "Password")]
    [InlineData("something@anotherthing.somethingelse", "£$%^&*()")]
    public void IsValid_WithValidData_ReturnsTrue(string email, string password)
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            Email = email,
            Password = password
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("not an email", "Password")]
    [InlineData("", "Password")]
    [InlineData("pingu@example.com", "short")]
    [InlineData("pingu@example.com", "")]
    public void IsValid_WithInvalidData_ReturnsFalse(string email, string password)
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            Email = email,
            Password = password
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
        var request = new UpdateEmailRequest
        {
            Email = "not an email",
            Password = "short"
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            Email = "not an email",
            Password = "short"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
