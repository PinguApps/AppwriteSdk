using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class TeamsListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 1;
        var id = IdUtils.GenerateUniqueId();
        var createdAt = DateTime.UtcNow;
        var updatedAt = DateTime.UtcNow;
        var name = "Development Team";
        var teamTotal = 10;
        var prefs = new Dictionary<string, string> { { "theme", "dark" } };

        var team = new Team(id, createdAt, updatedAt, name, teamTotal, prefs);
        var teamsList = new TeamsList(total, [team]);

        // Assert
        Assert.Equal(total, teamsList.Total);
        Assert.Single(teamsList.Teams);
        var extractedTeam = teamsList.Teams[0];

        Assert.Equal(id, extractedTeam.Id);
        Assert.Equal(createdAt.ToUniversalTime(), extractedTeam.CreatedAt.ToUniversalTime());
        Assert.Equal(updatedAt.ToUniversalTime(), extractedTeam.UpdatedAt.ToUniversalTime());
        Assert.Equal(name, extractedTeam.Name);
        Assert.Equal(teamTotal, extractedTeam.Total);
        Assert.Equal(prefs, extractedTeam.Prefs);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var teamsList = JsonSerializer.Deserialize<TeamsList>(TestConstants.TeamsListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(teamsList);
        Assert.Equal(5, teamsList.Total);
        Assert.Single(teamsList.Teams);
        var team = teamsList.Teams[0];

        Assert.Equal("5e5ea5c16897e", team.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), team.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), team.UpdatedAt.ToUniversalTime());
        Assert.Equal("VIP", team.Name);
        Assert.Equal(7, team.Total);
        Assert.Empty(team.Prefs);
    }
}
