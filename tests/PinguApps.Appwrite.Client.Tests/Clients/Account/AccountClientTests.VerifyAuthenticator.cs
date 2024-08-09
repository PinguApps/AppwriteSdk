using System.Net;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task VerifyAuthenticator_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new VerifyAuthenticatorRequest
        {
            Otp = "123456"
        };
        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .WithJsonContent(request)
            .ExpectedHeaders(true)
            .Respond(Constants.AppJson, Constants.UserResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.VerifyAuthenticator(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task VerifyAuthenticator_ShouldHitDifferentEndpoint_WhenNewTypeIsUsed()
    {
        // Arrange
        var type = "newAuth";
        var requestUri = $"{Constants.Endpoint}/account/mfa/authenticators/{type}";
        var requestBody = new VerifyAuthenticatorRequest
        {
            Otp = "123456",
            Type = type
        };
        var request = _mockHttp.Expect(HttpMethod.Put, requestUri)
            .WithJsonContent(requestBody)
            .ExpectedHeaders(true)
            .Respond(Constants.AppJson, Constants.UserResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.VerifyAuthenticator(requestBody);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
        var matches = _mockHttp.GetMatchCount(request);
        Assert.Equal(1, matches);
    }

    [Fact]
    public async Task VerifyAuthenticator_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new VerifyAuthenticatorRequest
        {
            Otp = "123456"
        };
        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .WithJsonContent(request)
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.VerifyAuthenticator(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task VerifyAuthenticator_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new VerifyAuthenticatorRequest
        {
            Otp = "123456"
        };
        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/mfa/authenticators/totp")
            .WithJsonContent(request)
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.VerifyAuthenticator(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
