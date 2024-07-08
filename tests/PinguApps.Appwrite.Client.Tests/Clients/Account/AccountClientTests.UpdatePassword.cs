using System.Net;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task UpdatePassword_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdatePasswordRequest()
        {
            OldPassword = "oldPassword",
            NewPassword = "newPassword"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/password")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.UserResponse);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdatePassword(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdatePassword_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdatePasswordRequest()
        {
            OldPassword = "oldPassword",
            NewPassword = "newPassword"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/password")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdatePassword(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdatePassword_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdatePasswordRequest()
        {
            OldPassword = "oldPassword",
            NewPassword = "newPassword"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/account/password")
            .ExpectedHeaders(true)
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.UpdatePassword(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
