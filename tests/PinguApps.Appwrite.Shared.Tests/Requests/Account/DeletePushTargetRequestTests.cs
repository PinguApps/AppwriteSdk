using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class DeletePushTargetRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new DeletePushTargetRequest();

        // Assert
        Assert.Equal(string.Empty, request.TargetId);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var targetId = IdUtils.GenerateUniqueId();

        // Arrange
        var request = new DeletePushTargetRequest();

        // Act
        request.TargetId = targetId;

        // Assert
        Assert.Equal(targetId, request.TargetId);
    }

    public static TheoryData<DeletePushTargetRequest> ValidRequestsData =
    [
        new DeletePushTargetRequest
        {
            TargetId = IdUtils.GenerateUniqueId()
        }
    ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(DeletePushTargetRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<DeletePushTargetRequest> InvalidRequestsData =
    [
        new DeletePushTargetRequest
        {
            TargetId = ""
        },
        new DeletePushTargetRequest
        {
            TargetId = null!
        }
    ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(DeletePushTargetRequest request)
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
        var request = new DeletePushTargetRequest
        {
            TargetId = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new DeletePushTargetRequest
        {
            TargetId = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
