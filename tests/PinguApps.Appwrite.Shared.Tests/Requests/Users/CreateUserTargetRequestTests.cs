using FluentValidation;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserTargetRequestTests : UserIdBaseRequestTests<CreateUserTargetRequest, CreateUserTargetRequestValidator>
{
    protected override CreateUserTargetRequest CreateValidRequest => new()
    {
        TargetId = IdUtils.GenerateUniqueId(),
        ProviderType = TargetProviderType.Email,
        Identifier = IdUtils.GenerateUniqueId()
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateUserTargetRequest();

        // Assert
        Assert.NotEmpty(request.TargetId);
        Assert.Equal(TargetProviderType.Email, request.ProviderType);
        Assert.Equal(string.Empty, request.Identifier);
        Assert.Null(request.ProviderId);
        Assert.Null(request.Name);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new CreateUserTargetRequest();

        // Act
        request.TargetId = "validTargetId";
        request.ProviderType = TargetProviderType.Sms;
        request.Identifier = "identifier";
        request.ProviderId = "providerId";
        request.Name = "Valid Name";

        // Assert
        Assert.Equal("validTargetId", request.TargetId);
        Assert.Equal(TargetProviderType.Sms, request.ProviderType);
        Assert.Equal("identifier", request.Identifier);
        Assert.Equal("providerId", request.ProviderId);
        Assert.Equal("Valid Name", request.Name);
    }

    public static TheoryData<CreateUserTargetRequest> ValidRequestsData = new()
        {
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = "validTargetId",
                ProviderType = TargetProviderType.Sms,
                Identifier = "identifier",
                ProviderId = "providerId",
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = "validTargetId",
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = null,
                Name = null
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                ProviderType = TargetProviderType.Push,
                Identifier = IdUtils.GenerateUniqueId(),
                ProviderId = null,
                Name = null
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateUserTargetRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateUserTargetRequest> InvalidRequestsData =
        [
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = string.Empty,
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = null!,
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = "Invalid Symbols!!!",
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = ".startsWithValidSymbol",
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = new string('a', 37),
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                ProviderType = (TargetProviderType)999,
                Identifier = "identifier",
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                ProviderType = TargetProviderType.Email,
                Identifier = string.Empty,
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                ProviderType = TargetProviderType.Email,
                Identifier = null!,
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = string.Empty,
                Name = "Valid Name"
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = string.Empty
            },
            new CreateUserTargetRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                TargetId = IdUtils.GenerateUniqueId(),
                ProviderType = TargetProviderType.Email,
                Identifier = "identifier",
                ProviderId = IdUtils.GenerateUniqueId(),
                Name = new string('a', 129)
            }
        ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateUserTargetRequest request)
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
        var request = new CreateUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            TargetId = string.Empty,
            ProviderType = TargetProviderType.Email,
            Identifier = string.Empty,
            ProviderId = string.Empty,
            Name = string.Empty
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            TargetId = string.Empty,
            ProviderType = TargetProviderType.Email,
            Identifier = string.Empty,
            ProviderId = string.Empty,
            Name = string.Empty
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
