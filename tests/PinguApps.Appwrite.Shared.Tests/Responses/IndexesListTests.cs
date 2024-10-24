using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using Index = PinguApps.Appwrite.Shared.Responses.Index;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class IndexesListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var indexes = new List<Index>
            {
                new Index(
                    "index1",
                    IndexType.Unique,
                    DatabaseElementStatus.Available,
                    "string",
                    new List<string>(),
                    new List<string>(),
                    DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(),
                    DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime()
                )
            };

        // Act
        var indexesList = new IndexesList(total, indexes);

        // Assert
        Assert.Equal(total, indexesList.Total);
        Assert.Equal(indexes, indexesList.Indexes);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var indexesList = JsonSerializer.Deserialize<IndexesList>(TestConstants.IndexesListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(indexesList);
        Assert.Equal(5, indexesList.Total);
        Assert.Single(indexesList.Indexes);
        var index = indexesList.Indexes[0];
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
