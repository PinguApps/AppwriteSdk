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

public static class AccountTestsExtensions
{
    public static MockedRequest ExpectedHeaders(this MockedRequest request)
    {
        return request
            .WithHeaders("x-appwrite-project", Constants.ProjectId)
            .WithHeaders("x-appwrite-key", Constants.ApiKey)
            .WithHeaders("x-sdk-name", Constants.SdkName)
            .WithHeaders("x-sdk-platform", "server")
            .WithHeaders("x-sdk-language", Constants.SdkLanguage)
            .WithHeaders("x-sdk-version", Constants.SdkVersion)
            .WithHeaders("x-appwrite-response-format", Constants.AppwriteResponseFormat);
    }
}
