using System.Text.Json;
using Moq;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Responses.Interfaces;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class AttributeRelationshipTests
{
    [Fact]
    public void RelatedCollection_ShouldBeSerialized()
    {
        var attribute = new AttributeRelationship(
            "fullName",
            "string",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "collection",
            RelationType.OneToOne,
            false,
            "string",
            OnDelete.Restrict,
            RelationshipSide.Parent
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"relatedCollection\":\"collection\"", json);
    }

    [Fact]
    public void RelationType_ShouldBeSerialized()
    {
        var attribute = new AttributeRelationship(
            "fullName",
            "string",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "collection",
            RelationType.OneToOne,
            false,
            "string",
            OnDelete.Restrict,
            RelationshipSide.Parent
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"relationType\":\"oneToOne\"", json);
    }

    [Fact]
    public void TwoWay_ShouldBeSerialized()
    {
        var attribute = new AttributeRelationship(
            "fullName",
            "string",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "collection",
            RelationType.OneToOne,
            false,
            "string",
            OnDelete.Restrict,
            RelationshipSide.Parent
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"twoWay\":false", json);
    }

    [Fact]
    public void TwoWayKey_ShouldBeSerialized()
    {
        var attribute = new AttributeRelationship(
            "fullName",
            "string",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "collection",
            RelationType.OneToOne,
            false,
            "string",
            OnDelete.Restrict,
            RelationshipSide.Parent
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"twoWayKey\":\"string\"", json);
    }

    [Fact]
    public void OnDelete_ShouldBeSerialized()
    {
        var attribute = new AttributeRelationship(
            "fullName",
            "string",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "collection",
            RelationType.OneToOne,
            false,
            "string",
            OnDelete.Restrict,
            RelationshipSide.Parent
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"onDelete\":\"restrict\"", json);
    }

    [Fact]
    public void Side_ShouldBeSerialized()
    {
        var attribute = new AttributeRelationship(
            "fullName",
            "string",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "collection",
            RelationType.OneToOne,
            false,
            "string",
            OnDelete.Restrict,
            RelationshipSide.Parent
        );

        var json = JsonSerializer.Serialize(attribute);
        Assert.Contains("\"side\":\"parent\"", json);
    }

    [Fact]
    public void Accept_ShouldInvokeVisitor()
    {
        var attribute = new AttributeRelationship(
            "fullName",
            "string",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "collection",
            RelationType.OneToOne,
            false,
            "string",
            OnDelete.Restrict,
            RelationshipSide.Parent
        );

        var visitorMock = new Mock<IAttributeVisitor>();
        attribute.Accept(visitorMock.Object);

        visitorMock.Verify(v => v.Visit(attribute), Times.Once);
    }

    [Fact]
    public void AcceptT_ShouldInvokeVisitor()
    {
        var attribute = new AttributeRelationship(
            "fullName",
            "string",
            AttributeStatus.Available,
            null,
            true,
            false,
            DateTime.UtcNow,
            DateTime.UtcNow,
            "collection",
            RelationType.OneToOne,
            false,
            "string",
            OnDelete.Restrict,
            RelationshipSide.Parent
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
        var json = TestConstants.AttributeRelationshipResponse;

        var attribute = JsonSerializer.Deserialize<AttributeRelationship>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(attribute);
        Assert.Equal("fullName", attribute.Key);
        Assert.Equal("string", attribute.Type);
        Assert.Equal(AttributeStatus.Available, attribute.Status);
        Assert.Equal("string", attribute.Error);
        Assert.True(attribute.Required);
        Assert.False(attribute.Array);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attribute.UpdatedAt.ToUniversalTime());
        Assert.Equal("collection", attribute.RelatedCollection);
        Assert.Equal(RelationType.ManyToOne, attribute.RelationType);
        Assert.False(attribute.TwoWay);
        Assert.Equal("string", attribute.TwoWayKey);
        Assert.Equal(OnDelete.Cascade, attribute.OnDelete);
        Assert.Equal(RelationshipSide.Child, attribute.Side);
    }
}
