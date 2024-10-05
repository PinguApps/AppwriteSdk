using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdatePasswordRequestTests : UserIdBaseRequestTests<UpdatePasswordRequest, UpdatePasswordRequestValidator>
{
    protected override UpdatePasswordRequest CreateValidRequest => new()
    {
        Password = "MyPassword"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePasswordRequest();

        // Assert
        Assert.Equal(string.Empty, request.Password);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var password = "NewPassword123";

        // Arrange
        var request = new UpdatePasswordRequest();

        // Act
        request.Password = password;

        // Assert
        Assert.Equal(password, request.Password);
    }

    public static TheoryData<UpdatePasswordRequest> ValidRequestsData = new()
        {
            new UpdatePasswordRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Password = "ValidPassword123"
            },
            new UpdatePasswordRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Password = "AnotherValidPassword456"
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdatePasswordRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdatePasswordRequest> InvalidRequestsData = new()
        {
            new UpdatePasswordRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Password = string.Empty
            },
            new UpdatePasswordRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Password = null!
            },
            new UpdatePasswordRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Password = "short"
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdatePasswordRequest request)
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
        var request = new UpdatePasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Password = string.Empty
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdatePasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Password = string.Empty
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
