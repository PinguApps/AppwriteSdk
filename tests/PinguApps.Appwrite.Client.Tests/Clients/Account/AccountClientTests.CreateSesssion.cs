﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreateSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateSessionRequest()
        {
            UserId = "123456",
            Secret = "654321"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/sessions/token")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.SessionResponse);

        // Act
        var result = await _appwriteClient.Account.CreateSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateSessionRequest()
        {
            UserId = "123456",
            Secret = "654321"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/sessions/token")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Account.CreateSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateSessionRequest()
        {
            UserId = "123456",
            Secret = "654321"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/sessions/token")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Account.CreateSession(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
