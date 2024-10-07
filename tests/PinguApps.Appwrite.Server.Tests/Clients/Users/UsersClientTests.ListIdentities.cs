using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task ListIdentities_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new ListIdentitiesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/identities")
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.IdentitiesListResponse);

        // Act
        var result = await _appwriteClient.Users.ListIdentities(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListIdentities_ShouldProvideQueries_WhenQueriesProvided()
    {
        // Arrange
        var query = Query.Equal("name", "Pingu");
        var request = new ListIdentitiesRequest()
        {
            Queries = [query]
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/identities")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}")
            .Respond(Constants.AppJson, Constants.IdentitiesListResponse);

        // Act
        var result = await _appwriteClient.Users.ListIdentities(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListIdentities_ShouldProvideSearch_WhenSearchProvided()
    {
        // Arrange
        var request = new ListIdentitiesRequest()
        {
            Search = "SearchQuery"
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/identities")
            .ExpectedHeaders()
            .WithQueryString("search=SearchQuery")
            .Respond(Constants.AppJson, Constants.IdentitiesListResponse);

        // Act
        var result = await _appwriteClient.Users.ListIdentities(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListIdentities_ShouldProvideQueriesAndSearch_WhenBothProvided()
    {
        // Arrange
        var query = Query.Equal("name", "Pingu");
        var request = new ListIdentitiesRequest()
        {
            Queries = [query],
            Search = "SearchQuery"
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/identities")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}")
            .WithQueryString("search=SearchQuery")
            .Respond(Constants.AppJson, Constants.IdentitiesListResponse);

        // Act
        var result = await _appwriteClient.Users.ListIdentities(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListIdentities_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListIdentitiesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/identities")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.ListIdentities(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListIdentities_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListIdentitiesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/identities")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.ListIdentities(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
