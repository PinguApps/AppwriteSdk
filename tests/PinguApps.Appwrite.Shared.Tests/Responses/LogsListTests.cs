using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class LogsListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var logEvent = "account.sessions.create";
        var userId = "610fc2f985ee0";
        var userEmail = "john@appwrite.io";
        var userName = "John Doe";
        var mode = "admin";
        var ip = "127.0.0.1";
        var time = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
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

        // Act
        var logModel = new LogModel(logEvent, userId, userEmail, userName, mode, ip, time, osCode, osName, osVersion, clientType, clientCode,
            clientName, clientVersion, clientEngine, clientEngineVersion, deviceName, deviceBrand, deviceModel, countryCode, countryName);
        var logsList = new LogsList(total, [logModel]);

        // Assert
        Assert.Equal(total, logsList.Total);
        Assert.Single(logsList.Logs);
        Assert.Equal(logModel, logsList.Logs[0]);
        Assert.Equal(logEvent, logModel.Event);
        Assert.Equal(userId, logModel.UserId);
        Assert.Equal(userEmail, logModel.UserEmail);
        Assert.Equal(userName, logModel.UserName);
        Assert.Equal(mode, logModel.Mode);
        Assert.Equal(ip, logModel.Ip);
        Assert.Equal(time, logModel.Time);
        Assert.Equal(osCode, logModel.OsCode);
        Assert.Equal(osName, logModel.OsName);
        Assert.Equal(osVersion, logModel.OsVersion);
        Assert.Equal(clientType, logModel.ClientType);
        Assert.Equal(clientCode, logModel.ClientCode);
        Assert.Equal(clientName, logModel.ClientName);
        Assert.Equal(clientVersion, logModel.ClientVersion);
        Assert.Equal(clientEngine, logModel.ClientEngine);
        Assert.Equal(clientEngineVersion, logModel.ClientEngineVersion);
        Assert.Equal(deviceName, logModel.DeviceName);
        Assert.Equal(deviceBrand, logModel.DeviceBrand);
        Assert.Equal(deviceModel, logModel.DeviceModel);
        Assert.Equal(countryCode, logModel.CountryCode);
        Assert.Equal(countryName, logModel.CountryName);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var logsList = JsonSerializer.Deserialize<LogsList>(Constants.LogsListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(logsList);
        Assert.Equal(5, logsList.Total);
        Assert.Single(logsList.Logs);

        var logModel = logsList.Logs[0];
        Assert.Equal("account.sessions.create", logModel.Event);
        Assert.Equal("610fc2f985ee0", logModel.UserId);
        Assert.Equal("john@appwrite.io", logModel.UserEmail);
        Assert.Equal("John Doe", logModel.UserName);
        Assert.Equal("admin", logModel.Mode);
        Assert.Equal("127.0.0.1", logModel.Ip);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), logModel.Time.ToUniversalTime());
        Assert.Equal("Mac", logModel.OsCode);
        Assert.Equal("Mac", logModel.OsName);
        Assert.Equal("Mac", logModel.OsVersion);
        Assert.Equal("browser", logModel.ClientType);
        Assert.Equal("CM", logModel.ClientCode);
        Assert.Equal("Chrome Mobile iOS", logModel.ClientName);
        Assert.Equal("84.0", logModel.ClientVersion);
        Assert.Equal("WebKit", logModel.ClientEngine);
        Assert.Equal("605.1.15", logModel.ClientEngineVersion);
        Assert.Equal("smartphone", logModel.DeviceName);
        Assert.Equal("Google", logModel.DeviceBrand);
        Assert.Equal("Nexus 5", logModel.DeviceModel);
        Assert.Equal("US", logModel.CountryCode);
        Assert.Equal("United States", logModel.CountryName);
    }
}
