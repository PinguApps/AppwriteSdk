using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateDatetimeAttributeRequestTests : CreateAttributeBaseRequestTests<CreateDatetimeAttributeRequest, CreateDatetimeAttributeRequestValidator>
{
    protected override CreateDatetimeAttributeRequest CreateValidCreateAttributeBaseRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateDatetimeAttributeRequest();

        // Assert
        Assert.Null(request.Default);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var defaultValue = DateTime.UtcNow;

        var request = new CreateDatetimeAttributeRequest();

        // Act
        request.Default = defaultValue;

        // Assert
        Assert.Equal(defaultValue, request.Default);
    }

    public static TheoryData<CreateDatetimeAttributeRequest> ValidRequestsData = new()
        {
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = null,
                Required = true
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = DateTime.UtcNow,
                Required = false
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateDatetimeAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateDatetimeAttributeRequest> InvalidRequestsData = new()
        {
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = DateTime.UtcNow,
                Required = true
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateDatetimeAttributeRequest request)
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
        var request = new CreateDatetimeAttributeRequest
        {
            Default = DateTime.UtcNow,
            Required = true
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateDatetimeAttributeRequest
        {
            Default = DateTime.UtcNow,
            Required = true
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
