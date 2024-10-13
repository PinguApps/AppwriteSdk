using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task CreateUserWithShaPassword_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateUserWithShaPasswordRequest
        {
            Email = "test@example.com",
            Password = "password123",
            PasswordVersion = "sha256"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/users/sha")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.CreateUserWithShaPassword(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateUserWithShaPassword_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateUserWithShaPasswordRequest
        {
            Email = "test@example.com",
            Password = "password123",
            PasswordVersion = "sha256"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/users/sha")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.CreateUserWithShaPassword(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateUserWithShaPassword_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateUserWithShaPasswordRequest
        {
            Email = "test@example.com",
            Password = "password123",
            PasswordVersion = "sha256"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/users/sha")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.CreateUserWithShaPassword(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
