using System.Net;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task GetAccountPreferences_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/account/prefs")
            .ExpectedHeaders(true)
            .Respond(Constants.AppJson, Constants.PreferencesResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.GetAccountPreferences();

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task GetAccountPreferences_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/account/prefs")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.GetAccountPreferences();

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task GetAccountPreferences_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/account/prefs")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.GetAccountPreferences();

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
