using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Servers;
using PinguApps.Appwrite.Shared.Tests;
using Refit;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountServerTests
{
    private readonly MockHttpMessageHandler _mockHttp;
    private readonly IAppwriteServer _appwriteServer;

    public AccountServerTests()
    {
        _mockHttp = new MockHttpMessageHandler();
        var services = new ServiceCollection();

        services.AddAppwriteServer(Constants.ProjectId, Constants.ApiKey, Constants.Endpoint, new RefitSettings
        {
            HttpMessageHandlerFactory = () => _mockHttp
        });

        var serviceProvider = services.BuildServiceProvider();

        _appwriteServer = serviceProvider.GetRequiredService<IAppwriteServer>();
    }
}
