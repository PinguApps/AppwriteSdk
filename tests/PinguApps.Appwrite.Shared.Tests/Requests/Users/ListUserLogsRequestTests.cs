using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class ListUserLogsRequestTests : UserIdBaseRequestTests<ListUserLogsRequest, ListUserLogsRequestValidator>
{
    protected override ListUserLogsRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new ListUserLogsRequest();

        // Assert
        Assert.Null(request.Queries);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var queries = new List<Query> { Query.Limit(10) };

        // Arrange
        var request = new ListUserLogsRequest();

        // Act
        request.Queries = queries;

        // Assert
        Assert.Single(request.Queries, queries[0]);
    }

    public static TheoryData<List<Query>?> ValidQueriesData =
    [
        null,
        [Query.Limit(10)],
        [Query.Offset(10)]
    ];

    [Theory]
    [MemberData(nameof(ValidQueriesData))]
    public void IsValid_WithValidData_ReturnsTrue(List<Query>? queries)
    {
        // Arrange
        var request = new ListUserLogsRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Queries = queries
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<List<Query>?> InvalidQueriesData =
    [
        Enumerable.Range(0,101).Select(x => Query.Limit(x)).ToList(),
        [Query.And([])],
        [Query.Between("a", 0, 1)],
        [Query.Contains("a", "a")],
        [Query.CursorAfter("a")],
        [Query.CursorBefore("a")],
        [Query.EndsWith("a", "a")],
        [Query.Equal("a", "a")],
        [Query.GreaterThan("a", "a")],
        [Query.IsNotNull("a")],
        [Query.IsNull("a")],
        [Query.LessThan("a", "a")],
        [Query.LessThanEqual("a", "a")],
        [Query.NotEqual("a", "a")],
        [Query.Or([])],
        [Query.OrderAsc("a")],
        [Query.OrderDesc("a")],
        [Query.Search("a", "a")],
        [Query.Select([])],
        [Query.StartsWith("a", "a")]
    ];

    [Theory]
    [MemberData(nameof(InvalidQueriesData))]
    public void IsValid_WithInvalidData_ReturnsFalse(List<Query>? queries)
    {
        // Arrange
        var request = new ListUserLogsRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Queries = queries
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new ListUserLogsRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Queries = [Query.StartsWith("a", "a")]
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new ListUserLogsRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Queries = [Query.StartsWith("a", "a")]
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
