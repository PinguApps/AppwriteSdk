using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Client.Handlers;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Shared.Tests;

namespace PinguApps.Appwrite.Client.Tests;
public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddAppwriteClient_RegistersExpectedServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddAppwriteClient(TestConstants.ProjectId, TestConstants.Endpoint);

        // Assert
        var provider = services.BuildServiceProvider();

        var headerHandler = provider.GetService<HeaderHandler>();
        Assert.NotNull(headerHandler);

        var clientCookieSessionHandler = provider.GetService<ClientCookieSessionHandler>();
        Assert.NotNull(clientCookieSessionHandler);

        var accountApi = provider.GetService<IAccountApi>();
        Assert.NotNull(accountApi);

        Assert.NotNull(provider.GetService<IAccountClient>());
        Assert.NotNull(provider.GetService<IAppwriteClient>());

        var lazyClient = provider.GetService<Lazy<IAppwriteClient>>();
        Assert.NotNull(lazyClient);
        var client = lazyClient.Value;
        Assert.NotNull(client);
    }

    [Fact]
    public void AddAppwriteClientForServer_RegistersExpectedServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddAppwriteClientForServer(TestConstants.ProjectId, TestConstants.Endpoint);

        // Assert
        var provider = services.BuildServiceProvider();

        var headerHandler = provider.GetService<HeaderHandler>();
        Assert.NotNull(headerHandler);

        var clientCookieSessionHandler = provider.GetService<ClientCookieSessionHandler>();
        Assert.Null(clientCookieSessionHandler);

        var accountApi = provider.GetService<IAccountApi>();
        Assert.NotNull(accountApi);

        Assert.NotNull(provider.GetService<IAccountClient>());
        Assert.NotNull(provider.GetService<IAppwriteClient>());
    }
}
