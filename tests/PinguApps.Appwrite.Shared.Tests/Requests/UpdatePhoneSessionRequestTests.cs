using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class UpdatePhoneSessionRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePhoneSessionRequest();

        // Assert
        Assert.NotNull(request.UserId);
        Assert.NotNull(request.Secret);
        Assert.Equal(string.Empty, request.UserId);
        Assert.Equal(string.Empty, request.Secret);
    }

    [Theory]
    [InlineData("user123", "validSecret")]
    [InlineData("anotherUser", "anotherSecret")]
    public void Properties_CanBeSet(string userId, string secret)
    {
        // Arrange
        var request = new UpdatePhoneSessionRequest();

        // Act
        request.UserId = userId;
        request.Secret = secret;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(secret, request.Secret);
    }

    [Theory]
    [InlineData("validUserId", "validSecret")]
    [InlineData("anotherValidUserId", "anotherValidSecret")]
    public void IsValid_WithValidData_ReturnsTrue(string userId, string secret)
    {
        // Arrange
        var request = new UpdatePhoneSessionRequest
        {
            UserId = userId,
            Secret = secret
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("", "validSecret")]
    [InlineData(null, "validSecret")]
    [InlineData(".startsWithSymbol", "validSecret")]
    [InlineData("contains invalid chars!", "validSecret")]
    [InlineData("ThisUserIdContainsFarTooManyCharacters", "validSecret")]
    [InlineData("validUserId", "")]
    [InlineData("validUserId", null)]
    public void IsValid_WithInvalidData_ReturnsFalse(string? userId, string? secret)
    {
        // Arrange
        var request = new UpdatePhoneSessionRequest
        {
            UserId = userId!,
            Secret = secret!
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
        var request = new UpdatePhoneSessionRequest
        {
            UserId = "",
            Secret = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdatePhoneSessionRequest
        {
            UserId = "",
            Secret = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
