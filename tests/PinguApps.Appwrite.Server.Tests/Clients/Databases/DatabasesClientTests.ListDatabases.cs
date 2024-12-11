using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task ListDatabases_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new ListDatabasesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.DatabasesListResponse);

        // Act
        var result = await _appwriteClient.Databases.ListDatabases(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListDatabases_ShouldProvideQueryParams_WhenQueriesAndSearchProvided()
    {
        // Arrange
        var query = Query.Limit(5);
        var search = "SearchString";
        var request = new ListDatabasesRequest
        {
            Queries = new List<Query> { query },
            Search = search
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}&search={search}")
            .Respond(TestConstants.AppJson, TestConstants.DatabasesListResponse);

        // Act
        var result = await _appwriteClient.Databases.ListDatabases(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListDatabases_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListDatabasesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.ListDatabases(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListDatabases_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListDatabasesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.ListDatabases(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
