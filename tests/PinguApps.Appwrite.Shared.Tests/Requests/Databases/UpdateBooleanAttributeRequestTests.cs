using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateBooleanAttributeRequestTests : UpdateAttributeBaseRequestTests<UpdateBooleanAttributeRequest, UpdateBooleanAttributeRequestValidator>
{
    protected override UpdateBooleanAttributeRequest CreateValidUpdateAttributeBaseRequest => new();
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateBooleanAttributeRequest();

        // Assert
        Assert.Null(request.Default);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var defaultValue = true;

        var request = new UpdateBooleanAttributeRequest();

        // Act
        request.Default = defaultValue;

        // Assert
        Assert.Equal(defaultValue, request.Default);
    }

    public static TheoryData<UpdateBooleanAttributeRequest> ValidRequestsData =>
        [
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
                Default = true,
                Required = false
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = false,
                Required = false
            }
        ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateBooleanAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateBooleanAttributeRequest> InvalidRequestsData =>
        [
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = true,
                Required = true
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = false,
                Required = true
            }
        ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateBooleanAttributeRequest request)
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
        var request = new UpdateBooleanAttributeRequest
        {
            Default = true,
            Required = true
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateBooleanAttributeRequest
        {
            Default = true,
            Required = true
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
