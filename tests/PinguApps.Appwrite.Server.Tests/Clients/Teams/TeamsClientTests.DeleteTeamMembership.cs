﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Teams;
public partial class TeamsClientTests
{
    [Fact]
    public async Task DeleteTeamMembership_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new DeleteTeamMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.NoContent);

        // Act
        var result = await _appwriteClient.Teams.DeleteTeamMembership(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task DeleteTeamMembership_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new DeleteTeamMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Teams.DeleteTeamMembership(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task DeleteTeamMembership_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new DeleteTeamMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Teams.DeleteTeamMembership(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
