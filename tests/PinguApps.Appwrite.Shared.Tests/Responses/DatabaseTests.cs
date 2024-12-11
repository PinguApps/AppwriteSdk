using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class DatabaseTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var id = "5e5ea5c16897e";
        var name = "My Database";
        var createdAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var updatedAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var enabled = false;

        // Act
        var database = new Database(id, name, createdAt, updatedAt, enabled);

        // Assert
        Assert.Equal(id, database.Id);
        Assert.Equal(name, database.Name);
        Assert.Equal(createdAt, database.CreatedAt);
        Assert.Equal(updatedAt, database.UpdatedAt);
        Assert.Equal(enabled, database.Enabled);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var database = JsonSerializer.Deserialize<Database>(TestConstants.DatabaseResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(database);
        Assert.Equal("5e5ea5c16897e", database.Id);
        Assert.Equal("My Database", database.Name);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), database.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), database.UpdatedAt.ToUniversalTime());
        Assert.False(database.Enabled);
    }
}
