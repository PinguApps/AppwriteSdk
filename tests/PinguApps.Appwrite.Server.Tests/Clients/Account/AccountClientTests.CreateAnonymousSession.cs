﻿using System.Net;
using PinguApps.Appwrite.Server.Tests.Clients;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreateAnonymousSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/sessions/anonymous")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.SessionResponse);

        // Act
        var result = await _appwriteServer.Account.CreateAnonymousSession();

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateAnonymousSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/sessions/anonymous")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteServer.Account.CreateAnonymousSession();

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateAnonymousSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/sessions/anonymous")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteServer.Account.CreateAnonymousSession();

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
