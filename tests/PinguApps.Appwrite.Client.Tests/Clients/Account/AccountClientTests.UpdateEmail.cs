﻿using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task UpdateEmail_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateEmailRequest()
        {
            Email = "email@example.com",
            Password = "password"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/email")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.UserResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateEmail(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateEmail_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new UpdateEmailRequest()
        {
            Email = "email@example.com",
            Password = "password"
        };

        // Act
        var result = await _appwriteClient.Account.UpdateEmail(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task UpdateEmail_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateEmailRequest()
        {
            Email = "email@example.com",
            Password = "password"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/email")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateEmail(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateEmail_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateEmailRequest()
        {
            Email = "email@example.com",
            Password = "password"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/email")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateEmail(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
