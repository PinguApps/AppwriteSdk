using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task UpdateMfa_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateMfaRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Mfa = true
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.UpdateMfa(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateMfa_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateMfaRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Mfa = true
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.UpdateMfa(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateMfa_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateMfaRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Mfa = true
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.UpdateMfa(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
