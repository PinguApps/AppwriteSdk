using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task RegenerateMfaRecoveryCodes_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new RegenerateMfaRecoveryCodesRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa/recovery-codes")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.MfaRecoveryCodesResponse);

        // Act
        var result = await _appwriteClient.Users.RegenerateMfaRecoveryCodes(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task RegenerateMfaRecoveryCodes_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new RegenerateMfaRecoveryCodesRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa/recovery-codes")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.RegenerateMfaRecoveryCodes(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task RegenerateMfaRecoveryCodes_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new RegenerateMfaRecoveryCodesRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/users/{request.UserId}/mfa/recovery-codes")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.RegenerateMfaRecoveryCodes(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
