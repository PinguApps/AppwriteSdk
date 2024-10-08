﻿using Microsoft.Extensions.DependencyInjection;
using Moq;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Tests;
using Refit;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    private readonly MockHttpMessageHandler _mockHttp;
    private readonly IAppwriteClient _appwriteClient;

    public AccountClientTests()
    {
        _mockHttp = new MockHttpMessageHandler();
        var services = new ServiceCollection();

        services.AddAppwriteClientForServer("PROJECT_ID", Constants.Endpoint, new RefitSettings
        {
            HttpMessageHandlerFactory = () => _mockHttp
        });

        var serviceProvider = services.BuildServiceProvider();

        _appwriteClient = serviceProvider.GetRequiredService<IAppwriteClient>();
    }

    [Fact]
    public void SetSession_UpdatesSession()
    {
        // Arrange
        var sc = new ServiceCollection();
        var mockAccountApi = new Mock<IAccountApi>();
        sc.AddSingleton(mockAccountApi.Object);
        var sp = sc.BuildServiceProvider();
        var accountClient = new AccountClient(sp, new Config(Constants.Endpoint, Constants.ProjectId));
        var sessionAware = accountClient as ISessionAware;

        // Act
        sessionAware.UpdateSession(Constants.Session);

        // Assert
        Assert.Equal(Constants.Session, accountClient.Session);
    }
}
