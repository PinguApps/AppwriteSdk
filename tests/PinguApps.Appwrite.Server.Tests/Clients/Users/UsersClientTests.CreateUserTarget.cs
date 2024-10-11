using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task CreateUserTarget_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            ProviderType = Shared.Enums.TargetProviderType.Push,
            Identifier = "token"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/targets")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.TargetResponse);

        // Act
        var result = await _appwriteClient.Users.CreateUserTarget(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateUserTarget_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            ProviderType = Shared.Enums.TargetProviderType.Push,
            Identifier = "token"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/targets")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.CreateUserTarget(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateUserTarget_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            ProviderType = Shared.Enums.TargetProviderType.Push,
            Identifier = "token"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/targets")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.CreateUserTarget(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
