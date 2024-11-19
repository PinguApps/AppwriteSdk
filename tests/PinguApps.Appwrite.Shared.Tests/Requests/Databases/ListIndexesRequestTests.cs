using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class ListIndexesRequestTests : DatabaseCollectionIdBaseRequestTests<ListIndexesRequest, ListIndexesRequestValidator>
{
    protected override ListIndexesRequest CreateValidDatabaseCollectionIdRequest => new();


    [Fact]
    public void QueryBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new ListIndexesRequest();

        // Assert
        Assert.Null(request.Queries);
    }

    [Fact]
    public void QueryBase_Properties_CanBeSet()
    {
        // Arrange
        var attributeName = "attributeName";
        var value = "value";
        List<Query> queries = [Query.Equal(attributeName, value)];

        var request = new ListIndexesRequest();

        // Act
        request.Queries = queries;

        // Assert
        Assert.Collection(request.Queries, query =>
        {
            Assert.Equal(attributeName, query.Attribute);
            Assert.NotNull(query.Values);
            Assert.Collection(query.Values, v =>
            {
                Assert.Equal(value, v);
            });
            Assert.Equal("equal", query.Method);
        });
    }

    [Fact]
    public void QueryBase_IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = new ListIndexesRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Queries = [Query.Equal("attributeName", "value")];

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void QueryBase_IsValid_WithNullQueries_ReturnsTrue()
    {
        // Arrange
        var request = new ListIndexesRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void QueryBase_IsValid_WithInvalidData_QueryTooLarge_ReturnsFalse()
    {
        // Arrange
        var request = new ListIndexesRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Queries = [Query.Equal("attributeName", new string('a', 4097))];

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void QueryBase_IsValid_WithInvalidData_TooManyQueries_ReturnsFalse()
    {
        // Arrange
        var request = new ListIndexesRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.Queries = Enumerable.Range(0, 101)
            .Select(_ => Query.Equal("attributeName", "value"))
            .ToList();

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void QueryBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new ListIndexesRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Queries = Enumerable.Range(0, 101)
            .Select(_ => Query.Equal("attributeName", "value"))
            .ToList();

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void QueryBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new ListIndexesRequest();
        request.DatabaseId = IdUtils.GenerateUniqueId();
        request.CollectionId = IdUtils.GenerateUniqueId();
        request.Queries = Enumerable.Range(0, 101)
            .Select(_ => Query.Equal("attributeName", "value"))
            .ToList();

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
