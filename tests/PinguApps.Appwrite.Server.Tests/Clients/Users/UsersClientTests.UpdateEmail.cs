using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Theory]
    [InlineData("user123", "newemail@example.com")]
    [InlineData("user456", "anotheremail@example.com")]
    public async Task UpdateEmail_ShouldReturnSuccess_WhenApiCallSucceeds(string userId, string newEmail)
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            UserId = userId,
            Email = newEmail
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{userId}/email")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.UpdateEmail(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateEmail_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            UserId = "user123",
            Email = "newemail@example.com"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/user123/email")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.UpdateEmail(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateEmail_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            UserId = "user123",
            Email = "newemail@example.com"
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/user123/email")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.UpdateEmail(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
