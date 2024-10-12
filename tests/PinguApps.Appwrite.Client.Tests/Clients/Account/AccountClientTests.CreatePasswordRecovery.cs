using System.Net;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreatePasswordRecovery_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreatePasswordRecoveryRequest()
        {
            Email = "pingu@example.com",
            Url = "https://localhost:1234/abc"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/recovery")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(TestConstants.AppJson, TestConstants.TokenResponse);

        // Act
        var result = await _appwriteClient.Account.CreatePasswordRecovery(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreatePasswordRecovery_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreatePasswordRecoveryRequest()
        {
            Email = "pingu@example.com",
            Url = "https://localhost:1234/abc"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/recovery")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Account.CreatePasswordRecovery(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreatePasswordRecovery_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreatePasswordRecoveryRequest()
        {
            Email = "pingu@example.com",
            Url = "https://localhost:1234/abc"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/recovery")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Account.CreatePasswordRecovery(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
