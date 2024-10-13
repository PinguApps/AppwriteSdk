using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class UpdatePushTargetRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePushTargetRequest();

        // Assert
        Assert.Equal(string.Empty, request.TargetId);
        Assert.Equal(string.Empty, request.Identifier);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var targetId = IdUtils.GenerateUniqueId();
        var identifier = "email";

        // Arrange
        var request = new UpdatePushTargetRequest();

        // Act
        request.TargetId = targetId;
        request.Identifier = identifier;

        // Assert
        Assert.Equal(targetId, request.TargetId);
        Assert.Equal(identifier, request.Identifier);
    }

    public static TheoryData<UpdatePushTargetRequest> ValidRequestsData = new()
    {
        new UpdatePushTargetRequest
        {
            TargetId = IdUtils.GenerateUniqueId(),
            Identifier = "token"
        },
        new UpdatePushTargetRequest
        {
            TargetId = IdUtils.GenerateUniqueId(),
            Identifier = "email"
        },
        new UpdatePushTargetRequest
        {
            TargetId = IdUtils.GenerateUniqueId(),
            Identifier = "phone"
        }
    };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdatePushTargetRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdatePushTargetRequest> InvalidRequestsData = new()
    {
        new UpdatePushTargetRequest
        {
            TargetId = "",
            Identifier = "token"
        },
        new UpdatePushTargetRequest
        {
            TargetId = null!,
            Identifier = "token"
        },
        new UpdatePushTargetRequest
        {
            TargetId = IdUtils.GenerateUniqueId(),
            Identifier = ""
        },
        new UpdatePushTargetRequest
        {
            TargetId = IdUtils.GenerateUniqueId(),
            Identifier = null!
        }
    };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdatePushTargetRequest request)
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
        var request = new UpdatePushTargetRequest
        {
            TargetId = "",
            Identifier = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdatePushTargetRequest
        {
            TargetId = "",
            Identifier = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
