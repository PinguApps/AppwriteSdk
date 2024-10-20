using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Teams;
public partial class TeamsClientTests
{
    [Fact]
    public async Task CreateTeam_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateTeamRequest
        {
            Name = "Test Team"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/teams")
            .ExpectedHeaders(true)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.TeamResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Teams.CreateTeam(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateTeam_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new CreateTeamRequest
        {
            Name = "Test Team"
        };

        // Act
        var result = await _appwriteClient.Teams.CreateTeam(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task CreateTeam_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateTeamRequest
        {
            Name = "Test Team"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/teams")
            .ExpectedHeaders(true)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Teams.CreateTeam(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateTeam_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateTeamRequest
        {
            Name = "Test Team"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/teams")
            .ExpectedHeaders(true)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Teams.CreateTeam(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
