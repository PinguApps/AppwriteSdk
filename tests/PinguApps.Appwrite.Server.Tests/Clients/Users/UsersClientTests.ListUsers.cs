using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Fact]
    public async Task ListUsers_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new ListUsersRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users")
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.UsersListResponse);

        // Act
        var result = await _appwriteClient.Users.ListUsers(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListUsers_ShouldProvideQueries_WhenQueriesProvided()
    {
        // Arrange
        var query = Query.Equal("name", "Pingu");
        var request = new ListUsersRequest()
        {
            Queries = [query]
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}")
            .Respond(Constants.AppJson, Constants.UsersListResponse);

        // Act
        var result = await _appwriteClient.Users.ListUsers(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListUsers_ShouldProvideSearch_WhenSearchProvided()
    {
        // Arrange
        var request = new ListUsersRequest()
        {
            Search = "SearchQuery"
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users")
            .ExpectedHeaders()
            .WithQueryString($"search=SearchQuery")
            .Respond(Constants.AppJson, Constants.UsersListResponse);

        // Act
        var result = await _appwriteClient.Users.ListUsers(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListUsers_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListUsersRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.ListUsers(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListUsers_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListUsersRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.ListUsers(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
