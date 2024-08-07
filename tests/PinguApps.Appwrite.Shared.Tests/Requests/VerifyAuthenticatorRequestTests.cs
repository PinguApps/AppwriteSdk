using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class VerifyAuthenticatorRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new VerifyAuthenticatorRequest();

        // Assert
        Assert.Equal(string.Empty, request.Otp);
    }

    [Theory]
    [InlineData("A string")]
    [InlineData("123456")]
    [InlineData("A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. ")]
    public void Properties_CanBeSet(string otp)
    {
        // Arrange
        var request = new VerifyAuthenticatorRequest();

        // Act
        request.Otp = otp;

        // Assert
        Assert.Equal(otp, request.Otp);
    }

    [Fact]
    public void IsValid_WithValidInputs_ReturnsTrue()
    {
        // Arrange
        var request = new VerifyAuthenticatorRequest
        {
            Otp = "123456"
        };

        // Act
        bool isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void IsValid_WithInvalidInputs_ReturnsFalse(string? otp)
    {
        // Arrange
        var request = new VerifyAuthenticatorRequest
        {
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
        var request = new VerifyAuthenticatorRequest
        {
            Otp = null!
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new VerifyAuthenticatorRequest
        {
            Otp = null!
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
