using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class AttributesListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var attributes = new List<Attribute>
            {
                new AttributeBoolean("isEnabled", "boolean", DatabaseElementStatus.Available, "string", true,
                false, DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(),
                DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), false)
            };

        // Act
        var attributesList = new AttributesList(total, attributes);

        // Assert
        Assert.Equal(total, attributesList.Total);
        Assert.Equal(attributes, attributesList.Attributes);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var attributesList = JsonSerializer.Deserialize<AttributesList>(TestConstants.AttributesListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(attributesList);
        Assert.Equal(5, attributesList.Total);
        Assert.Single(attributesList.Attributes);

        var attribute = attributesList.Attributes[0];
        Assert.IsType<AttributeBoolean>(attribute);
        var attributeBoolean = (AttributeBoolean)attribute;
        Assert.Equal("isEnabled", attributeBoolean.Key);
        Assert.Equal("boolean", attributeBoolean.Type);
        Assert.Equal(DatabaseElementStatus.Available, attributeBoolean.Status);
        Assert.Equal("string", attributeBoolean.Error);
        Assert.True(attributeBoolean.Required);
        Assert.False(attributeBoolean.Array);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attributeBoolean.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), attributeBoolean.UpdatedAt.ToUniversalTime());
        Assert.False(attributeBoolean.Default);
    }
}
