using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdateUserTargertRequestTests : UserIdBaseRequestTests<UpdateUserTargertRequest, UpdateUserTargertRequestValidator>
{
    protected override UpdateUserTargertRequest CreateValidRequest => new()
    {
        TargetId = IdUtils.GenerateUniqueId()
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateUserTargertRequest();

        // Assert
        Assert.Equal(string.Empty, request.TargetId);
        Assert.Null(request.Identifier);
        Assert.Null(request.ProviderId);
        Assert.Null(request.Name);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new UpdateUserTargertRequest();

        // Act
        request.TargetId = "validTargetId";
        request.Identifier = "validIdentifier";
        request.ProviderId = "validProviderId";
        request.Name = "Valid Name";

        // Assert
        Assert.Equal("validTargetId", request.TargetId);
        Assert.Equal("validIdentifier", request.Identifier);
        Assert.Equal("validProviderId", request.ProviderId);
        Assert.Equal("Valid Name", request.Name);
    }

    public static TheoryData<UpdateUserTargertRequest> ValidRequestsData = new()
        {
            new UpdateUserTargertRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                Identifier = "validIdentifier",
                ProviderId = "validProviderId",
                Name = "Valid Name"
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateUserTargertRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateUserTargertRequest> InvalidRequestsData = new()
        {
            new UpdateUserTargertRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = null!
            },
            new UpdateUserTargertRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = string.Empty
            },
            new UpdateUserTargertRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                Identifier = string.Empty
            },
            new UpdateUserTargertRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                ProviderId = string.Empty
            },
            new UpdateUserTargertRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                Name = string.Empty
            },
            new UpdateUserTargertRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                Name = new string('a', 129)
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateUserTargertRequest request)
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
        var request = new UpdateUserTargertRequest
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
        var request = new UpdateUserTargertRequest
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
