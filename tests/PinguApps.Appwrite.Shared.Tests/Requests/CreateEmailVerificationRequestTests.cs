using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class CreateEmailVerificationRequestTests
{

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateEmailVerificationRequest();

        // Assert
        Assert.NotNull(request.Url);
        Assert.Equal(string.Empty, request.Url);
    }

    [Theory]
    [InlineData("https://google.com")]
    [InlineData("https://localhost:1234")]
    public void Properties_CanBeSet(string url)
    {
        // Arrange
        var request = new CreateEmailVerificationRequest();

        // Act
        request.Url = url;

        // Assert
        Assert.Equal(url, request.Url);
    }

    [Theory]
    [InlineData("https://google.com")]
    [InlineData("https://localhost:1234")]
    public void IsValid_WithValidData_ReturnsTrue(string url)
    {
        // Arrange
        var request = new CreateEmailVerificationRequest
        {
            Url = url
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("not a url")]
    public void IsValid_WithInvalidData_ReturnsFalse(string url)
    {
        // Arrange
        var request = new CreateEmailVerificationRequest
        {
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
        var request = new CreateEmailVerificationRequest
        {
            Url = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateEmailVerificationRequest
        {
            Url = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
