using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class AddAuthenticatorRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new AddAuthenticatorRequest();

        // Assert
        Assert.Equal("totp", request.Type);
    }

    [Theory]
    [InlineData("A string")]
    [InlineData("123456")]
    [InlineData("A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. ")]
    public void Properties_CanBeSet(string type)
    {
        // Arrange
        var request = new AddAuthenticatorRequest();

        // Act
        request.Type = type;

        // Assert
        Assert.Equal(type, request.Type);
    }

    [Fact]
    public void IsValid_WithValidInputs_ReturnsTrue()
    {
        // Arrange
        var request = new AddAuthenticatorRequest
        {
            Type = "abcd"
        };

        // Act
        bool isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void IsValid_WithInvalidInputs_ReturnsFalse(string? type)
    {
        // Arrange
        var request = new AddAuthenticatorRequest
        {
            Type = type!
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
        var request = new AddAuthenticatorRequest
        {
            Type = null!
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new AddAuthenticatorRequest
        {
            Type = null!
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
