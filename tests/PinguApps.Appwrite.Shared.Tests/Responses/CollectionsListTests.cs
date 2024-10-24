using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;
using Index = PinguApps.Appwrite.Shared.Responses.Index;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class CollectionsListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var collections = new List<Collection>
            {
                new Collection(
                    "5e5ea5c16897e",
                    DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(),
                    DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(),
                    new List<string> { "read(\"any\")" },
                    "5e5ea5c16897e",
                    "My Collection",
                    false,
                    true,
                    new List<Attribute>
                    {
                        new AttributeBoolean("isEnabled", "boolean", DatabaseElementStatus.Available, "string", true, false, DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), false)
                    },
                    new List<Index>
                    {
                        new Index("index1", IndexType.Unique, DatabaseElementStatus.Available, "string", new List<string>(), new List<string>(), DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime())
                    }
                )
            };

        // Act
        var collectionsList = new CollectionsList(total, collections);

        // Assert
        Assert.Equal(total, collectionsList.Total);
        Assert.Equal(collections, collectionsList.Collections);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var collectionsList = JsonSerializer.Deserialize<CollectionsList>(TestConstants.CollectionsListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(collectionsList);
        Assert.Equal(5, collectionsList.Total);
        Assert.Single(collectionsList.Collections);
        var collection = collectionsList.Collections[0];
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
