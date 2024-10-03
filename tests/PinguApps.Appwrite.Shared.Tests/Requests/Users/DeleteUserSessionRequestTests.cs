using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class DeleteUserSessionRequestTests : UserIdBaseRequestTests<DeleteUserSessionRequest, DeleteUserSessionRequestValidator>
{
    protected override DeleteUserSessionRequest CreateValidRequest => new()
    {
        SessionId = IdUtils.GenerateUniqueId()
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new DeleteUserSessionRequest();

        // Assert
        Assert.Equal(string.Empty, request.SessionId);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var sessionId = IdUtils.GenerateUniqueId();

        // Arrange
        var request = new DeleteUserSessionRequest();

        // Act
        request.SessionId = sessionId;

        // Assert
        Assert.Equal(sessionId, request.SessionId);
    }

    public static TheoryData<DeleteUserSessionRequest> ValidRequestsData =
        [
            new DeleteUserSessionRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                SessionId = IdUtils.GenerateUniqueId()
            }
        ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(DeleteUserSessionRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<DeleteUserSessionRequest> InvalidRequestsData =
        [
            new DeleteUserSessionRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                SessionId = string.Empty
            },
            new DeleteUserSessionRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                SessionId = null!
            },
        ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(DeleteUserSessionRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new DeleteUserSessionRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            SessionId = string.Empty
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new DeleteUserSessionRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            SessionId = string.Empty
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
