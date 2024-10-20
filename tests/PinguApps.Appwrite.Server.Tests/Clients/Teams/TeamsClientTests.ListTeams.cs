using System.Net;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Teams;
public partial class TeamsClientTests
{
    [Fact]
    public async Task ListTeams_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new ListTeamsRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/teams")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.TeamsListResponse);

        // Act
        var result = await _appwriteClient.Teams.ListTeams(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListTeams_ShouldProvideQueryParams_WhenQueriesAndSearchProvided()
    {
        // Arrange
        var query = Query.Limit(5);
        var search = "SearchString";
        var request = new ListTeamsRequest
        {
            Queries = [query],
            Search = search
        };

        var expectedQueryParams = new Dictionary<string, string>
        {
            { "queries[]", query.GetQueryString() },
            { "search", search }
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/teams")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}&search={search}")
            .Respond(TestConstants.AppJson, TestConstants.LogsListResponse);

        // Act
        var result = await _appwriteClient.Teams.ListTeams(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListTeams_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListTeamsRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/teams")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Teams.ListTeams(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListTeams_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListTeamsRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/teams")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Teams.ListTeams(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
