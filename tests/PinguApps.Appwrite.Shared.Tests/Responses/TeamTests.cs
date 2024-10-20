using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class TeamTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var id = IdUtils.GenerateUniqueId();
        var createdAt = DateTime.UtcNow;
        var updatedAt = DateTime.UtcNow;
        var name = "Development Team";
        var total = 10;
        var prefs = new Dictionary<string, string> { { "theme", "dark" } };

        // Act
        var team = new Team(id, createdAt, updatedAt, name, total, prefs);

        // Assert
        Assert.Equal(id, team.Id);
        Assert.Equal(createdAt.ToUniversalTime(), team.CreatedAt.ToUniversalTime());
        Assert.Equal(updatedAt.ToUniversalTime(), team.UpdatedAt.ToUniversalTime());
        Assert.Equal(name, team.Name);
        Assert.Equal(total, team.Total);
        Assert.Equal(prefs, team.Prefs);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var team = JsonSerializer.Deserialize<Team>(TestConstants.TeamResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(team);
        Assert.Equal("5e5ea5c16897e", team.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), team.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), team.UpdatedAt.ToUniversalTime());
        Assert.Equal("VIP", team.Name);
        Assert.Equal(7, team.Total);
        Assert.Empty(team.Prefs);
    }
}
