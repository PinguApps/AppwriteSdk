using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Tests;
using Refit;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    private readonly MockHttpMessageHandler _mockHttp;
    private readonly IAppwriteClient _appwriteClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public AccountClientTests()
    {
        _mockHttp = new MockHttpMessageHandler();
        var services = new ServiceCollection();

        services.AddAppwriteClientForServer(TestConstants.ProjectId, TestConstants.Endpoint, new RefitSettings
        {
            HttpMessageHandlerFactory = () => _mockHttp
        });

        var serviceProvider = services.BuildServiceProvider();

        _appwriteClient = serviceProvider.GetRequiredService<IAppwriteClient>();

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        _jsonSerializerOptions.Converters.Add(new IgnoreSdkExcludedPropertiesConverterFactory());
    }

    [Fact]
    public void SetSession_UpdatesSession()
    {
        // Arrange
        var sc = new ServiceCollection();
        var mockAccountApi = new Mock<IAccountApi>();
        sc.AddSingleton(mockAccountApi.Object);
        var sp = sc.BuildServiceProvider();
        var accountClient = new AccountClient(sp, new Config(TestConstants.Endpoint, TestConstants.ProjectId));
        var sessionAware = accountClient as ISessionAware;

        // Act
        sessionAware.UpdateSession(TestConstants.Session);

        // Assert
        Assert.Equal(TestConstants.Session, accountClient.Session);
    }
}
