﻿using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Clients;
using PinguApps.Appwrite.Server.Handlers;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Shared.Tests;

namespace PinguApps.Appwrite.Server.Tests;
public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddAppwriteServer_RegistersExpectedServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddAppwriteServer(TestConstants.ProjectId, TestConstants.ApiKey, TestConstants.Endpoint);

        // Assert
        var provider = services.BuildServiceProvider();

        // Assert HeaderHandler is registered
        var headerHandler = provider.GetService<HeaderHandler>();
        Assert.NotNull(headerHandler);

        // Assert IAccountApi is registered and configured
        var accountApi = provider.GetService<IAccountApi>();
        Assert.NotNull(accountApi);

        // Assert services are registered
        Assert.NotNull(provider.GetService<IServerAccountClient>());
        Assert.NotNull(provider.GetService<IServerUsersClient>());
        Assert.NotNull(provider.GetService<IServerAppwriteClient>());
    }

    // Additional tests can be added to verify different configurations or overloads of AddAppwriteServer
}
