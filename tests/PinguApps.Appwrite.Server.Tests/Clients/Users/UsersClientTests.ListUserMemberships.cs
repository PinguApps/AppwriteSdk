using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task ListUserMemberships_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new ListUserMembershipsRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/memberships")
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.MembershipsListResponse);

        // Act
        var result = await _appwriteClient.Users.ListUserMemberships(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListUserMemberships_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListUserMembershipsRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/memberships")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.ListUserMemberships(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListUserMemberships_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListUserMembershipsRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/memberships")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.ListUserMemberships(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
