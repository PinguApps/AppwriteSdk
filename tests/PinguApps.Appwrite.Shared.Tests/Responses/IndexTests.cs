using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using Index = PinguApps.Appwrite.Shared.Responses.Index;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class IndexTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var key = "index1";
        var type = IndexType.Unique;
        var status = DatabaseElementStatus.Available;
        var error = "string";
        var attributes = Array.Empty<string>();
        var orders = Array.Empty<string>();
        var createdAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var updatedAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();

        // Act
        var index = new Index(key, type, status, error, attributes, orders, createdAt, updatedAt);

        // Assert
        Assert.Equal(key, index.Key);
        Assert.Equal(type, index.Type);
        Assert.Equal(status, index.Status);
        Assert.Equal(error, index.Error);
        Assert.Equal(attributes, index.Attributes);
        Assert.Equal(orders, index.Orders);
        Assert.Equal(createdAt, index.CreatedAt);
        Assert.Equal(updatedAt, index.UpdatedAt);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var index = JsonSerializer.Deserialize<Index>(TestConstants.IndexResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(index);
        Assert.Equal("index1", index.Key);
        Assert.Equal(IndexType.Unique, index.Type);
        Assert.Equal(DatabaseElementStatus.Available, index.Status);
        Assert.Equal("string", index.Error);
        Assert.Empty(index.Attributes);
        Assert.Empty(index.Orders);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), index.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), index.UpdatedAt.ToUniversalTime());
    }
}
