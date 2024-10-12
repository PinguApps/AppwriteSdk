using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task CreateToken_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateTokenRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            // Add other properties as needed
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/tokens")
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.TokenResponse);

        // Act
        var result = await _appwriteClient.Users.CreateToken(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateToken_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateTokenRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            // Add other properties as needed
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/tokens")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.CreateToken(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateToken_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateTokenRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            // Add other properties as needed
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/tokens")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.CreateToken(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
