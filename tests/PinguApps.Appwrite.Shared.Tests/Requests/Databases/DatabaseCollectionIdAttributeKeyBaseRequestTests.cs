using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public abstract class DatabaseCollectionIdAttributeKeyBaseRequestTests<TRequest, TValidator> : DatabaseCollectionIdBaseRequestTests<TRequest, TValidator>
        where TRequest : DatabaseCollectionIdAttributeKeyBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected sealed override TRequest CreateValidDatabaseCollectionIdRequest
    {
        get
        {
            var request = CreateValidDatabaseCollectionIdAttributeKeyRequest;
            request.Key = IdUtils.GenerateUniqueId();
            return request;
        }
    }

    protected abstract TRequest CreateValidDatabaseCollectionIdAttributeKeyRequest { get; }

    [Fact]
    public void KeyBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidDatabaseCollectionIdAttributeKeyRequest;

        // Assert
        Assert.Equal(string.Empty, request.Key);
    }

    [Fact]
    public void KeyBase_Properties_CanBeSet()
    {
        // Arrange
        var value = "validId";
        var request = CreateValidDatabaseCollectionIdAttributeKeyRequest;

        // Act
        request.Key = value;

        // Assert
        Assert.Equal(value, request.Key);
    }

    [Fact]
    public void KeyBase_IsValid_WithValidTeamId_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionIdAttributeKeyRequest;
        request.DatabaseId = "valid_Team-Id.";
        request.CollectionId = "valid_Team-Id.";
        request.Key = "ValidKey";

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void KeyBase_IsValid_WithInvalidData_ReturnsFalse(string? id)
    {
        // Arrange
        var request = CreateValidDatabaseCollectionIdAttributeKeyRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = id!;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void KeyBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionIdAttributeKeyRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = string.Empty;

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void KeyBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionIdAttributeKeyRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = string.Empty;

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
