using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public abstract class DatabaseCollectionDocumentIdBaseRequestTests<TRequest, TValidator> : DatabaseCollectionIdBaseRequestTests<TRequest, TValidator>
        where TRequest : DatabaseCollectionDocumentIdBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected sealed override TRequest CreateValidDatabaseCollectionIdRequest
    {
        get
        {
            var request = CreateValidDatabaseCollectionDocumentIdRequest;
            request.DocumentId = IdUtils.GenerateUniqueId();
            return request;
        }
    }

    protected abstract TRequest CreateValidDatabaseCollectionDocumentIdRequest { get; }

    [Fact]
    public void KeyBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidDatabaseCollectionDocumentIdRequest;

        // Assert
        Assert.Equal(string.Empty, request.DocumentId);
    }

    [Fact]
    public void KeyBase_Properties_CanBeSet()
    {
        // Arrange
        var value = "validId";
        var request = CreateValidDatabaseCollectionDocumentIdRequest;

        // Act
        request.DocumentId = value;

        // Assert
        Assert.Equal(value, request.DocumentId);
    }

    [Fact]
    public void KeyBase_IsValid_WithValidTeamId_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionDocumentIdRequest;
        request.DatabaseId = "valid_Team-Id.";
        request.CollectionId = "valid_Team-Id.";
        request.DocumentId = "valid_Team-Id.";

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
        var request = CreateValidDatabaseCollectionDocumentIdRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.DocumentId = id!;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void KeyBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionDocumentIdRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.DocumentId = string.Empty;

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void KeyBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidDatabaseCollectionDocumentIdRequest;
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.DocumentId = string.Empty;

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
