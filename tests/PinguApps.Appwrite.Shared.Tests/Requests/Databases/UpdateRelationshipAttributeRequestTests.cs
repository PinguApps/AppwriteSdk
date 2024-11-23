using FluentValidation;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateRelationshipAttributeRequestTests : DatabaseCollectionIdAttributeKeyBaseRequestTests<UpdateRelationshipAttributeRequest, UpdateRelationshipAttributeRequestValidator>
{
    protected override UpdateRelationshipAttributeRequest CreateValidDatabaseCollectionIdAttributeKeyRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateRelationshipAttributeRequest();

        // Assert
        Assert.Null(request.NewKey);
        Assert.Null(request.OnDelete);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var keyValue = "validKey";
        var onDeleteValue = OnDelete.SetNull;
        var request = new UpdateRelationshipAttributeRequest();

        // Act
        request.NewKey = keyValue;
        request.OnDelete = onDeleteValue;

        // Assert
        Assert.Equal(keyValue, request.NewKey);
        Assert.Equal(onDeleteValue, request.OnDelete);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("validKey", OnDelete.Restrict)]
    [InlineData("validKey", OnDelete.Cascade)]
    [InlineData("validKey", OnDelete.SetNull)]
    public void IsValid_WithValidData_ReturnsTrue(string? key, OnDelete? onDelete)
    {
        // Arrange
        var request = new UpdateRelationshipAttributeRequest();
        request.DatabaseId = "valid_Team-Id.";
        request.CollectionId = "valid_Team-Id.";
        request.Key = "validKey";
        request.NewKey = key;
        request.OnDelete = onDelete;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("", null)]
    [InlineData(null, (OnDelete)999)]
    public void IsValid_WithInvalidData_ReturnsFalse(string? key, OnDelete? onDelete)
    {
        // Arrange
        var request = new UpdateRelationshipAttributeRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.NewKey = key;
        request.OnDelete = onDelete;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new UpdateRelationshipAttributeRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.NewKey = "";
        request.OnDelete = (OnDelete)999;

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateRelationshipAttributeRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Key = "validKey";
        request.NewKey = "";
        request.OnDelete = (OnDelete)999;

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
