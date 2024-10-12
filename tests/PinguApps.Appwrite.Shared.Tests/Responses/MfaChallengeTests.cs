using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class MfaChallengeTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var id = "bb8ea5c16897e";
        var createdAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00");
        var userId = "5e5ea5c168bb8";
        var expire = DateTime.Parse("2020-10-15T06:38:00.000+00:00");

        // Act
        var mfaType = new MfaChallenge(id, createdAt, userId, expire);

        // Assert
        Assert.Equal(id, mfaType.Id);
        Assert.Equal(createdAt, mfaType.CreatedAt);
        Assert.Equal(userId, mfaType.UserId);
        Assert.Equal(expire, mfaType.Expire);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var mfaType = JsonSerializer.Deserialize<MfaChallenge>(TestConstants.MfaChallengeResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(mfaType);
        Assert.Equal("bb8ea5c16897e", mfaType.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), mfaType.CreatedAt.ToUniversalTime());
        Assert.Equal("5e5ea5c168bb8", mfaType.UserId);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), mfaType.Expire.ToUniversalTime());
    }
}
