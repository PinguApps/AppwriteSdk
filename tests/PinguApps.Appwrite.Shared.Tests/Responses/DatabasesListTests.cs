using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class DatabasesListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var databases = new List<Database>
            {
                new("5e5ea5c16897e", "My Database", DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), false)
            };

        // Act
        var databasesList = new DatabasesList(total, databases);

        // Assert
        Assert.Equal(total, databasesList.Total);
        Assert.Equal(databases, databasesList.Databases);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var databasesList = JsonSerializer.Deserialize<DatabasesList>(TestConstants.DatabasesListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(databasesList);
        Assert.Equal(5, databasesList.Total);
        Assert.Single(databasesList.Databases);

        var database = databasesList.Databases[0];
        Assert.Equal("5e5ea5c16897e", database.Id);
        Assert.Equal("My Database", database.Name);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), database.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), database.UpdatedAt.ToUniversalTime());
        Assert.False(database.Enabled);
    }
}
