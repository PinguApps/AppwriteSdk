using System.Net;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Teams;
public partial class TeamsClientTests
{
    [Fact]
    public async Task UpdateTeamMembershipStatus_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateTeamMembershipStatusRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Secret = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}/status")
            .ExpectedHeaders(false)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.MembershipResponse);

        // Act
        var result = await _appwriteClient.Teams.UpdateTeamMembershipStatus(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateTeamMembershipStatus_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateTeamMembershipStatusRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Secret = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}/status")
            .ExpectedHeaders(false)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Teams.UpdateTeamMembershipStatus(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateTeamMembershipStatus_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateTeamMembershipStatusRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Secret = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}/status")
            .ExpectedHeaders(false)
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Teams.UpdateTeamMembershipStatus(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
