﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreatePasswordRecoveryConfirmation_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreatePasswordRecoveryConfirmationRequest()
        {
            UserId = "userId",
            Secret = "secret",
            Password = "password"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/recovery")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.TokenResponse);

        // Act
        var result = await _appwriteClient.Account.CreatePasswordRecoveryConfirmation(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreatePasswordRecoveryConfirmation_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreatePasswordRecoveryConfirmationRequest()
        {
            UserId = "userId",
            Secret = "secret",
            Password = "password"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/recovery")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Account.CreatePasswordRecoveryConfirmation(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreatePasswordRecoveryConfirmation_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreatePasswordRecoveryConfirmationRequest()
        {
            UserId = "userId",
            Secret = "secret",
            Password = "password"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/recovery")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Account.CreatePasswordRecoveryConfirmation(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
