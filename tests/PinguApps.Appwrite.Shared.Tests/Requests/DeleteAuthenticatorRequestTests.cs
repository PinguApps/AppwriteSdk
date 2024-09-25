using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class DeleteAuthenticatorRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new DeleteAuthenticatorRequest();

        // Assert
        Assert.Equal("totp", request.Type);
        Assert.Equal(string.Empty, request.Otp);
    }

    [Theory]
    [InlineData("A string", "A string")]
    [InlineData("123456", "123456")]
    [InlineData("A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. ", "A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. ")]
    public void Properties_CanBeSet(string type, string otp)
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest();

        // Act
        request.Type = type;
        request.Otp = otp;

        // Assert
        Assert.Equal(type, request.Type);
    }

    [Fact]
    public void IsValid_WithValidInputs_ReturnsTrue()
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest
        {
            Type = "abcd",
            Otp = "123456"
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("", "123456")]
    [InlineData(null, "123456")]
    [InlineData("abcd", "")]
    [InlineData("abcd", null)]
    public void IsValid_WithInvalidInputs_ReturnsFalse(string? type, string? otp)
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest
        {
            Type = type!,
            Otp = otp!
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
        var request = new DeleteAuthenticatorRequest
        {
            Type = null!,
            Otp = null!
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest
        {
            Type = null!,
            Otp = null!
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
