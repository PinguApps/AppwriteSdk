using System.Net;
using PinguApps.Appwrite.Server.Tests.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreatePhoneToken_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreatePhoneTokenRequest()
        {
            UserId = "123456",
            PhoneNumber = "+16175551212"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/tokens/phone")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.TokenResponse);

        // Act
        var result = await _appwriteServer.Account.CreatePhoneToken(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreatePhoneToken_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreatePhoneTokenRequest()
        {
            UserId = "123456",
            PhoneNumber = "+16175551212"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/tokens/phone")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteServer.Account.CreatePhoneToken(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreatePhoneToken_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreatePhoneTokenRequest()
        {
            UserId = "123456",
            PhoneNumber = "+16175551212"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account/tokens/phone")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteServer.Account.CreatePhoneToken(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
