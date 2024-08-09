using System.Net;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task DeleteAuthenticator_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest()
        {
            Otp = "123456"
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.MfaTypeResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteAuthenticator(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task DeleteAuthenticator_ShouldHitDifferentEndpoint_WhenNewTypeIsUsed()
    {
        // Arrange
        var type = "newAuth";
        var request = new DeleteAuthenticatorRequest()
        {
            Type = type,
            Otp = "123456"
        };
        var requestUri = $"{Constants.Endpoint}/account/mfa/authenticators/{type}";
        var mockRequest = _mockHttp.Expect(HttpMethod.Delete, requestUri)
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.MfaTypeResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteAuthenticator(request);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
        var matches = _mockHttp.GetMatchCount(mockRequest);
        Assert.Equal(1, matches);
    }

    [Fact]
    public async Task DeleteAuthenticator_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest()
        {
            Otp = "123456"
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteAuthenticator(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task DeleteAuthenticator_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new DeleteAuthenticatorRequest()
        {
            Otp = "123456"
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteAuthenticator(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
