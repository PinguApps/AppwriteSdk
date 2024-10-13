using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class CreatePushTargetRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreatePushTargetRequest();

        // Assert
        Assert.NotEmpty(request.TargetId);
        Assert.Equal(string.Empty, request.Identifier);
        Assert.Null(request.ProviderId);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var targetId = IdUtils.GenerateUniqueId();
        var identifier = "email";
        var providerId = "provider123";

        // Arrange
        var request = new CreatePushTargetRequest();

        // Act
        request.TargetId = targetId;
        request.Identifier = identifier;
        request.ProviderId = providerId;

        // Assert
        Assert.Equal(targetId, request.TargetId);
        Assert.Equal(identifier, request.Identifier);
        Assert.Equal(providerId, request.ProviderId);
    }

    public static TheoryData<CreatePushTargetRequest> ValidRequestsData = new()
        {
            new CreatePushTargetRequest
            {
                TargetId = IdUtils.GenerateUniqueId(),
                Identifier = "token",
                ProviderId = "provider123"
            },
            new CreatePushTargetRequest
            {
                TargetId = IdUtils.GenerateUniqueId(),
                Identifier = "email",
                ProviderId = "provider456"
            },
            new CreatePushTargetRequest
            {
                TargetId = IdUtils.GenerateUniqueId(),
                Identifier = "phone",
                ProviderId = "provider789"
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreatePushTargetRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreatePushTargetRequest> InvalidRequestsData = new()
        {
            new CreatePushTargetRequest
            {
                TargetId = ".badChar",
                Identifier = "token",
                ProviderId = "provider123"
            },
            new CreatePushTargetRequest
            {
                TargetId = "",
                Identifier = "token",
                ProviderId = "provider123"
            },
            new CreatePushTargetRequest
            {
                TargetId = null!,
                Identifier = "token",
                ProviderId = "provider123"
            },
            new CreatePushTargetRequest
            {
                TargetId = "badChar^!",
                Identifier = "token",
                ProviderId = "provider123"
            },
            new CreatePushTargetRequest
            {
                TargetId = new string('a', 37),
                Identifier = "token",
                ProviderId = "provider123"
            },
            new CreatePushTargetRequest
            {
                TargetId = IdUtils.GenerateUniqueId(),
                Identifier = "",
                ProviderId = "provider123"
            },
            new CreatePushTargetRequest
            {
                TargetId = IdUtils.GenerateUniqueId(),
                Identifier = null!,
                ProviderId = "provider123"
            },
            new CreatePushTargetRequest
            {
                TargetId = "validTargetId",
                Identifier = "token",
                ProviderId = string.Empty
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreatePushTargetRequest request)
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
        var request = new CreatePushTargetRequest
        {
            TargetId = ".badChar^",
            Identifier = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreatePushTargetRequest
        {
            TargetId = ".badChar^",
            Identifier = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
