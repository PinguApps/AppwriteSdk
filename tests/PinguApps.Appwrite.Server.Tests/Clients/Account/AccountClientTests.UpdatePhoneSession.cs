using System.Net;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task UpdatePhoneSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdatePhoneSessionRequest()
        {
            UserId = "user123",
            Secret = "validSecret"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/sessions/phone")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.SessionResponse);

        // Act
        var result = await _appwriteServer.Account.UpdatePhoneSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdatePhoneSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdatePhoneSessionRequest()
        {
            UserId = "user123",
            Secret = "validSecret"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/sessions/phone")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteServer.Account.UpdatePhoneSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdatePhoneSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdatePhoneSessionRequest()
        {
            UserId = "user123",
            Secret = "validSecret"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{Constants.Endpoint}/account/sessions/phone")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteServer.Account.UpdatePhoneSession(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
