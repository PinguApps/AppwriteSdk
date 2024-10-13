using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task UpdateUserPreferences_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateUserPreferencesRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Preferences = new Dictionary<string, string>
            {
                { "theme", "dark" },
                { "notifications", "enabled" }
            }
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/prefs")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.PreferencesResponse);

        // Act
        var result = await _appwriteClient.Users.UpdateUserPreferences(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateUserPreferences_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateUserPreferencesRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Preferences = new Dictionary<string, string>
            {
                { "theme", "dark" },
                { "notifications", "enabled" }
            }
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/prefs")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.UpdateUserPreferences(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateUserPreferences_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateUserPreferencesRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Preferences = new Dictionary<string, string>
            {
                { "theme", "dark" },
                { "notifications", "enabled" }
            }
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/users/{request.UserId}/prefs")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.UpdateUserPreferences(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
