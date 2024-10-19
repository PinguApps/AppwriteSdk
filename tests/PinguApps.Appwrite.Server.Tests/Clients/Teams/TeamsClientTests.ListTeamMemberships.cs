using System.Net;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Teams;
public partial class TeamsClientTests
{
    [Fact]
    public async Task ListTeamMemberships_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new ListTeamMembershipsRequest
        {
            TeamId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.MembershipsListResponse);

        // Act
        var result = await _appwriteClient.Teams.ListTeamMemberships(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListTeamMemberships_ShouldProvideQueryParams_WhenQueriesAndSearchProvided()
    {
        // Arrange
        var query = Query.Limit(5);
        var search = "SearchString";
        var request = new ListTeamMembershipsRequest
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Queries = [query],
            Search = search
        };

        var expectedQueryParams = new Dictionary<string, string>
        {
            { "queries[]", query.GetQueryString() },
            { "search", search }
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}&search={search}")
            .Respond(TestConstants.AppJson, TestConstants.LogsListResponse);

        // Act
        var result = await _appwriteClient.Teams.ListTeamMemberships(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListTeamMemberships_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListTeamMembershipsRequest
        {
            TeamId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Teams.ListTeamMemberships(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListTeamMemberships_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListTeamMembershipsRequest
        {
            TeamId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/teams/{request.TeamId}/memberships")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Teams.ListTeamMemberships(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
