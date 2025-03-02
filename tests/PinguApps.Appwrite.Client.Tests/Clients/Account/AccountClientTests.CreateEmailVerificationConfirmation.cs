﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreateEmailVerificationConfirmation_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateEmailVerificationConfirmationRequest()
        {
            UserId = "123456",
            Secret = "654321"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/verification")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.TokenResponse);

        // Act
        var result = await _appwriteClient.Account.CreateEmailVerificationConfirmation(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateEmailVerificationConfirmation_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateEmailVerificationConfirmationRequest()
        {
            UserId = "123456",
            Secret = "654321"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/verification")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Account.CreateEmailVerificationConfirmation(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateEmailVerificationConfirmation_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateEmailVerificationConfirmationRequest()
        {
            UserId = "123456",
            Secret = "654321"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/verification")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Account.CreateEmailVerificationConfirmation(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
