using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class TargetListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var id = "259125845563242502";
        var createdAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var updatedAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var name = "Aegon apple token";
        var userId = "259125845563242502";
        var providerId = "259125845563242502";
        var providerType = TargetProviderType.Email;
        var identifier = "token";

        // Act
        var target = new Target(id, createdAt, updatedAt, name, userId, providerId, providerType, identifier);
        var targetList = new TargetList(total, new List<Target> { target });

        // Assert
        Assert.Equal(total, targetList.Total);
        Assert.Single(targetList.Targets);
        var extractedTarget = targetList.Targets[0];

        Assert.Equal(id, extractedTarget.Id);
        Assert.Equal(createdAt, extractedTarget.CreatedAt);
        Assert.Equal(updatedAt, extractedTarget.UpdatedAt);
        Assert.Equal(name, extractedTarget.Name);
        Assert.Equal(userId, extractedTarget.UserId);
        Assert.Equal(providerId, extractedTarget.ProviderId);
        Assert.Equal(providerType, extractedTarget.ProviderType);
        Assert.Equal(identifier, extractedTarget.Identifier);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var targetList = JsonSerializer.Deserialize<TargetList>(Constants.TargetListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(targetList);
        Assert.Equal(5, targetList.Total);
        Assert.Single(targetList.Targets);
        var target = targetList.Targets[0];

        Assert.Equal("259125845563242502", target.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), target.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), target.UpdatedAt.ToUniversalTime());
        Assert.Equal("Aegon apple token", target.Name);
        Assert.Equal("259125845563242502", target.UserId);
        Assert.Equal("259125845563242502", target.ProviderId);
        Assert.Equal(TargetProviderType.Email, target.ProviderType);
        Assert.Equal("token", target.Identifier);
    }
}
