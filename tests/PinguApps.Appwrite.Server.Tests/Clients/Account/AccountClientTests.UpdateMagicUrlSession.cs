using System.Net;
using PinguApps.Appwrite.Server.Tests.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task UpdateMagicUrlSession_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateMagicUrlSessionRequest()
        {
            UserId = "user123",
            Secret = "validSecret"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/sessions/magic-url")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.SessionResponse);

        // Act
        var result = await _appwriteServer.Account.UpdateMagicUrlSession(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateMagicUrlSession_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateMagicUrlSessionRequest()
        {
            UserId = "user123",
            Secret = "validSecret"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/sessions/magic-url")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteServer.Account.UpdateMagicUrlSession(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateMagicUrlSession_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateMagicUrlSessionRequest()
        {
            UserId = "user123",
            Secret = "validSecret"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/sessions/magic-url")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteServer.Account.UpdateMagicUrlSession(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
