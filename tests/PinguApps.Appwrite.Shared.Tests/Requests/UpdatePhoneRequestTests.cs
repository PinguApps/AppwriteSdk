using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;

public class UpdatePhoneRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePhoneRequest();

        // Assert
        Assert.NotNull(request.Password);
        Assert.NotNull(request.Phone);
        Assert.Equal(string.Empty, request.Password);
        Assert.Equal(string.Empty, request.Phone);
    }

    [Theory]
    [InlineData("password", "+123456789")]
    [InlineData("drowssap", "+987654321")]
    public void Properties_CanBeSet(string password, string phone)
    {
        // Arrange
        var request = new UpdatePhoneRequest();

        // Act
        request.Password = password;
        request.Phone = phone;

        // Assert
        Assert.Equal(password, request.Password);
        Assert.Equal(phone, request.Phone);
    }

    [Fact]
    public void IsValid_WithValidPhoneAndPassword_ReturnsTrue()
    {
        // Arrange
        var request = new UpdatePhoneRequest
        {
            Phone = "+16175551212",
            Password = "password123"
        };

        // Act
        bool isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("", "password123")] // Empty phone
    [InlineData("+16175551212", "")] // Empty password
    [InlineData("16175551212", "password123")] // Invalid phone
    [InlineData("+16175551212", "pass")] // Short password
    public void IsValid_WithInvalidInputs_ReturnsFalse(string phone, string password)
    {
        // Arrange
        var request = new UpdatePhoneRequest
        {
            Phone = phone,
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
        var request = new UpdatePhoneRequest
        {
            Phone = "invalid",
            Password = "short"
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdatePhoneRequest
        {
            Phone = "invalid",
            Password = "short"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
