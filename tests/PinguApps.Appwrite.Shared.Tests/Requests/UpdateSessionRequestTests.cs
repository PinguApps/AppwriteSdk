using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class UpdateSessionRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatetSessionRequest();

        // Assert
        Assert.Equal("current", request.SessionId);
    }

    [Theory]
    [InlineData("A string")]
    public void Properties_CanBeSet(string sessionId)
    {
        // Arrange
        var request = new UpdatetSessionRequest();

        // Act
        request.SessionId = sessionId;

        // Assert
        Assert.Equal(sessionId, request.SessionId);
    }

    [Fact]
    public void IsValid_WithValidInputs_ReturnsTrue()
    {
        // Arrange
        var request = new UpdatetSessionRequest
        {
            SessionId = "blahblah"
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void IsValid_WithInvalidInputs_ReturnsFalse(string? sessionId)
    {
        // Arrange
        var request = new UpdatetSessionRequest
        {
            SessionId = sessionId!
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
        var request = new UpdatetSessionRequest
        {
            SessionId = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdatetSessionRequest
        {
            SessionId = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
