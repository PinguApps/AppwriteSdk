using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public abstract class UpdateAttributeBaseRequestTests<TRequest, TValidator> : DatabaseCollectionIdAttributeKeyBaseRequestTests<TRequest, TValidator>
        where TRequest : UpdateAttributeBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected override TRequest CreateValidDatabaseCollectionIdAttributeKeyRequest => CreateValidDatabaseCollectionIdAttributeKeyRequest;

    protected abstract TRequest CreateValidUpdateAttributeBaseRequest { get; }

    [Fact]
    public void UpdateAttributeBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidUpdateAttributeBaseRequest;

        // Assert
        Assert.False(request.Required);
        Assert.Null(request.NewKey);
    }

    [Fact]
    public void UpdateAttributeBase_Properties_CanBeSet()
    {
        // Arrange
        var keyValue = "validKey";
        var request = CreateValidUpdateAttributeBaseRequest;

        // Act
        request.Required = true;
        request.NewKey = keyValue;

        // Assert
        Assert.True(request.Required);
        Assert.Equal(keyValue, request.NewKey);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData("validKey", true)]
    public void UpdateAttributeBase_IsValid_WithValidData_ReturnsTrue(string? key, bool required)
    {
        // Arrange
        var request = CreateValidUpdateAttributeBaseRequest;
        request.DatabaseId = "valid_Team-Id.";
        request.CollectionId = "valid_Team-Id.";
        request.Key = "validKey";
        request.Required = required;
        request.NewKey = key;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    public void UpdateAttributeBase_IsValid_WithInvalidData_ReturnsFalse(string? key)
    {
        // Arrange
        var request = CreateValidUpdateAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.NewKey = key;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void UpdateAttributeBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidUpdateAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.NewKey = "";

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void UpdateAttributeBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidUpdateAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.NewKey = "";

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
