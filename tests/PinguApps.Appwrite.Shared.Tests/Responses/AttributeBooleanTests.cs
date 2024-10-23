using System.Text.Json;
using Moq;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class AttributeBooleanTests
{
    [Fact]
    public void Default_ShouldBeSerialized()
    {
        var attribute = new AttributeBoolean(
            "a",
            "boolean",
            AttributeStatus.Available,
            null,
            false,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            true
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"default\":true", json);
    }

    [Fact]
    public void Accept_ShouldInvokeVisitor()
    {
        var attribute = new AttributeBoolean(
            "a",
            "boolean",
            AttributeStatus.Available,
            null,
            false,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            true
        );

        var visitorMock = new Mock<IAttributeVisitor>();
        attribute.Accept(visitorMock.Object);

        visitorMock.Verify(v => v.Visit(attribute), Times.Once);
    }

    [Fact]
    public void AcceptT_ShouldInvokeVisitor()
    {
        var attribute = new AttributeBoolean(
            "a",
            "boolean",
            AttributeStatus.Available,
            null,
            false,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            true
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
        var json = TestConstants.AttributeBooleanResponse;

        var attribute = JsonSerializer.Deserialize<AttributeBoolean>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(attribute);
        Assert.Equal("isEnabled", attribute.Key);
        Assert.Equal("boolean", attribute.Type);
        Assert.Equal(AttributeStatus.Available, attribute.Status);
        Assert.Equal("string", attribute.Error);
        Assert.True(attribute.Required);
        Assert.False(attribute.Array);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.UpdatedAt.ToUniversalTime());
        Assert.False(attribute.Default);
    }
}
