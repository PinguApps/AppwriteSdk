using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class CreateMagicUrlTokenRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateMagicUrlTokenRequest();

        // Assert
        Assert.Equal(string.Empty, request.UserId);
        Assert.Equal(string.Empty, request.Email);
        Assert.Null(request.Url);
        Assert.False(request.Phrase);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var userId = "newId";
        var email = "me@example.com";
        var url = "https://example.com/magic-url";
        var phrase = true;

        var request = new CreateMagicUrlTokenRequest();

        // Act
        request.UserId = userId;
        request.Email = email;
        request.Url = url;
        request.Phrase = phrase;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(email, request.Email);
        Assert.Equal(url, request.Url);
        Assert.Equal(phrase, request.Phrase);
    }

    [Theory]
    [InlineData("new.Id-123_456", "me@email.com", "https://google.com")]
    [InlineData("new.Id-123_456", "me@email.co.uk", "https://google.com/")]
    [InlineData("new.Id-123_456", "me@email.co.uk", "https://google.com/some/path/segments")]
    [InlineData("new.Id-123_456", "me@email.co.uk", null)]
    public void IsValid_WithValidData_ReturnsTrue(string userId, string email, string? url)
    {
        // Arrange
        var request = new CreateMagicUrlTokenRequest
        {
            UserId = userId,
            Email = email,
            Url = url
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null, "me@email.com", "https://google.com")]
    [InlineData("", "me@email.com", "https://google.com")]
    [InlineData("-startsWithSpecial", "me@email.com", "https://google.com")]
    [InlineData("has illegal chars!", "me@email.com", "https://google.com")]
    [InlineData("thisIdIsFarTooLongAsItShouldOnlyBeMaximum36Characters", "me@email.com", "https://google.com")]
    [InlineData("new.Id-123_456", null, "https://google.com")]
    [InlineData("new.Id-123_456", "", "https://google.com")]
    [InlineData("new.Id-123_456", "not an email", "https://google.com")]
    [InlineData("new.Id-123_456", "me@email.com", "not a URL")]
    [InlineData("new.Id-123_456", "me@email.com", "")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? userId, string? email, string? url)
    {
        // Arrange
        var request = new CreateMagicUrlTokenRequest
        {
            UserId = userId!,
            Email = email!,
            Url = url
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
        var request = new CreateMagicUrlTokenRequest()
        {
            UserId = "",
            Email = "not an email"
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateMagicUrlTokenRequest()
        {
            UserId = "",
            Email = "not an email"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
