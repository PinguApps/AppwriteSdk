using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;
using Index = PinguApps.Appwrite.Shared.Responses.Index;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class CollectionTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var id = "5e5ea5c16897e";
        var createdAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var updatedAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var permissions = new List<string> { "read(\"any\")" };
        var databaseId = "5e5ea5c16897e";
        var name = "My Collection";
        var enabled = false;
        var documentSecurity = true;
        var attributes = new List<Attribute>
            {
                new AttributeBoolean("isEnabled", "boolean", DatabaseElementStatus.Available, "string", true, false, createdAt, updatedAt, false)
            };
        var indexes = new List<Index>
            {
                new Index("index1", IndexType.Unique, DatabaseElementStatus.Available, "string", new List<string>(), new List<string>(), createdAt, updatedAt)
            };

        // Act
        var collection = new Collection(id, createdAt, updatedAt, permissions, databaseId, name, enabled, documentSecurity, attributes, indexes);

        // Assert
        Assert.Equal(id, collection.Id);
        Assert.Equal(createdAt, collection.CreatedAt);
        Assert.Equal(updatedAt, collection.UpdatedAt);
        Assert.Equal(permissions, collection.Permissions);
        Assert.Equal(databaseId, collection.DatabaseId);
        Assert.Equal(name, collection.Name);
        Assert.Equal(enabled, collection.Enabled);
        Assert.Equal(documentSecurity, collection.DocumentSecurity);
        Assert.Equal(attributes, collection.Attributes);
        Assert.Equal(indexes, collection.Indexes);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var collection = JsonSerializer.Deserialize<Collection>(TestConstants.CollectionResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(collection);
        Assert.Equal("5e5ea5c16897e", collection.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), collection.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), collection.UpdatedAt.ToUniversalTime());
        Assert.Contains("read(\"any\")", collection.Permissions);
        Assert.Equal("5e5ea5c16897e", collection.DatabaseId);
        Assert.Equal("My Collection", collection.Name);
        Assert.False(collection.Enabled);
        Assert.True(collection.DocumentSecurity);
        Assert.Single(collection.Attributes);
        Assert.Single(collection.Indexes);
    }
}
