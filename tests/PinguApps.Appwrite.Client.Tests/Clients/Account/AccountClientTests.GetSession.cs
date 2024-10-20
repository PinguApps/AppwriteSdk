﻿using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task GetSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new GetSessionRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.GetSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task GetSession_ShouldRequestSession_WhenSessionProvided()
    {
        // Arrange
        var request = new GetSessionRequest()
        {
            SessionId = "123456"
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/account/sessions/{request.SessionId}")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.GetSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task GetSession_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new GetSessionRequest();

        // Act
        var result = await _appwriteClient.Account.GetSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task GetSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new GetSessionRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.GetSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task GetSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new GetSessionRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.GetSession(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
