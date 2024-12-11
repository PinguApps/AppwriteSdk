using FluentValidation;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateIndexRequestTests : DatabaseCollectionIdBaseRequestTests<CreateIndexRequest, CreateIndexRequestValidator>
{
    protected override CreateIndexRequest CreateValidDatabaseCollectionIdRequest => new()
    {
        Key = "test_index",
        IndexType = IndexType.Key,
        Attributes = ["attr1"],
        Orders = [SortDirection.Asc]
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateIndexRequest();

        // Assert
        Assert.Equal(string.Empty, request.Key);
        Assert.Equal(IndexType.Key, request.IndexType);
        Assert.Empty(request.Attributes);
        Assert.Empty(request.Orders);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var key = "test_index";
        var indexType = IndexType.Unique;
        var attributes = new List<string> { "attr1", "attr2" };
        var orders = new List<SortDirection> { SortDirection.Asc, SortDirection.Desc };

        var request = new CreateIndexRequest();

        // Act
        request.Key = key;
        request.IndexType = indexType;
        request.Attributes = attributes;
        request.Orders = orders;

        // Assert
        Assert.Equal(key, request.Key);
        Assert.Equal(indexType, request.IndexType);
        Assert.Equal(attributes, request.Attributes);
        Assert.Equal(orders, request.Orders);
    }

    public static TheoryData<CreateIndexRequest> ValidRequestsData = new()
    {
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "valid_index",
            IndexType = IndexType.Key,
            Attributes = ["attr1"],
            Orders = [SortDirection.Asc]
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "multi_index",
            IndexType = IndexType.Unique,
            Attributes = ["attr1", "attr2"],
            Orders = [SortDirection.Asc, SortDirection.Desc]
        }
    };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateIndexRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateIndexRequest> InvalidRequestsData = new()
    {
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "",
            IndexType = IndexType.Key,
            Attributes = ["attr1"],
            Orders = [SortDirection.Asc]
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = null!,
            IndexType = IndexType.Key,
            Attributes = ["attr1"],
            Orders = [SortDirection.Asc]
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "valid_key",
            IndexType = (IndexType) 9999,
            Attributes = ["attr1"],
            Orders = [SortDirection.Asc]
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "valid_key",
            IndexType = IndexType.Key,
            Attributes = [new string('a', 33)],
            Orders = [SortDirection.Asc]
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "valid_key",
            IndexType = IndexType.Key,
            Attributes = Enumerable.Range(0,101).Select(x => x.ToString()).ToList(),
            Orders = Enumerable.Range(0,101).Select(x => SortDirection.Asc).ToList()
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "valid_key",
            IndexType = IndexType.Key,
            Attributes = ["attr1", "attr2"],
            Orders = [SortDirection.Asc]
        }
    };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateIndexRequest request)
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
        var request = new CreateIndexRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "",
            IndexType = IndexType.Key,
            Attributes = [],
            Orders = []
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateIndexRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "",
            IndexType = IndexType.Key,
            Attributes = [],
            Orders = []
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
