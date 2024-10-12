using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task UpdatePhone_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdatePhoneRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            PhoneNumber = "+1234567890"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/phone")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.UpdatePhone(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdatePhone_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdatePhoneRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            PhoneNumber = "+1234567890"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/phone")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.UpdatePhone(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdatePhone_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdatePhoneRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            PhoneNumber = "+1234567890"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/phone")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.UpdatePhone(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
