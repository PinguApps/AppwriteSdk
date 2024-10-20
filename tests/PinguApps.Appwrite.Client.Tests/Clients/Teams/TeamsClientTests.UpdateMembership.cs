using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Teams;
public partial class TeamsClientTests
{
    [Fact]
    public async Task UpdateMembership_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            // Add other necessary fields for the request
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.MembershipResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Teams.UpdateMembership(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateMembership_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new UpdateMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            // Add other necessary fields for the request
        };

        // Act
        var result = await _appwriteClient.Teams.UpdateMembership(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task UpdateMembership_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            // Add other necessary fields for the request
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Teams.UpdateMembership(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateMembership_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            MembershipId = IdUtils.GenerateUniqueId(),
            // Add other necessary fields for the request
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships/{request.MembershipId}")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Teams.UpdateMembership(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
