using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Clients;
using PinguApps.Appwrite.Shared.Tests;
using Refit;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    private readonly MockHttpMessageHandler _mockHttp;
    private readonly IAppwriteClient _appwriteClient;

    public UsersClientTests()
    {
        _mockHttp = new MockHttpMessageHandler();
        var services = new ServiceCollection();

        services.AddAppwriteServer(Constants.ProjectId, Constants.ApiKey, Constants.Endpoint, new RefitSettings
        {
            HttpMessageHandlerFactory = () => _mockHttp
        });

        var serviceProvider = services.BuildServiceProvider();

        _appwriteClient = serviceProvider.GetRequiredService<IAppwriteClient>();
    }
}
