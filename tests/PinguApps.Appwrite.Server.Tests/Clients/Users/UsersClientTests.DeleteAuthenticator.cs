using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task DeleteAuthenticator_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Type = "totp"
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa/authenticators/{request.Type}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.NoContent);

        // Act
        var result = await _appwriteClient.Users.DeleteAuthenticator(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task DeleteAuthenticator_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Type = "totp"
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa/authenticators/{request.Type}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.DeleteAuthenticator(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task DeleteAuthenticator_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Type = "totp"
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa/authenticators/{request.Type}")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.DeleteAuthenticator(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
