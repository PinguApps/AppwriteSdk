using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class IdentityListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var id = "5e5ea5c16897e";
        var createdAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var updatedAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var userId = "5e5bb8c16897e";
        var provider = "email";
        var providerUid = "5e5bb8c16897e";
        var providerEmail = "user@example.com";
        var providerAccessToken = "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3";
        var providerAccessTokenExpiry = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var providerRefreshToken = "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3";

        // Act
        var identityModel = new IdentityModel(id, createdAt, updatedAt, userId, provider, providerUid, providerEmail, providerAccessToken, providerAccessTokenExpiry, providerRefreshToken);
        var identitiesList = new IdentitiesList(total, new List<IdentityModel> { identityModel });

        // Assert
        Assert.Equal(total, identitiesList.Total);
        Assert.Single(identitiesList.Identities);
        Assert.Equal(identityModel, identitiesList.Identities[0]);
        Assert.Equal(id, identityModel.Id);
        Assert.Equal(createdAt, identityModel.CreatedAt);
        Assert.Equal(updatedAt, identityModel.UpdatedAt);
        Assert.Equal(userId, identityModel.UserId);
        Assert.Equal(provider, identityModel.Provider);
        Assert.Equal(providerUid, identityModel.ProviderUid);
        Assert.Equal(providerEmail, identityModel.ProviderEmail);
        Assert.Equal(providerAccessToken, identityModel.ProviderAccessToken);
        Assert.Equal(providerAccessTokenExpiry, identityModel.ProviderAccessTokenExpiry);
        Assert.Equal(providerRefreshToken, identityModel.ProviderRefreshToken);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var identitiesList = JsonSerializer.Deserialize<IdentitiesList>(TestConstants.IdentitiesListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(identitiesList);
        Assert.Equal(5, identitiesList.Total);
        Assert.Single(identitiesList.Identities);

        var identityModel = identitiesList.Identities[0];
        Assert.Equal("5e5ea5c16897e", identityModel.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), identityModel.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), identityModel.UpdatedAt.ToUniversalTime());
        Assert.Equal("5e5bb8c16897e", identityModel.UserId);
        Assert.Equal("email", identityModel.Provider);
        Assert.Equal("5e5bb8c16897e", identityModel.ProviderUid);
        Assert.Equal("user@example.com", identityModel.ProviderEmail);
        Assert.Equal("MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3", identityModel.ProviderAccessToken);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), identityModel.ProviderAccessTokenExpiry.ToUniversalTime());
        Assert.Equal("MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3", identityModel.ProviderRefreshToken);
    }
}
