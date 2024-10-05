using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserJwtRequestTests : UserIdBaseRequestTests<CreateUserJwtRequest, CreateUserJwtRequestValidator>
{
    protected override CreateUserJwtRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateUserJwtRequest();

        // Assert
        Assert.Null(request.SessionId);
        Assert.Null(request.Duration);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var sessionId = "recent";
        var duration = 1200;

        // Arrange
        var request = new CreateUserJwtRequest();

        // Act
        request.SessionId = sessionId;
        request.Duration = duration;

        // Assert
        Assert.Equal(sessionId, request.SessionId);
        Assert.Equal(duration, request.Duration);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("recent", 1200)]
    [InlineData("validSessionId", 3600)]
    public void IsValid_WithValidData_ReturnsTrue(string? sessionId, int? duration)
    {
        // Arrange
        var request = new CreateUserJwtRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            SessionId = sessionId,
            Duration = duration
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("", 1200)] // Invalid SessionId
    [InlineData("recent", -1)] // Invalid Duration
    [InlineData("recent", 3601)] // Invalid Duration
    public void IsValid_WithInvalidData_ReturnsFalse(string? sessionId, int? duration)
    {
        // Arrange
        var request = new CreateUserJwtRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            SessionId = sessionId,
            Duration = duration
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
        var request = new CreateUserJwtRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            SessionId = "",
            Duration = -1
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateUserJwtRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            SessionId = "",
            Duration = -1
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
