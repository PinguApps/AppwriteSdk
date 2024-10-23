using System.Text.Json;
using Moq;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class AttributeStringTests
{
    [Fact]
    public void Size_ShouldBeSerialized()
    {
        var attribute = new AttributeString(
            "fullName",
            "string",
            AttributeStatus.Available,
            "string",
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            128,
            "default"
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"size\":128", json);
    }

    [Fact]
    public void Default_ShouldBeSerialized()
    {
        var attribute = new AttributeString(
            "fullName",
            "string",
            AttributeStatus.Available,
            "string",
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            128,
            "default"
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"default\":\"default\"", json);
    }

    [Fact]
    public void Accept_ShouldInvokeVisitor()
    {
        var attribute = new AttributeString(
            "fullName",
            "string",
            AttributeStatus.Available,
            "string",
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            128,
            "default"
        );

        var visitorMock = new Mock<IAttributeVisitor>();
        attribute.Accept(visitorMock.Object);

        visitorMock.Verify(v => v.Visit(attribute), Times.Once);
    }

    [Fact]
    public void AcceptT_ShouldInvokeVisitor()
    {
        var attribute = new AttributeString(
            "fullName",
            "string",
            AttributeStatus.Available,
            "string",
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            128,
            "default"
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
        var json = TestConstants.AttributeStringResponse;

        var attribute = JsonSerializer.Deserialize<AttributeString>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(attribute);
        Assert.Equal("fullName", attribute.Key);
        Assert.Equal("string", attribute.Type);
        Assert.Equal(AttributeStatus.Available, attribute.Status);
        Assert.Equal("string", attribute.Error);
        Assert.True(attribute.Required);
        Assert.False(attribute.Array);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.UpdatedAt.ToUniversalTime());
        Assert.Equal(128, attribute.Size);
        Assert.Equal("default", attribute.Default);
    }
}
