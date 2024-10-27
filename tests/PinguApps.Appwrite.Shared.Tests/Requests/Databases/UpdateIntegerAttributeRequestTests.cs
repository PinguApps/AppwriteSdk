using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateIntegerAttributeRequestTests : UpdateAttributeBaseRequestTests<UpdateIntegerAttributeRequest, UpdateIntegerAttributeRequestValidator>
{
    protected override UpdateIntegerAttributeRequest CreateValidUpdateAttributeBaseRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateIntegerAttributeRequest();

        // Assert
        Assert.Null(request.Default);
        Assert.Null(request.Min);
        Assert.Null(request.Max);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var min = 1;
        var defaultValue = 5;
        var max = 10;

        var request = new UpdateIntegerAttributeRequest();

        // Act
        request.Min = min;
        request.Default = defaultValue;
        request.Max = max;

        // Assert
        Assert.Equal(min, request.Min);
        Assert.Equal(defaultValue, request.Default);
        Assert.Equal(max, request.Max);
    }

    public static TheoryData<UpdateIntegerAttributeRequest> ValidRequestsData =>
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
    public void IsValid_WithValidData_ReturnsTrue(UpdateIntegerAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateIntegerAttributeRequest> InvalidRequestsData =>
        [
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = 0,
                Min = null,
                Max = null,
                Required = true
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = 0,
                Min = 1,
                Max = null,
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = 1,
                Min = null,
                Max = 0,
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = null,
                Min = 1,
                Max = 0,
            }
        ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateIntegerAttributeRequest request)
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
        var request = new UpdateIntegerAttributeRequest
        {
            Default = 5,
            Required = true,
            Min = 10,
            Max = 0
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateIntegerAttributeRequest
        {
            Default = 5,
            Required = true,
            Min = 10,
            Max = 0
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
