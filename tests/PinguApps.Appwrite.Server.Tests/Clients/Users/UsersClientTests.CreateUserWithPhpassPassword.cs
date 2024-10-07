using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task CreateUserWithPhpassPassword_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateUserWithPhpassPasswordRequest
        {
            Email = "test@example.com",
            Password = "password123"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/phpass")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.CreateUserWithPhpassPassword(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateUserWithPhpassPassword_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateUserWithPhpassPasswordRequest
        {
            Email = "test@example.com",
            Password = "password123"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/phpass")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.CreateUserWithPhpassPassword(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateUserWithPhpassPassword_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateUserWithPhpassPasswordRequest
        {
            Email = "test@example.com",
            Password = "password123"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/phpass")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.CreateUserWithPhpassPassword(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
