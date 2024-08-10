using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task ListFactors_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/account/mfa/factors")
            .ExpectedHeaders(true)
            .Respond(Constants.AppJson, Constants.LogsListResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.ListFactors();

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListFactors_ShouldReturnError_WhenSessionIsNull()
    {
        // Act
        var result = await _appwriteClient.Account.ListFactors();

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task ListFactors_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/account/mfa/factors")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.ListFactors();

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListFactors_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/account/mfa/factors")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.ListFactors();

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
