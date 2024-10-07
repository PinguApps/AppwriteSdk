﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task CreateUserWithArgon2Password_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateUserWithArgon2PasswordRequest
        {
            Email = "pingu@example.com",
            Password = "password",
            Name = "Pingu"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/argon2")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.CreateUserWithArgon2Password(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateUserWithArgon2Password_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateUserWithArgon2PasswordRequest
        {
            Email = "pingu@example.com",
            Password = "password",
            Name = "Pingu"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/argon2")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.CreateUserWithArgon2Password(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateUserWithArgon2Password_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateUserWithArgon2PasswordRequest
        {
            Email = "pingu@example.com",
            Password = "password",
            Name = "Pingu"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/argon2")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.CreateUserWithArgon2Password(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}