using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class CreateAccountRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateAccountRequest();

        // Assert
        Assert.NotNull(request.UserId);
        Assert.NotEmpty(request.UserId);
        Assert.Equal(string.Empty, request.Email);
        Assert.Equal(string.Empty, request.Password);
        Assert.Null(request.Name);
    }

    [Theory]
    [InlineData("test@example.com", "password123", "Test User")]
    [InlineData("another@example.com", "diffPassword", null)]
    public void Properties_CanBeSet(string email, string password, string? name)
    {
        // Arrange
        var request = new CreateAccountRequest();

        // Act
        request.Email = email;
        request.Password = password;
        request.Name = name;

        // Assert
        Assert.Equal(email, request.Email);
        Assert.Equal(password, request.Password);
        Assert.Equal(name, request.Name);
    }

    [Theory]
    [InlineData(null, "pingu@example.com", "Password", null)]
    [InlineData("321654987", "pingu@example.com", "12345678", "Pingu")]
    [InlineData("a.s-d_f", "pingu@example.com", "12345678", "Pingu")]
    public void IsValid_WithValidData_ReturnsTrue(string? userId, string email, string password, string? name)
    {
        // Arrange
        var request = new CreateAccountRequest
        {
            Email = email,
            Password = password,
            Name = name
        };

        if (userId is not null)
        {
            request.UserId = userId;
        }

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("badChar^", "pingu@example.com", "Password", "Pingu")]
    [InlineData(".bad", "pingu@example.com", "Password", "Pingu")]
    [InlineData("_bad", "pingu@example.com", "Password", "Pingu")]
    [InlineData("-bad", "pingu@example.com", "Password", "Pingu")]
    [InlineData("", "pingu@example.com", "Password", "Pingu")]
    [InlineData("1234567890123456789012345678901234567", "pingu@example.com", "Password", "Pingu")]
    [InlineData(null, "not an email", "Password", "Pingu")]
    [InlineData(null, "", "Password", "Pingu")]
    [InlineData(null, "pingu@example.com", "short", "Pingu")]
    [InlineData(null, "pingu@example.com", "", "Pingu")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? userId, string email, string password, string? name)
    {
        // Arrange
        var request = new CreateAccountRequest
        {
            Email = email,
            Password = password,
            Name = name
        };

        if (userId is not null)
        {
            request.UserId = userId;
        }

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new CreateAccountRequest
        {
            UserId = ".badChar^",
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
        var request = new CreateAccountRequest
        {
            UserId = ".badChar^",
            Email = "not an email",
            Password = "short"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
