﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Clients;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Tests;
using Refit;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Teams;
public partial class TeamsClientTests
{
    private readonly MockHttpMessageHandler _mockHttp;
    private readonly IAppwriteClient _appwriteClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public TeamsClientTests()
    {
        _mockHttp = new MockHttpMessageHandler();
        var services = new ServiceCollection();

        services.AddAppwriteServer(TestConstants.ProjectId, TestConstants.ApiKey, TestConstants.Endpoint, new RefitSettings
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
}