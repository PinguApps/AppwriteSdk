using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdateNameRequestTests : UserIdBaseRequestTests<UpdateNameRequest, UpdateNameRequestValidator>
{
    protected override UpdateNameRequest CreateValidRequest => new()
    {
        Name = "pingu"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateNameRequest();

        // Assert
        Assert.Equal(string.Empty, request.Name);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var name = "New Name";

        // Arrange
        var request = new UpdateNameRequest();

        // Act
        request.Name = name;

        // Assert
        Assert.Equal(name, request.Name);
    }

    public static TheoryData<UpdateNameRequest> ValidRequestsData = new()
        {
            new UpdateNameRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new UpdateNameRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Name = new string('a', 128)
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateNameRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateNameRequest> InvalidRequestsData = new()
        {
            new UpdateNameRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Name = string.Empty
            },
            new UpdateNameRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Name = null!
            },
            new UpdateNameRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Name = new string('a', 129)
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateNameRequest request)
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
        var request = new UpdateNameRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Name = string.Empty
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateNameRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Name = string.Empty
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
