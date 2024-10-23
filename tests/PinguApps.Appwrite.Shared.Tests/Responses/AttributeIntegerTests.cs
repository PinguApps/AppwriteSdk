using System.Text.Json;
using Moq;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class AttributeIntegerTests
{
    [Fact]
    public void Default_ShouldBeSerialized()
    {
        var attribute = new AttributeInteger(
            "count",
            "integer",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1,
            10,
            10
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"default\":10", json);
    }

    [Fact]
    public void Min_ShouldBeSerialized()
    {
        var attribute = new AttributeInteger(
            "count",
            "integer",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1,
            10,
            10
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"min\":1", json);
    }

    [Fact]
    public void Max_ShouldBeSerialized()
    {
        var attribute = new AttributeInteger(
            "count",
            "integer",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1,
            10,
            10
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"max\":10", json);
    }

    [Fact]
    public void Accept_ShouldInvokeVisitor()
    {
        var attribute = new AttributeInteger(
            "count",
            "integer",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1,
            10,
            10
        );

        var visitorMock = new Mock<IAttributeVisitor>();
        attribute.Accept(visitorMock.Object);

        visitorMock.Verify(v => v.Visit(attribute), Times.Once);
    }

    [Fact]
    public void AcceptT_ShouldInvokeVisitor()
    {
        var attribute = new AttributeInteger(
            "count",
            "integer",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1,
            10,
            10
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
        var json = TestConstants.AttributeIntegerResponse;

        var attribute = JsonSerializer.Deserialize<AttributeInteger>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(attribute);
        Assert.Equal("count", attribute.Key);
        Assert.Equal("integer", attribute.Type);
        Assert.Equal(AttributeStatus.Available, attribute.Status);
        Assert.Equal("string", attribute.Error);
        Assert.True(attribute.Required);
        Assert.False(attribute.Array);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.UpdatedAt.ToUniversalTime());
        Assert.Equal(1, attribute.Min);
        Assert.Equal(10, attribute.Max);
        Assert.Equal(10, attribute.Default);
    }
}
