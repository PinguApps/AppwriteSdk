using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdatePhoneRequestTests : UserIdBaseRequestTests<UpdatePhoneRequest, UpdatePhoneRequestValidator>
{
    protected override UpdatePhoneRequest CreateValidRequest => new()
    {
        PhoneNumber = "+16175551212"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePhoneRequest();

        // Assert
        Assert.Equal(string.Empty, request.PhoneNumber);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var phoneNumber = "+16175551212";

        // Arrange
        var request = new UpdatePhoneRequest();

        // Act
        request.PhoneNumber = phoneNumber;

        // Assert
        Assert.Equal(phoneNumber, request.PhoneNumber);
    }

    public static TheoryData<UpdatePhoneRequest> ValidRequestsData = new()
        {
            new UpdatePhoneRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneNumber = "+16175551212"
            },
            new UpdatePhoneRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneNumber = "+441632960961"
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdatePhoneRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdatePhoneRequest> InvalidRequestsData = new()
        {
            new UpdatePhoneRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneNumber = string.Empty
            },
            new UpdatePhoneRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneNumber = null!
            },
            new UpdatePhoneRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneNumber = "6175551212"
            },
            new UpdatePhoneRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneNumber = "+161755512121234567"
            },
            new UpdatePhoneRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneNumber = "+text"
            },
            new UpdatePhoneRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneNumber = "+123456.9"
            },
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdatePhoneRequest request)
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
        var request = new UpdatePhoneRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            PhoneNumber = string.Empty
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
            UserId = IdUtils.GenerateUniqueId(),
            PhoneNumber = string.Empty
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
