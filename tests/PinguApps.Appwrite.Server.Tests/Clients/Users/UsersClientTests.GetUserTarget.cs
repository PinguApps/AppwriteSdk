using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task GetUserTarget_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new GetUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            TargetId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/users/{request.UserId}/targets/{request.TargetId}")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.TargetResponse);

        // Act
        var result = await _appwriteClient.Users.GetUserTarget(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task GetUserTarget_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new GetUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            TargetId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/users/{request.UserId}/targets/{request.TargetId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.GetUserTarget(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task GetUserTarget_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new GetUserTargetRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            TargetId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/users/{request.UserId}/targets/{request.TargetId}")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.GetUserTarget(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
