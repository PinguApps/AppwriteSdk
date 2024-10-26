using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class ListAttributesRequestTests : QueryBaseRequestTests<ListAttributesRequest, ListAttributesRequestValidator>
{
    protected override ListAttributesRequest CreateValidRequest => new()
    {
        DatabaseId = IdUtils.GenerateUniqueId(),
        CollectionId = IdUtils.GenerateUniqueId()
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new ListAttributesRequest();

        // Assert
        Assert.Equal(string.Empty, request.DatabaseId);
        Assert.Equal(string.Empty, request.CollectionId);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var databaseId = "testDatabaseId";
        var collectionId = "testCollectionId";

        var request = new ListAttributesRequest();

        // Act
        request.DatabaseId = databaseId;
        request.CollectionId = collectionId;

        // Assert
        Assert.Equal(databaseId, request.DatabaseId);
        Assert.Equal(collectionId, request.CollectionId);
    }

    public static TheoryData<ListAttributesRequest> ValidRequestsData =>
        [
            new()
            {
                DatabaseId = "validDatabaseId123",
                CollectionId = "validCollectionId123"
            },
            new()
            {
                DatabaseId = "anotherValidDatabaseId",
                CollectionId = "anotherValidCollectionId"
            }
        ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(ListAttributesRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<ListAttributesRequest> InvalidRequestsData =>
        [
            new()
            {
                DatabaseId = null!,
                CollectionId = IdUtils.GenerateUniqueId()
            },
            new()
            {
                DatabaseId = "",
                CollectionId = IdUtils.GenerateUniqueId()
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = null!
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = ""
            }
        ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(ListAttributesRequest request)
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
        var request = new ListAttributesRequest
        {
            DatabaseId = "",
            CollectionId = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new ListAttributesRequest
        {
            DatabaseId = "",
            CollectionId = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
