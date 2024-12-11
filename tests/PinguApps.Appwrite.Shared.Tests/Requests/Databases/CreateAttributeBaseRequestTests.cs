using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public abstract class CreateAttributeBaseRequestTests<TRequest, TValidator> : DatabaseCollectionIdBaseRequestTests<TRequest, TValidator>
        where TRequest : CreateAttributeBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected sealed override TRequest CreateValidDatabaseCollectionIdRequest
    {
        get
        {
            var request = CreateValidCreateAttributeBaseRequest;
            request.Key = IdUtils.GenerateUniqueId();
            return request;
        }
    }

    protected abstract TRequest CreateValidCreateAttributeBaseRequest { get; }

    [Fact]
    public void CreateAttributeBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidCreateAttributeBaseRequest;

        // Assert
        Assert.Equal(string.Empty, request.Key);
        Assert.False(request.Required);
        Assert.False(request.Array);
    }

    [Fact]
    public void CreateAttributeBase_Properties_CanBeSet()
    {
        // Arrange
        var keyValue = "validKey";
        var request = CreateValidCreateAttributeBaseRequest;

        // Act
        request.Key = keyValue;
        request.Required = true;
        request.Array = true;

        // Assert
        Assert.Equal(keyValue, request.Key);
        Assert.True(request.Required);
        Assert.True(request.Array);
    }

    [Fact]
    public void CreateAttributeBase_IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidCreateAttributeBaseRequest;
        request.DatabaseId = "valid_Team-Id.";
        request.CollectionId = "valid_Team-Id.";
        request.Key = "validKey";

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateAttributeBase_IsValid_WithInvalidData_ReturnsFalse(string? key)
    {
        // Arrange
        var request = CreateValidCreateAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = key!;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void CreateAttributeBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidCreateAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "";

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void CreateAttributeBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidCreateAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "";

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
