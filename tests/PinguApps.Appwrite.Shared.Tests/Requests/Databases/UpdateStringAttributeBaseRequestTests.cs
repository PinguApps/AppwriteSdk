using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public abstract class UpdateStringAttributeBaseRequestTests<TRequest, TValidator> : UpdateAttributeBaseRequestTests<TRequest, TValidator>
        where TRequest : UpdateStringAttributeBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected sealed override TRequest CreateValidUpdateAttributeBaseRequest => CreateValidUpdateStringAttributeBaseRequest;

    protected abstract TRequest CreateValidUpdateStringAttributeBaseRequest { get; }

    [Fact]
    public void UpdateStringAttributeBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidUpdateStringAttributeBaseRequest;

        // Assert
        Assert.Null(request.Default);
    }

    [Fact]
    public void UpdateStringAttributeBase_Properties_CanBeSet()
    {
        // Arrange
        var defaultValue = "validKey";
        var request = CreateValidUpdateStringAttributeBaseRequest;

        // Act
        request.Default = defaultValue;

        // Assert
        Assert.Equal(defaultValue, request.Default);
    }

    [Fact]
    public void UpdateStringAttributeBase_IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidUpdateStringAttributeBaseRequest;
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
    public void UpdateStringAttributeBase_IsValid_WithInvalidData_ReturnsFalse()
    {
        // Arrange
        var request = CreateValidUpdateStringAttributeBaseRequest;
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
    public void UpdateStringAttributeBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidUpdateStringAttributeBaseRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.Required = true;
        request.Default = "";

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void UpdateStringAttributeBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidUpdateStringAttributeBaseRequest;
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
