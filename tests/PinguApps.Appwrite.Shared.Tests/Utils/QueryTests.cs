using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Utils;
public class QueryTests
{
    [Fact]
    public void Equal_Returns_CorrectQuery()
    {
        // Act
        var query = Query.Equal("name", "John");

        // Assert
        Assert.Equal("equal", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal("John", query.Values[0]);
    }

    [Fact]
    public void NotEqual_Returns_CorrectQuery()
    {
        // Act
        var query = Query.NotEqual("name", "John");

        // Assert
        Assert.Equal("notEqual", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal("John", query.Values[0]);
    }

    [Fact]
    public void LessThan_Returns_CorrectQuery()
    {
        // Act
        var query = Query.LessThan("age", 30);

        // Assert
        Assert.Equal("lessThan", query.Method);
        Assert.Equal("age", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal(30, query.Values[0]);
    }

    [Fact]
    public void LessThanEqual_Returns_CorrectQuery()
    {
        // Act
        var query = Query.LessThanEqual("age", 30);

        // Assert
        Assert.Equal("lessThanEqual", query.Method);
        Assert.Equal("age", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal(30, query.Values[0]);
    }

    [Fact]
    public void GreaterThan_Returns_CorrectQuery()
    {
        // Act
        var query = Query.GreaterThan("age", 30);

        // Assert
        Assert.Equal("greaterThan", query.Method);
        Assert.Equal("age", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal(30, query.Values[0]);
    }

    [Fact]
    public void GreaterThanEqual_Returns_CorrectQuery()
    {
        // Act
        var query = Query.GreaterThanEqual("age", 30);

        // Assert
        Assert.Equal("greaterThanEqual", query.Method);
        Assert.Equal("age", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal(30, query.Values[0]);
    }

    [Fact]
    public void Search_Returns_CorrectQuery()
    {
        // Act
        var query = Query.Search("name", "John");

        // Assert
        Assert.Equal("search", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal("John", query.Values[0]);
    }

    [Fact]
    public void IsNull_Returns_CorrectQuery()
    {
        // Act
        var query = Query.IsNull("name");

        // Assert
        Assert.Equal("isNull", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.Null(query.Values);
    }

    [Fact]
    public void IsNotNull_Returns_CorrectQuery()
    {
        // Act
        var query = Query.IsNotNull("name");

        // Assert
        Assert.Equal("isNotNull", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.Null(query.Values);
    }

    [Fact]
    public void StartsWith_Returns_CorrectQuery()
    {
        // Act
        var query = Query.StartsWith("name", "Jo");

        // Assert
        Assert.Equal("startsWith", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal("Jo", query.Values[0]);
    }

    [Fact]
    public void EndsWith_Returns_CorrectQuery()
    {
        // Act
        var query = Query.EndsWith("name", "hn");

        // Assert
        Assert.Equal("endsWith", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal("hn", query.Values[0]);
    }

    [Fact]
    public void Between_Returns_CorrectQuery_ForString()
    {
        // Act
        var query = Query.Between("age", "20", "30");

        // Assert
        Assert.Equal("between", query.Method);
        Assert.Equal("age", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Equal(2, query.Values.Count);
        Assert.Equal("20", query.Values[0]);
        Assert.Equal("30", query.Values[1]);
    }

    [Fact]
    public void Between_Returns_CorrectQuery_ForInt()
    {
        // Act
        var query = Query.Between("age", 20, 30);

        // Assert
        Assert.Equal("between", query.Method);
        Assert.Equal("age", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Equal(2, query.Values.Count);
        Assert.Equal(20, query.Values[0]);
        Assert.Equal(30, query.Values[1]);
    }

    [Fact]
    public void Between_Returns_CorrectQuery_ForDouble()
    {
        // Act
        var query = Query.Between("age", 20.5, 30.5);

        // Assert
        Assert.Equal("between", query.Method);
        Assert.Equal("age", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Equal(2, query.Values.Count);
        Assert.Equal(20.5, query.Values[0]);
        Assert.Equal(30.5, query.Values[1]);
    }

    [Fact]
    public void Select_Returns_CorrectQuery()
    {
        // Act
        var query = Query.Select(new List<string> { "name", "age" });

        // Assert
        Assert.Equal("select", query.Method);
        Assert.Null(query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Equal(2, query.Values.Count);
        Assert.Equal("name", query.Values[0]);
        Assert.Equal("age", query.Values[1]);
    }

    [Fact]
    public void CursorAfter_Returns_CorrectQuery()
    {
        // Act
        var query = Query.CursorAfter("docId");

        // Assert
        Assert.Equal("cursorAfter", query.Method);
        Assert.Null(query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal("docId", query.Values[0]);
    }

    [Fact]
    public void CursorBefore_Returns_CorrectQuery()
    {
        // Act
        var query = Query.CursorBefore("docId");

        // Assert
        Assert.Equal("cursorBefore", query.Method);
        Assert.Null(query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal("docId", query.Values[0]);
    }

    [Fact]
    public void OrderAsc_Returns_CorrectQuery()
    {
        // Act
        var query = Query.OrderAsc("name");

        // Assert
        Assert.Equal("orderAsc", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.Null(query.Values);
    }

    [Fact]
    public void OrderDesc_Returns_CorrectQuery()
    {
        // Act
        var query = Query.OrderDesc("name");

        // Assert
        Assert.Equal("orderDesc", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.Null(query.Values);
    }

    [Fact]
    public void Limit_Returns_CorrectQuery()
    {
        // Act
        var query = Query.Limit(10);

        // Assert
        Assert.Equal("limit", query.Method);
        Assert.Null(query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal(10, query.Values[0]);
    }

    [Fact]
    public void Offset_Returns_CorrectQuery()
    {
        // Act
        var query = Query.Offset(5);

        // Assert
        Assert.Equal("offset", query.Method);
        Assert.Null(query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal(5, query.Values[0]);
    }

    [Fact]
    public void Contains_Returns_CorrectQuery()
    {
        // Act
        var query = Query.Contains("name", "John");

        // Assert
        Assert.Equal("contains", query.Method);
        Assert.Equal("name", query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Single(query.Values);
        Assert.Equal("John", query.Values[0]);
    }

    [Fact]
    public void Or_Returns_CorrectQuery()
    {
        // Arrange
        var queries = new List<Query> { Query.Equal("name", "John"), Query.Equal("age", 30) };

        // Act
        var query = Query.Or(queries);

        // Assert
        Assert.Equal("or", query.Method);
        Assert.Null(query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Equal(2, query.Values.Count);
    }

    [Fact]
    public void And_Returns_CorrectQuery()
    {
        // Arrange
        var queries = new List<Query> { Query.Equal("name", "John"), Query.Equal("age", 30) };

        // Act
        var query = Query.And(queries);

        // Assert
        Assert.Equal("and", query.Method);
        Assert.Null(query.Attribute);
        Assert.NotNull(query.Values);
        Assert.Equal(2, query.Values.Count);
    }

    [Fact]
    public void GetQueryString_Returns_ValidJson()
    {
        // Act
        var query = Query.Equal("name", "John");
        var queryString = query.GetQueryString();

        // Assert
        Assert.Contains("%22method%22:%22equal%22", queryString);
        Assert.Contains("%22attribute%22:%22name%22", queryString);
        Assert.Contains("%22values%22:[%22John%22]", queryString);
    }
}
