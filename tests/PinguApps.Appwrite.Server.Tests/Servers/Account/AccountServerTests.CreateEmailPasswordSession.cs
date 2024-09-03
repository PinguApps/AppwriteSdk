﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountServerTests
{
    [Fact]
    public async Task CreateEmailPasswordSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateEmailPasswordSessionRequest()
        {
            Email = "email@example.com",
            Password = "Password"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/sessions/email")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.SessionResponse);

        // Act
        var result = await _appwriteServer.Account.CreateEmailPasswordSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateEmailPasswordSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateEmailPasswordSessionRequest()
        {
            Email = "email@example.com",
            Password = "Password"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/sessions/email")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteServer.Account.CreateEmailPasswordSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateEmailPasswordSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateEmailPasswordSessionRequest()
        {
            Email = "email@example.com",
            Password = "Password"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/sessions/email")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteServer.Account.CreateEmailPasswordSession(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
