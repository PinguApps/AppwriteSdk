using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreateEmailVerification_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateEmailVerificationRequest()
        {
            Url = "https://localhost:5001/abc123"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/verification")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(TestConstants.AppJson, TestConstants.TokenResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.CreateEmailVerification(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateEmailVerification_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new CreateEmailVerificationRequest()
        {
            Url = "https://localhost:5001/abc123"
        };

        // Act
        var result = await _appwriteClient.Account.CreateEmailVerification(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task CreateEmailVerification_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateEmailVerificationRequest()
        {
            Url = "https://localhost:5001/abc123"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/verification")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.CreateEmailVerification(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateEmailVerification_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateEmailVerificationRequest()
        {
            Url = "https://localhost:5001/abc123"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/verification")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.CreateEmailVerification(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
