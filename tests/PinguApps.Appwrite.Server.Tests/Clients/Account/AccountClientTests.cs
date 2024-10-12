using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Clients;
using PinguApps.Appwrite.Shared.Tests;
using Refit;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountClientTests
{
    private readonly MockHttpMessageHandler _mockHttp;
    private readonly IAppwriteClient _appwriteServer;

    public AccountClientTests()
    {
        _mockHttp = new MockHttpMessageHandler();
        var services = new ServiceCollection();

        services.AddAppwriteServer(TestConstants.ProjectId, TestConstants.ApiKey, TestConstants.Endpoint, new RefitSettings
        {
            HttpMessageHandlerFactory = () => _mockHttp
        });

        var serviceProvider = services.BuildServiceProvider();

        _appwriteServer = serviceProvider.GetRequiredService<IAppwriteClient>();
    }
}
