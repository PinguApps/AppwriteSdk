using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateFloatAttributeRequestTests : UpdateAttributeBaseRequestTests<UpdateFloatAttributeRequest, UpdateFloatAttributeRequestValidator>
{
    protected override UpdateFloatAttributeRequest CreateValidUpdateAttributeBaseRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateFloatAttributeRequest();

        // Assert
        Assert.Null(request.Default);
        Assert.Null(request.Min);
        Assert.Null(request.Max);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var min = 1f;
        var defaultValue = 5f;
        var max = 10f;

        var request = new UpdateFloatAttributeRequest();

        // Act
        request.Min = min;
        request.Default = defaultValue;
        request.Max = max;

        // Assert
        Assert.Equal(min, request.Min);
        Assert.Equal(defaultValue, request.Default);
        Assert.Equal(max, request.Max);
    }

    public static TheoryData<UpdateFloatAttributeRequest> ValidRequestsData =>
        [
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = null,
                Min = null,
                Max = null,
                Required = true
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = 5,
                Min = 0,
                Max = 10,
                Required = false
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = -10,
                Min = null,
                Max = null,
                Required = false
            }
        ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateFloatAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateFloatAttributeRequest> InvalidRequestsData =>
        [
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = 0f,
                Min = null,
                Max = null,
                Required = true
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = 0f,
                Min = 1f,
                Max = null,
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = 1f,
                Min = null,
                Max = 0f,
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = null,
                Min = 1f,
                Max = 0f,
            }
        ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateFloatAttributeRequest request)
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
        var request = new UpdateFloatAttributeRequest
        {
            Default = 5f,
            Required = true,
            Min = 10f,
            Max = 0f
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateFloatAttributeRequest
        {
            Default = 5f,
            Required = true,
            Min = 10f,
            Max = 0f
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
