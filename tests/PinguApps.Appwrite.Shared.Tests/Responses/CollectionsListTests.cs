using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;
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
                    [Permission.Read().Any()],
                    "5e5ea5c16897e",
                    "My Collection",
                    false,
                    true,
                    [
                        new AttributeBoolean("isEnabled", "boolean", DatabaseElementStatus.Available, "string", true, false, DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), false)
                    ],
                    [
                        new Index("index1", IndexType.Unique, DatabaseElementStatus.Available, "string", new List<string>(), new List<string>(), DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime())
                    ]
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
        Assert.Single(collection.Permissions);
        Assert.Equal(PermissionType.Read, collection.Permissions[0].PermissionType);
        Assert.Equal(RoleType.Any, collection.Permissions[0].RoleType);
        Assert.Equal("5e5ea5c16897e", collection.DatabaseId);
        Assert.Equal("My Collection", collection.Name);
        Assert.False(collection.Enabled);
        Assert.True(collection.DocumentSecurity);
        Assert.Single(collection.Attributes);
        Assert.Single(collection.Indexes);
    }
}
