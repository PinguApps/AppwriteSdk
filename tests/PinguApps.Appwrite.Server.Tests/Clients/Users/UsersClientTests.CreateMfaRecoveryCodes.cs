using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task CreateMfaRecoveryCodes_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateMfaRecoveryCodesRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/mfa/recovery-codes")
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.MfaRecoveryCodesResponse);

        // Act
        var result = await _appwriteClient.Users.CreateMfaRecoveryCodes(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateMfaRecoveryCodes_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateMfaRecoveryCodesRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/mfa/recovery-codes")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.CreateMfaRecoveryCodes(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateMfaRecoveryCodes_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateMfaRecoveryCodesRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/mfa/recovery-codes")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.CreateMfaRecoveryCodes(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
