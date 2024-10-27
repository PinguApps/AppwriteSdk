using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public abstract class CreateStringAttributeBaseRequestTests<TRequest, TValidator> : CreateAttributeBaseRequestTests<TRequest, TValidator>
        where TRequest : CreateStringAttributeBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected sealed override TRequest CreateValidCreateAttributeBaseRequest => CreateValidCreateStringAttributeBaseRequest;

    protected abstract TRequest CreateValidCreateStringAttributeBaseRequest { get; }

    [Fact]
    public void CreateStringAttributeBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidCreateStringAttributeBaseRequest;

        // Assert
        Assert.Null(request.Default);
    }

    [Fact]
    public void CreateStringAttributeBase_Properties_CanBeSet()
    {
        // Arrange
        var defaultValue = "validKey";
        var request = CreateValidCreateStringAttributeBaseRequest;

        // Act
        request.Default = defaultValue;

        // Assert
        Assert.Equal(defaultValue, request.Default);
    }

    [Fact]
    public void CreateStringAttributeBase_IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidCreateStringAttributeBaseRequest;
        request.DatabaseId = "valid_Team-Id.";
        request.CollectionId = "valid_Team-Id.";
        request.Key = "validKey";
        request.Default = null;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void CreateStringAttributeBase_IsValid_WithInvalidData_ReturnsFalse()
    {
        // Arrange
        var request = CreateValidCreateStringAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.Required = true;
        request.Default = "";

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void CreateStringAttributeBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidCreateStringAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.Required = true;
        request.Default = "";

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void CreateStringAttributeBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidCreateStringAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.Required = true;
        request.Default = "";

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
