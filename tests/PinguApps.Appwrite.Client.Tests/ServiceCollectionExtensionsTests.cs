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
        services.AddAppwriteClient(Constants.ProjectId, Constants.Endpoint);

        // Assert
        var provider = services.BuildServiceProvider();

        // Assert HeaderHandler is registered
        var headerHandler = provider.GetService<HeaderHandler>();
        Assert.NotNull(headerHandler);

        // Assert IAccountApi is registered and configured
        var accountApi = provider.GetService<IAccountApi>();
        Assert.NotNull(accountApi);

        // Assert services are registered
        Assert.NotNull(provider.GetService<IAccountClient>());
        Assert.NotNull(provider.GetService<IAppwriteClient>());
    }

    [Fact]
    public void AddAppwriteClientForServer_RegistersExpectedServicesWithTransientLifetime()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddAppwriteClientForServer(Constants.ProjectId, Constants.Endpoint);

        // Assert
        var provider = services.BuildServiceProvider();

        // Assert HeaderHandler is registered
        var headerHandler = provider.GetService<HeaderHandler>();
        Assert.NotNull(headerHandler);

        // Assert IAccountApi is registered and configured
        var accountApi = provider.GetService<IAccountApi>();
        Assert.NotNull(accountApi);

        // Assert services are registered with Transient lifetime
        var accountClientServiceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IAccountClient));
        Assert.NotNull(accountClientServiceDescriptor);
        Assert.Equal(ServiceLifetime.Transient, accountClientServiceDescriptor.Lifetime);

        var appwriteClientServiceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IAppwriteClient));
        Assert.NotNull(appwriteClientServiceDescriptor);
        Assert.Equal(ServiceLifetime.Transient, appwriteClientServiceDescriptor.Lifetime);
    }
}
