using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public abstract class QuerySearchBaseRequestTests<TRequest, TValidator> : QueryBaseRequestTests<TRequest, TValidator>
        where TRequest : QuerySearchBaseRequest<TRequest, TValidator>, new()
        where TValidator : AbstractValidator<TRequest>, new()
{
    [Fact]
    public void QuerySearchBase_SearchProperty_CanBeSet()
    {
        // Arrange
        var searchValue = "test search";
        var request = CreateValidRequest;

        // Act
        request.Search = searchValue;

        // Assert
        Assert.Equal(searchValue, request.Search);
    }

    [Fact]
    public void QuerySearchBase_IsValid_WithValidSearch_ReturnsTrue()
    {
        // Arrange
        var request = CreateValidRequest;
        request.Search = "valid search term";

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void QuerySearchBase_IsValid_WithSearchTooLong_ReturnsFalse()
    {
        // Arrange
        var request = CreateValidRequest;
        request.Search = new string('a', 257); // 257 characters, exceeding the limit

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void QuerySearchBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.Search = new string('a', 257); // 257 characters, exceeding the limit

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void QuerySearchBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.Search = new string('a', 257); // 257 characters, exceeding the limit

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
