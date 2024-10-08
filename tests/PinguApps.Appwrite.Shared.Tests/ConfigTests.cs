﻿namespace PinguApps.Appwrite.Shared.Tests;
public class ConfigTests
{
    [Fact]
    public void Config_ShouldInitializeProperties()
    {
        // Arrange
        var endpoint = "https://example.com";
        var projectId = "project123";
        var apiKey = "myKey";

        // Act
        var config = new Config(endpoint, projectId, apiKey);

        // Assert
        Assert.Equal(endpoint, config.Endpoint);
        Assert.Equal(projectId, config.ProjectId);
        Assert.Equal(apiKey, config.ApiKey);
    }
}
