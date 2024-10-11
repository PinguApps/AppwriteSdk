using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task UpdateUserStatus_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateUserStatusRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Status = true
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/status")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.UpdateUserStatus(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateUserStatus_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateUserStatusRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Status = true
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/status")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.UpdateUserStatus(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateUserStatus_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateUserStatusRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Status = true
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/status")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.UpdateUserStatus(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
