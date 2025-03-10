﻿using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task Create2faChallenge_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new Create2faChallengeRequest();

        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false));

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/mfa/challenge")
            .ExpectedHeaders(true)
            .WithJsonContent(request, options)
            .Respond(TestConstants.AppJson, TestConstants.MfaTypeResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.Create2faChallenge(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task Create2faChallenge_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new Create2faChallengeRequest();

        // Act
        var result = await _appwriteClient.Account.Create2faChallenge(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task Create2faChallenge_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new Create2faChallengeRequest();

        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false));

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/mfa/challenge")
            .ExpectedHeaders(true)
            .WithJsonContent(request, options)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.Create2faChallenge(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task Create2faChallenge_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new Create2faChallengeRequest();

        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false));

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/mfa/challenge")
            .ExpectedHeaders(true)
            .WithJsonContent(request, options)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.Create2faChallenge(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
