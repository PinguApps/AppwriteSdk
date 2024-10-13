using System.Net;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreateEmailToken_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateEmailTokenRequest()
        {
            UserId = "123456",
            Email = "email@example.com"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/tokens/email")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.TokenResponse);

        // Act
        var result = await _appwriteClient.Account.CreateEmailToken(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateEmailToken_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateEmailTokenRequest()
        {
            UserId = "123456",
            Email = "email@example.com"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/tokens/email")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Account.CreateEmailToken(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateEmailToken_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateEmailTokenRequest()
        {
            UserId = "123456",
            Email = "email@example.com"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/tokens/email")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Account.CreateEmailToken(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
