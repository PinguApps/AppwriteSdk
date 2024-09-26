using FluentValidation;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class QueryParamBaseRequestTests
{
    private class TestRequest : QueryParamBaseRequest<TestRequest, TestValidator>
    {
        [UrlReplacement("{id}")]
        public string Id { get; set; } = string.Empty;

        [QueryParameter("name")]
        public string? Name { get; set; }

        [QueryParameter("tags")]
        public List<string>? Tags { get; set; }

        protected override string Path => "/api/resource/{id}";
    }

    private class TestValidator : AbstractValidator<TestRequest>
    {
    }

    [Fact]
    public void BuildUri_ShouldReplaceUrlPlaceholders()
    {
        // Arrange
        var request = new TestRequest
        {
            Id = "123"
        };

        var endpoint = "https://example.com";
        var expectedUri = new Uri("https://example.com/api/resource/123");

        // Act
        var result = request.BuildUri(endpoint, null);

        // Assert
        Assert.Equal(expectedUri, result);
    }

    [Fact]
    public void BuildUri_ShouldAddQueryParameters()
    {
        // Arrange
        var request = new TestRequest
        {
            Id = "123",
            Name = "test",
            Tags = ["tag1", "tag2"]
        };

        var endpoint = "https://example.com";
        var expectedUri = new Uri("https://example.com/api/resource/123?name=test&tags=tag1&tags=tag2");

        // Act
        var result = request.BuildUri(endpoint, null);

        // Assert
        Assert.Equal(expectedUri, result);
    }

    [Fact]
    public void BuildUri_ShouldAddProjectIdToQueryParameters()
    {
        // Arrange
        var request = new TestRequest
        {
            Id = "123"
        };

        var endpoint = "https://example.com";
        var projectId = "project123";
        var expectedUri = new Uri("https://example.com/api/resource/123?project=project123");

        // Act
        var result = request.BuildUri(endpoint, projectId);

        // Assert
        Assert.Equal(expectedUri, result);
    }

    [Fact]
    public void BuildUri_ShouldHandleNullQueryParameterValues()
    {
        // Arrange
        var request = new TestRequest
        {
            Id = "123",
            Name = null
        };

        var endpoint = "https://example.com";
        var expectedUri = new Uri("https://example.com/api/resource/123");

        // Act
        var result = request.BuildUri(endpoint, null);

        // Assert
        Assert.Equal(expectedUri, result);
    }

    [Fact]
    public void BuildUri_ShouldHandleEmptyEndpointPath()
    {
        // Arrange
        var request = new TestRequest
        {
            Id = "123"
        };

        var endpoint = "https://example.com/";
        var expectedUri = new Uri("https://example.com/api/resource/123");

        // Act
        var result = request.BuildUri(endpoint, null);

        // Assert
        Assert.Equal(expectedUri, result);
    }

    [Fact]
    public void BuildUri_ShouldHandleComplexQueryParameterValues()
    {
        // Arrange
        var request = new TestRequest
        {
            Id = "123",
            Tags = ["tag1", "tag2"]
        };

        var endpoint = "https://example.com";
        var expectedUri = new Uri("https://example.com/api/resource/123?tags=tag1&tags=tag2");

        // Act
        var result = request.BuildUri(endpoint, null);

        // Assert
        Assert.Equal(expectedUri, result);
    }

    [Fact]
    public void BuildUri_ShouldHandleExistingPathIdEndpoint()
    {
        // Arrange
        var request = new TestRequest
        {
            Id = "123"
        };

        var endpoint = "https://example.com/existing/path";
        var expectedUri = new Uri("https://example.com/existing/path/api/resource/123");

        // Act
        var result = request.BuildUri(endpoint, null);

        // Assert
        Assert.Equal(expectedUri, result);
    }
}
