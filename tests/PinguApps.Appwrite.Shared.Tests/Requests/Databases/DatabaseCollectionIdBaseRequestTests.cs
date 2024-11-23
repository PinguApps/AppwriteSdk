using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public abstract class DatabaseCollectionIdBaseRequestTests<TRequest, TValidator> : DatabaseIdBaseRequestTests<TRequest, TValidator>
        where TRequest : DatabaseCollectionIdBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected sealed override TRequest CreateValidRequest
    {
        get
        {
            var request = CreateValidDatabaseCollectionIdRequest;
            request.CollectionId = IdUtils.GenerateUniqueId();
            return request;
        }
    }

    protected abstract TRequest CreateValidDatabaseCollectionIdRequest { get; }

    [Fact]
    public void CollectionIdBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidDatabaseCollectionIdRequest;

        // Assert
        Assert.Equal(string.Empty, request.CollectionId);
    }

    [Fact]
    public void CollectionIdBase_Properties_CanBeSet()
    {
        // Arrange
        var collectionIdValue = "validId";
        var request = CreateValidDatabaseCollectionIdRequest;

        // Act
        request.CollectionId = collectionIdValue;

        // Assert
        Assert.Equal(collectionIdValue, request.CollectionId);
    }

    [Fact]
    public void CollectionIdBase_IsValid_WithValidTeamId_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionIdRequest;
        request.DatabaseId = "valid_Team-Id.";
        request.CollectionId = "valid_Team-Id.";

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CollectionIdBase_IsValid_WithInvalidData_ReturnsFalse(string? id)
    {
        // Arrange
        var request = CreateValidDatabaseCollectionIdRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = id!;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void CollectionIdBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionIdRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = string.Empty; // Invalid Id

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void CollectionIdBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionIdRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = string.Empty; // Invalid Id

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
