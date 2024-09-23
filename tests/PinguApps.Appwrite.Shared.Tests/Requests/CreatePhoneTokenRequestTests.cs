using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class CreatePhoneTokenRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreatePhoneTokenRequest();

        // Assert
        Assert.Equal(string.Empty, request.UserId);
        Assert.Equal(string.Empty, request.PhoneNumber);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var userId = "123456";
        var phoneNumber = "+16175551212";

        // Arrange
        var request = new CreatePhoneTokenRequest();

        // Act
        request.UserId = userId;
        request.PhoneNumber = phoneNumber;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(phoneNumber, request.PhoneNumber);
    }

    [Fact]
    public void IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = new CreatePhoneTokenRequest
        {
            UserId = "validUserId",
            PhoneNumber = "+16175551212"
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("badChar^", "+16175551212")]
    [InlineData(".bad", "+16175551212")]
    [InlineData("_bad", "+16175551212")]
    [InlineData("-bad", "+16175551212")]
    [InlineData("", "+16175551212")]
    [InlineData("1234567890123456789012345678901234567", "+16175551212")]
    [InlineData("validUserId", "")]
    [InlineData("validUserId", "123456")]
    [InlineData("validUserId", "+1234567890123456789012345678901234567")]
    public void IsValid_WithInvalidData_ReturnsFalse(string userId, string phoneNumber)
    {
        // Arrange
        var request = new CreatePhoneTokenRequest
        {
            UserId = userId,
            PhoneNumber = phoneNumber
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
        var request = new CreatePhoneTokenRequest
        {
            UserId = ".badChar^",
            PhoneNumber = "123456"
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreatePhoneTokenRequest
        {
            UserId = ".badChar^",
            PhoneNumber = "123456"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
