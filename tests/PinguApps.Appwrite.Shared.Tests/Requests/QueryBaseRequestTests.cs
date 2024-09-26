﻿using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Requests.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class QueryBaseRequestTests
{
    public class TestRequest : QueryBaseRequest<TestRequest, TestValidator>
    { }

    public class TestValidator : AbstractValidator<TestRequest>
    {
        public TestValidator()
        {
            Include(new QueryBaseRequestValidator<TestRequest, TestValidator>());
        }
    }


    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new TestRequest();

        // Assert
        Assert.Null(request.Queries);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var attributeName = "attributeName";
        var value = "value";
        List<Query> queries = [Query.Equal(attributeName, value)];
        var request = new TestRequest();

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
    public void IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = new TestRequest
        {
            Queries = [Query.Equal("attributeName", "value")]
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void IsValid_WithNullQueries_ReturnsTrue()
    {
        // Arrange
        var request = new TestRequest();

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void IsValid_WithInvalidData_QueryTooLarge_ReturnsFalse()
    {
        // Arrange
        var request = new TestRequest
        {
            Queries = [Query.Equal("attributeName", new string('a', 4097))]
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void IsValid_WithInvalidData_TooManyQueries_ReturnsFalse()
    {
        // Arrange
        var request = new TestRequest
        {
            Queries = Enumerable.Range(0, 101)
                .Select(_ => Query.Equal("attributeName", "value"))
                .ToList()
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
        var request = new TestRequest
        {
            Queries = Enumerable.Range(0, 101)
                .Select(_ => Query.Equal("attributeName", "value"))
                .ToList()
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new TestRequest
        {
            Queries = Enumerable.Range(0, 101)
                .Select(_ => Query.Equal("attributeName", "value"))
                .ToList()
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
