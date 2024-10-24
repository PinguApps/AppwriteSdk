using System.Text.Json;
using Moq;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class AttributeUrlTests
{
    [Fact]
    public void Format_ShouldBeSerialized()
    {
        var attribute = new AttributeUrl(
            "githubUrl",
            "string",
            DatabaseElementStatus.Available,
            "string",
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "url",
            "http://example.com"
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"format\":\"url\"", json);
    }

    [Fact]
    public void Default_ShouldBeSerialized()
    {
        var attribute = new AttributeUrl(
            "githubUrl",
            "string",
            DatabaseElementStatus.Available,
            "string",
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "url",
            "http://example.com"
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"default\":\"http://example.com\"", json);
    }

    [Fact]
    public void Accept_ShouldInvokeVisitor()
    {
        var attribute = new AttributeUrl(
            "githubUrl",
            "string",
            DatabaseElementStatus.Available,
            "string",
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "url",
            "http://example.com"
        );

        var visitorMock = new Mock<IAttributeVisitor>();
        attribute.Accept(visitorMock.Object);

        visitorMock.Verify(v => v.Visit(attribute), Times.Once);
    }

    [Fact]
    public void AcceptT_ShouldInvokeVisitor()
    {
        var attribute = new AttributeUrl(
            "githubUrl",
            "string",
            DatabaseElementStatus.Available,
            "string",
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "url",
            "http://example.com"
        );

        var visitorMock = new Mock<IAttributeVisitor<string>>();
        visitorMock.Setup(v => v.Visit(attribute)).Returns("Visited");

        var result = attribute.Accept(visitorMock.Object);

        visitorMock.Verify(v => v.Visit(attribute), Times.Once);
        Assert.Equal("Visited", result);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        var attribute = JsonSerializer.Deserialize<AttributeUrl>(TestConstants.AttributeUrlResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(attribute);
        Assert.Equal("githubUrl", attribute.Key);
        Assert.Equal("string", attribute.Type);
        Assert.Equal(DatabaseElementStatus.Available, attribute.Status);
        Assert.Equal("string", attribute.Error);
        Assert.True(attribute.Required);
        Assert.False(attribute.Array);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.UpdatedAt.ToUniversalTime());
        Assert.Equal("url", attribute.Format);
        Assert.Equal("http://example.com", attribute.Default);
    }
}
