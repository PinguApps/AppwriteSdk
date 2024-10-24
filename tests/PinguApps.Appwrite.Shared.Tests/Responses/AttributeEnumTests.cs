using System.Text.Json;
using Moq;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class AttributeEnumTests
{
    [Fact]
    public void Default_ShouldBeSerialized()
    {
        var attribute = new AttributeEnum(
            "a",
            "string",
            DatabaseElementStatus.Available,
            null,
            false,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            ["element1", "element2"],
            "enum",
            "element1"
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"default\":\"element1\"", json);
    }

    [Fact]
    public void Elements_ShouldBeSerialized()
    {
        var attribute = new AttributeEnum(
            "a",
            "string",
            DatabaseElementStatus.Available,
            null,
            false,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            ["element1", "element2"],
            "enum",
            "element1"
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"elements\":[\"element1\",\"element2\"]", json);
    }

    [Fact]
    public void Format_ShouldBeSerialized()
    {
        var attribute = new AttributeEnum(
            "a",
            "string",
            DatabaseElementStatus.Available,
            null,
            false,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            ["element1", "element2"],
            "enum",
            "element1"
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"format\":\"enum\"", json);
    }

    [Fact]
    public void Accept_ShouldInvokeVisitor()
    {
        var attribute = new AttributeEnum(
            "a",
            "string",
            DatabaseElementStatus.Available,
            null,
            false,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            ["element1", "element2"],
            "enum",
            "element1"
        );

        var visitorMock = new Mock<IAttributeVisitor>();
        attribute.Accept(visitorMock.Object);

        visitorMock.Verify(v => v.Visit(attribute), Times.Once);
    }

    [Fact]
    public void AcceptT_ShouldInvokeVisitor()
    {
        var attribute = new AttributeEnum(
            "a",
            "string",
            DatabaseElementStatus.Available,
            null,
            false,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            ["element1", "element2"],
            "enum",
            "element1"
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
        var json = TestConstants.AttributeEnumResponse;

        var attribute = JsonSerializer.Deserialize<AttributeEnum>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(attribute);
        Assert.Equal("status", attribute.Key);
        Assert.Equal("string", attribute.Type);
        Assert.Equal(DatabaseElementStatus.Available, attribute.Status);
        Assert.Equal("string", attribute.Error);
        Assert.True(attribute.Required);
        Assert.False(attribute.Array);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.UpdatedAt.ToUniversalTime());
        Assert.Equal(new List<string> { "element" }, attribute.Elements);
        Assert.Equal("enum", attribute.Format);
        Assert.Equal("element", attribute.Default);
    }
}
