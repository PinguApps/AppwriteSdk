using System.Text.Json;
using Moq;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class AttributeFloatTests
{
    [Fact]
    public void Default_ShouldBeSerialized()
    {
        var attribute = new AttributeFloat(
            "percentageCompleted",
            "double",
            DatabaseElementStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1.5f,
            10.5f,
            2.5f
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"default\":2.5", json);
    }

    [Fact]
    public void Min_ShouldBeSerialized()
    {
        var attribute = new AttributeFloat(
            "percentageCompleted",
            "double",
            DatabaseElementStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1.5f,
            10.5f,
            2.5f
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"min\":1.5", json);
    }

    [Fact]
    public void Max_ShouldBeSerialized()
    {
        var attribute = new AttributeFloat(
            "percentageCompleted",
            "double",
            DatabaseElementStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1.5f,
            10.5f,
            2.5f
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"max\":10.5", json);
    }

    [Fact]
    public void Accept_ShouldInvokeVisitor()
    {
        var attribute = new AttributeFloat(
            "percentageCompleted",
            "double",
            DatabaseElementStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1.5f,
            10.5f,
            2.5f
        );

        var visitorMock = new Mock<IAttributeVisitor>();
        attribute.Accept(visitorMock.Object);

        visitorMock.Verify(v => v.Visit(attribute), Times.Once);
    }

    [Fact]
    public void AcceptT_ShouldInvokeVisitor()
    {
        var attribute = new AttributeFloat(
            "percentageCompleted",
            "double",
            DatabaseElementStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            1.5f,
            10.5f,
            2.5f
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
        var json = TestConstants.AttributeFloatResponse;

        var attribute = JsonSerializer.Deserialize<AttributeFloat>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(attribute);
        Assert.Equal("percentageCompleted", attribute.Key);
        Assert.Equal("double", attribute.Type);
        Assert.Equal(DatabaseElementStatus.Available, attribute.Status);
        Assert.Equal("string", attribute.Error);
        Assert.True(attribute.Required);
        Assert.False(attribute.Array);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.UpdatedAt.ToUniversalTime());
        Assert.Equal(1.5f, attribute.Min);
        Assert.Equal(10.5f, attribute.Max);
        Assert.Equal(2.5f, attribute.Default);
    }
}
