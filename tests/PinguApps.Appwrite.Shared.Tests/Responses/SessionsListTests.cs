﻿using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class SessionsListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var id = "5e5ea5c16897e";
        var createdAt = DateTime.UtcNow;
        var updatedAt = DateTime.UtcNow;
        var userId = "5e5bb8c16897e";
        var expiresAt = DateTime.UtcNow;
        var provider = "email";
        var providerUserId = "user@example.com";
        var providerAccessToken = "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3";
        var providerAccessTokenExpiry = DateTime.UtcNow;
        var ProviderRefreshToken = "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3";
        var ip = "127.0.0.1";
        var osCode = "Mac";
        var osName = "Mac";
        var osVersion = "Mac";
        var clientType = "browser";
        var clientCode = "CM";
        var clientName = "Chrome Mobile iOS";
        var clientVersion = "84.0";
        var clientEngine = "WebKit";
        var clientEngineVersion = "605.1.15";
        var deviceName = "smartphone";
        var deviceBrand = "Google";
        var deviceModel = "Nexus 5";
        var countryCode = "US";
        var countryName = "United States";
        var current = true;
        var factors = new List<string> { "email" };
        var secret = "5e5bb8c16897e";
        var mfaUpdatedAt = DateTime.UtcNow;

        // Act
        var session = new Session(id, createdAt, updatedAt, userId, expiresAt, provider, providerUserId, providerAccessToken,
            providerAccessTokenExpiry, ProviderRefreshToken, ip, osCode, osName, osVersion, clientType, clientCode, clientName,
            clientVersion, clientEngine, clientEngineVersion, deviceName, deviceBrand, deviceModel, countryCode, countryName,
            current, factors, secret, mfaUpdatedAt);

        var sessionsList = new SessionsList(total, [session]);

        // Assert
        Assert.Equal(total, sessionsList.Total);

        Assert.Single(sessionsList.Sessions);
        var extractedSession = sessionsList.Sessions[0];

        Assert.Equal(id, extractedSession.Id);
        Assert.Equal(createdAt.ToUniversalTime(), extractedSession.CreatedAt.ToUniversalTime());
        Assert.Equal(updatedAt.ToUniversalTime(), extractedSession.UpdatedAt.ToUniversalTime());
        Assert.Equal(userId, extractedSession.UserId);
        Assert.Equal(expiresAt.ToUniversalTime(), extractedSession.ExpiresAt.ToUniversalTime());
        Assert.Equal(provider, extractedSession.Provider);
        Assert.Equal(providerUserId, extractedSession.ProviderUserId);
        Assert.Equal(providerAccessToken, extractedSession.ProviderAccessToken);
        Assert.Equal(providerAccessTokenExpiry.ToUniversalTime(), extractedSession.ProviderAccessTokenExpiry?.ToUniversalTime());
        Assert.Equal(ProviderRefreshToken, extractedSession.ProviderRefreshToken);
        Assert.Equal(ip, extractedSession.Ip);
        Assert.Equal(osCode, extractedSession.OsCode);
        Assert.Equal(osName, extractedSession.OsName);
        Assert.Equal(osVersion, extractedSession.OsVersion);
        Assert.Equal(clientType, extractedSession.ClientType);
        Assert.Equal(clientCode, extractedSession.ClientCode);
        Assert.Equal(clientName, extractedSession.ClientName);
        Assert.Equal(clientVersion, extractedSession.ClientVersion);
        Assert.Equal(clientEngine, extractedSession.ClientEngine);
        Assert.Equal(clientEngineVersion, extractedSession.ClientEngineVersion);
        Assert.Equal(deviceName, extractedSession.DeviceName);
        Assert.Equal(deviceBrand, extractedSession.DeviceBrand);
        Assert.Equal(deviceModel, extractedSession.DeviceModel);
        Assert.Equal(countryCode, extractedSession.CountryCode);
        Assert.Equal(countryName, extractedSession.CountryName);
        Assert.Equal(current, extractedSession.Current);
        Assert.Equal(factors, extractedSession.Factors);
        Assert.Equal(secret, extractedSession.Secret);
        Assert.Equal(mfaUpdatedAt.ToUniversalTime(), extractedSession.MfaUpdatedAt?.ToUniversalTime());
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var sessionsList = JsonSerializer.Deserialize<SessionsList>(TestConstants.SessionsListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(sessionsList);
        Assert.Equal(5, sessionsList.Total);

        Assert.Single(sessionsList.Sessions);
        var session = sessionsList.Sessions[0];

        Assert.Equal("5e5ea5c16897e", session.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), session.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), session.UpdatedAt.ToUniversalTime());
        Assert.Equal("5e5bb8c16897e", session.UserId);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), session.ExpiresAt.ToUniversalTime());
        Assert.Equal("email", session.Provider);
        Assert.Equal("user@example.com", session.ProviderUserId);
        Assert.Equal("MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3", session.ProviderAccessToken);
        Assert.NotNull(session.ProviderAccessTokenExpiry);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), session.ProviderAccessTokenExpiry.Value.ToUniversalTime());
        Assert.Equal("MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3", session.ProviderRefreshToken);
        Assert.Equal("127.0.0.1", session.Ip);
        Assert.Equal("Mac", session.OsCode);
        Assert.Equal("Mac", session.OsName);
        Assert.Equal("Mac", session.OsVersion);
        Assert.Equal("browser", session.ClientType);
        Assert.Equal("CM", session.ClientCode);
        Assert.Equal("Chrome Mobile iOS", session.ClientName);
        Assert.Equal("84.0", session.ClientVersion);
        Assert.Equal("WebKit", session.ClientEngine);
        Assert.Equal("605.1.15", session.ClientEngineVersion);
        Assert.Equal("smartphone", session.DeviceName);
        Assert.Equal("Google", session.DeviceBrand);
        Assert.Equal("Nexus 5", session.DeviceModel);
        Assert.Equal("US", session.CountryCode);
        Assert.Equal("United States", session.CountryName);
        Assert.True(session.Current);
        Assert.Single(session.Factors);
        Assert.Equal("email", session.Factors[0]);
        Assert.Equal("5e5bb8c16897e", session.Secret);
        Assert.NotNull(session.MfaUpdatedAt);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), session.MfaUpdatedAt.Value.ToUniversalTime());
    }
}
