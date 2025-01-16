using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Clients;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Tests;
using Refit;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    private readonly MockHttpMessageHandler _mockHttp;
    private readonly IServerAppwriteClient _appwriteClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public DatabasesClientTests()
    {
        _mockHttp = new MockHttpMessageHandler();
        var services = new ServiceCollection();

        services.AddAppwriteServer(TestConstants.ProjectId, TestConstants.ApiKey, TestConstants.Endpoint, x =>
        {
            x.RetryCount = 0;
            x.CircuitBreakerThreshold = 999;
        }, new RefitSettings
        {
            HttpMessageHandlerFactory = () => _mockHttp
        });

        var serviceProvider = services.BuildServiceProvider();

        _appwriteClient = serviceProvider.GetRequiredService<IServerAppwriteClient>();

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        _jsonSerializerOptions.Converters.Add(new IgnoreSdkExcludedPropertiesConverterFactory());
    }

    public class TestData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "Unset";

        [JsonPropertyName("age")]
        public int Age { get; set; } = 0;
    }

    public class TestDataResponse : TestData
    {
    }
}
