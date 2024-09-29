using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class DeleteAuthenticatorRequestTests : UserIdBaseRequestTests<DeleteAuthenticatorRequest, DeleteAuthenticatorRequestValidator>
{
    protected override DeleteAuthenticatorRequest CreateValidRequest => new()
    {
        Type = "totp"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new DeleteAuthenticatorRequest();

        // Assert
        Assert.Equal(string.Empty, request.Type);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var type = "totp";

        var request = new DeleteAuthenticatorRequest();

        // Act
        request.Type = type;

        // Assert
        Assert.Equal(type, request.Type);
    }

    public static TheoryData<DeleteAuthenticatorRequest> ValidRequestsData = new()
        {
            new DeleteAuthenticatorRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Type = "totp"
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(DeleteAuthenticatorRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<DeleteAuthenticatorRequest> InvalidRequestsData = new()
        {
            new DeleteAuthenticatorRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Type = string.Empty
            },
            new DeleteAuthenticatorRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Type = null!
            },
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(DeleteAuthenticatorRequest request)
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
        var request = new DeleteAuthenticatorRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Type = string.Empty
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
            UserId = IdUtils.GenerateUniqueId(),
            Type = string.Empty
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
