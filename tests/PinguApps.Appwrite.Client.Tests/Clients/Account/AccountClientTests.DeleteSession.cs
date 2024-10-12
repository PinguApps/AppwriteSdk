using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task DeleteSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new DeleteSessionRequest();

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.NoContent);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task DeleteSession_ShouldHitDifferentEndpoint_WhenNewTypeIsUsed()
    {
        // Arrange
        var sessionId = "mySessionId";
        var request = new DeleteSessionRequest()
        {
            SessionId = sessionId
        };
        var requestUri = $"{TestConstants.Endpoint}/account/sessions/{sessionId}";
        var mockRequest = _mockHttp.Expect(HttpMethod.Delete, requestUri)
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.NoContent);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteSession(request);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
        var matches = _mockHttp.GetMatchCount(mockRequest);
        Assert.Equal(1, matches);
    }

    [Fact]
    public async Task DeleteSession_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new DeleteSessionRequest();

        // Act
        var result = await _appwriteClient.Account.DeleteSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task DeleteSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new DeleteSessionRequest();

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task DeleteSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new DeleteSessionRequest();

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/account/sessions/current")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteSession(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
