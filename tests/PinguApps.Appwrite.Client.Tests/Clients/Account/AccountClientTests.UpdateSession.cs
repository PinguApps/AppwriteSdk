using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task UpdateSession_HitsCurrent_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateSessionRequest();

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateSessionRequest
        {
            SessionId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/account/sessions/{request.SessionId}")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateSession_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new UpdateSessionRequest();

        // Act
        var result = await _appwriteClient.Account.UpdateSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task UpdateSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateSessionRequest();

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateSessionRequest();

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateSession(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
