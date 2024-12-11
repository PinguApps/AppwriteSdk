using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class DocumentTests
{
    [Fact]
    public void Document_ShouldBeDeserialized_FromJson()
    {
        var document = JsonSerializer.Deserialize<Document>(TestConstants.DocumentResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(document);
        Assert.Equal("5e5ea5c16897e", document.Id);
        Assert.Equal("5e5ea5c15117e", document.CollectionId);
        Assert.Equal("5e5ea5c15117e", document.DatabaseId);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), document.CreatedAt?.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), document.UpdatedAt?.ToUniversalTime());
        Assert.Single(document.Permissions);
        Assert.Equal(PermissionType.Read, document.Permissions[0].PermissionType);
        Assert.Equal(RoleType.Any, document.Permissions[0].RoleType);
        Assert.Equal("a string prop", document.Data["str"]);
        var dt = (DateTime?)document.Data["dt"];
        Assert.NotNull(dt);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), dt.Value.ToUniversalTime());
        Assert.Equal(5L, document.Data["num"]);
        var num2 = document.Data["num2"];
        Assert.IsType<float>(num2);
        Assert.Equal(6.7, (float)num2, 0.0001);
        Assert.Equal(true, document.Data["boo"]);
        Assert.Equal(new List<object> { "one", "two", "three" }, document.Data["lis"]);
    }

    [Fact]
    public void Indexer_ShouldReturnCorrectValue()
    {
        var data = new Dictionary<string, object?>
            {
                { "key1", "value1" },
                { "key2", 123 }
            };

        var document = new Document(
            "id",
            "collectionId",
            "databaseId",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            data
        );

        Assert.Equal("value1", document["key1"]);
        Assert.Equal(123, document["key2"]);
        Assert.Null(document["key3"]);
    }

    [Fact]
    public void GetValue_ShouldReturnCorrectValue()
    {
        var data = new Dictionary<string, object?>
            {
                { "key1", "value1" },
                { "key2", 123 }
            };

        var document = new Document(
            "id",
            "collectionId",
            "databaseId",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            data
        );

        Assert.Equal("value1", document.GetValue<string>("key1"));
        Assert.Equal(123, document.GetValue<int>("key2"));
    }

    [Fact]
    public void GetValue_ShouldThrowException_WhenKeyNotFound()
    {
        var document = new Document(
            "id",
            "collectionId",
            "databaseId",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            new Dictionary<string, object?>()
        );

        Assert.Throws<KeyNotFoundException>(() => document.GetValue<string>("key1"));
    }

    [Fact]
    public void GetValue_ShouldThrowException_WhenInvalidCast()
    {
        var data = new Dictionary<string, object?>
            {
                { "key1", "value1" }
            };

        var document = new Document(
            "id",
            "collectionId",
            "databaseId",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            data
        );

        Assert.Throws<InvalidCastException>(() => document.GetValue<int>("key1"));
    }

    [Fact]
    public void TryGetValue_ReturnsTrue_WhenKeyExistsAndTypeMatches()
    {
        // Arrange
        var data = new Dictionary<string, object?>
            {
                { "key1", "value1" },
                { "key2", 123 }
            };
        var document = new Document("id", "collectionId", "databaseId", DateTime.UtcNow, DateTime.UtcNow, [], data);

        // Act
        var result = document.TryGetValue("key1", out string? value);

        // Assert
        Assert.True(result);
        Assert.Equal("value1", value);
    }

    [Fact]
    public void TryGetValue_ReturnsFalse_WhenKeyDoesNotExist()
    {
        // Arrange
        var data = new Dictionary<string, object?>();
        var document = new Document("id", "collectionId", "databaseId", DateTime.UtcNow, DateTime.UtcNow, [], data);

        // Act
        var result = document.TryGetValue("nonexistentKey", out string? value);

        // Assert
        Assert.False(result);
        Assert.Null(value);
    }

    [Fact]
    public void TryGetValue_ReturnsFalse_WhenTypeDoesNotMatch()
    {
        // Arrange
        var data = new Dictionary<string, object?>
            {
                { "key1", "value1" }
            };
        var document = new Document("id", "collectionId", "databaseId", DateTime.UtcNow, DateTime.UtcNow, [], data);

        // Act
        var result = document.TryGetValue("key1", out int? value);

        // Assert
        Assert.False(result);
        Assert.Null(value);
    }

    [Fact]
    public void Document_ShouldContainUnmatchedProperties()
    {
        var document = JsonSerializer.Deserialize<Document>(TestConstants.DocumentResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(document);
        Assert.True(document.Data.ContainsKey("str"));
        Assert.True(document.Data.ContainsKey("dt"));
        Assert.True(document.Data.ContainsKey("num"));
        Assert.True(document.Data.ContainsKey("num2"));
        Assert.True(document.Data.ContainsKey("boo"));
        Assert.True(document.Data.ContainsKey("lis"));
    }
}
