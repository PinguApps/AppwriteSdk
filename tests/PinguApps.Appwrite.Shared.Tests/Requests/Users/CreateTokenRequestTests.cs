using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateTokenRequestTests : UserIdBaseRequestTests<CreateTokenRequest, CreateTokenRequestValidator>
{
    protected override CreateTokenRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateTokenRequest();

        // Assert
        Assert.Null(request.Length);
        Assert.Null(request.Expire);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new CreateTokenRequest();

        // Act
        request.Length = 8;
        request.Expire = 1800; // 30 minutes

        // Assert
        Assert.Equal(8, request.Length);
        Assert.Equal(1800, request.Expire);
    }

    public static TheoryData<CreateTokenRequest> ValidRequestsData = new()
        {
            new CreateTokenRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Length = 6,
                Expire = 900 // 15 minutes
            },
            new CreateTokenRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Length = 100,
                Expire = 86400 // 24 hours
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateTokenRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateTokenRequest> InvalidRequestsData = new()
        {
            new CreateTokenRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Length = -1
            },
            new CreateTokenRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Expire = -1
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateTokenRequest request)
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
        var request = new CreateTokenRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Length = -1,
            Expire = -1
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateTokenRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Length = -1,
            Expire = -1
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
