using System.Net;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Teams;
public partial class TeamsClientTests
{
    [Fact]
    public async Task CreateTeamMembership_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateTeamMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Email = "test@example.com",
            Roles = ["role1", "role2"]
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.MembershipResponse);

        // Act
        var result = await _appwriteClient.Teams.CreateTeamMembership(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateTeamMembership_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateTeamMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Email = "test@example.com",
            Roles = ["role1", "role2"]
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Teams.CreateTeamMembership(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateTeamMembership_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateTeamMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Email = "test@example.com",
            Roles = ["role1", "role2"]
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Teams.CreateTeamMembership(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
