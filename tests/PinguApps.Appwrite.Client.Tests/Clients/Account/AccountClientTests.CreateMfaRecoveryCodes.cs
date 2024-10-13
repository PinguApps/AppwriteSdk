using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task CreateMfaRecoveryCodes_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/mfa/recovery-codes")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.JwtResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.CreateMfaRecoveryCodes();

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateMfaRecoveryCodes_ShouldReturnError_WhenSessionIsNull()
    {
        // Act
        var result = await _appwriteClient.Account.CreateMfaRecoveryCodes();

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task CreateMfaRecoveryCodes_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/mfa/recovery-codes")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.CreateMfaRecoveryCodes();

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateMfaRecoveryCodes_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/account/mfa/recovery-codes")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.CreateMfaRecoveryCodes();

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
