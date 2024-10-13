using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task Create2faChallengeConfirmation_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new Create2faChallengeConfirmationRequest()
        {
            ChallengeId = IdUtils.GenerateUniqueId(),
            Otp = "123456"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/mfa/challenge")
            .ExpectedHeaders(true)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.NoContent);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.Create2faChallengeConfirmation(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task Create2faChallengeConfirmation_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new Create2faChallengeConfirmationRequest()
        {
            ChallengeId = IdUtils.GenerateUniqueId(),
            Otp = "123456"
        };

        // Act
        var result = await _appwriteClient.Account.Create2faChallengeConfirmation(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task Create2faChallengeConfirmation_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new Create2faChallengeConfirmationRequest()
        {
            ChallengeId = IdUtils.GenerateUniqueId(),
            Otp = "123456"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/mfa/challenge")
            .ExpectedHeaders(true)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.Create2faChallengeConfirmation(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task Create2faChallengeConfirmation_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new Create2faChallengeConfirmationRequest()
        {
            ChallengeId = IdUtils.GenerateUniqueId(),
            Otp = "123456"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/account/mfa/challenge")
            .ExpectedHeaders(true)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.Create2faChallengeConfirmation(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
