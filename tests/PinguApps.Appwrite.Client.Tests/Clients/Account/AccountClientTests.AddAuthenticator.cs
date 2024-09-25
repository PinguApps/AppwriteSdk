using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task AddAuthenticator_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new AddAuthenticatorRequest();

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .ExpectedHeaders(true)
            .Respond(Constants.AppJson, Constants.MfaTypeResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.AddAuthenticator(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task AddAuthenticator_ShouldHitDifferentEndpoint_WhenNewTypeIsUsed()
    {
        // Arrange
        var type = "newAuth";
        var request = new AddAuthenticatorRequest()
        {
            Type = type
        };
        var requestUri = $"{Constants.Endpoint}/account/mfa/authenticators/{type}";
        var mockRequest = _mockHttp.Expect(HttpMethod.Post, requestUri)
            .ExpectedHeaders(true)
            .Respond(Constants.AppJson, Constants.MfaTypeResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.AddAuthenticator(request);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
        var matches = _mockHttp.GetMatchCount(mockRequest);
        Assert.Equal(1, matches);
    }

    [Fact]
    public async Task AddAuthenticator_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new AddAuthenticatorRequest();

        // Act
        var result = await _appwriteClient.Account.AddAuthenticator(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task AddAuthenticator_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new AddAuthenticatorRequest();

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.AddAuthenticator(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task AddAuthenticator_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new AddAuthenticatorRequest();

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.AddAuthenticator(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
