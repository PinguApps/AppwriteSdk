﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Theory]
    [InlineData("user123")]
    [InlineData("user456")]
    public async Task GetUser_ShouldReturnSuccess_WhenApiCallSucceeds(string userId)
    {
        // Arrange
        var request = new GetUserRequest
        {
            UserId = userId
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/users/{userId}")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.GetUser(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task GetUser_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new GetUserRequest
        {
            UserId = "user123"
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/users/user123")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.GetUser(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task GetUser_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new GetUserRequest
        {
            UserId = "user123"
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/users/user123")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.GetUser(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
