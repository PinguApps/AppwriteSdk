using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class GetUserTargetRequestTests : UserIdBaseRequestTests<GetUserTargetRequest, GetUserTargetRequestValidator>
{
    protected override GetUserTargetRequest CreateValidRequest => new()
    {
        TargetId = IdUtils.GenerateUniqueId()
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new GetUserTargetRequest();

        // Assert
        Assert.Equal(string.Empty, request.TargetId);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new GetUserTargetRequest();

        // Act
        request.TargetId = "validTargetId";

        // Assert
        Assert.Equal("validTargetId", request.TargetId);
    }

    public static TheoryData<GetUserTargetRequest> ValidRequestsData = new()
        {
            new GetUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId()
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(GetUserTargetRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<GetUserTargetRequest> InvalidRequestsData = new()
        {
            new GetUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = null!
            },
            new GetUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = string.Empty
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(GetUserTargetRequest request)
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
        var request = new GetUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            TargetId = string.Empty
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new GetUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            TargetId = string.Empty
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
