using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task UpdatePassword_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdatePasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Password = "newPassword"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/password")
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.UpdatePassword(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdatePassword_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdatePasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Password = "newPassword"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/password")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.UpdatePassword(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdatePassword_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdatePasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Password = "newPassword"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/password")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.UpdatePassword(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
