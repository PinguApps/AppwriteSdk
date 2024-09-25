﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountServerTests
{
    [Fact]
    public async Task Create_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateAccountRequest()
        {
            Email = "email@example.com",
            Password = "password",
            Name = "name"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.UserResponse);

        // Act
        var result = await _appwriteServer.Account.Create(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task Create_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateAccountRequest()
        {
            Email = "email@example.com",
            Password = "password",
            Name = "name"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteServer.Account.Create(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task Create_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateAccountRequest()
        {
            Email = "email@example.com",
            Password = "password",
            Name = "name"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteServer.Account.Create(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
