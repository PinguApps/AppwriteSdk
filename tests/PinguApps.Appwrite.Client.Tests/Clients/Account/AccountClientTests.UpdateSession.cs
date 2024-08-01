using System.Net;
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
        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Respond(Constants.AppJson, Constants.UserResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateSession();

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var sessionId = IdUtils.GenerateUniqueId();

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/sessions/{sessionId}")
            .ExpectedHeaders(true)
            .Respond(Constants.AppJson, Constants.UserResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateSession(sessionId);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateSession();

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdateSession();

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
