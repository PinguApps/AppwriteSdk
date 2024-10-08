using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    public static TheoryData<ListUserLogsRequest> ListUserLogs_ValidRequestData =
        new TheoryData<ListUserLogsRequest>
        {
            new ListUserLogsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
            },
            new ListUserLogsRequest
            {
                UserId = IdUtils.GenerateUniqueId()
            }
        };

    [Theory]
    [MemberData(nameof(ListUserLogs_ValidRequestData))]
    public async Task ListUserLogs_ShouldReturnSuccess_WhenApiCallSucceeds(ListUserLogsRequest request)
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/logs")
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.LogsListResponse);

        // Act
        var result = await _appwriteClient.Users.ListUserLogs(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListUserLogs_ShouldProvideQueries_WhenQueriesProvided()
    {
        // Arrange
        var query = Query.Limit(5);
        var request = new ListUserLogsRequest()
        {
            UserId = IdUtils.GenerateUniqueId(),
            Queries = [query]
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/logs")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}")
            .Respond(Constants.AppJson, Constants.LogsListResponse);

        // Act
        var result = await _appwriteClient.Users.ListUserLogs(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListUserLogs_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListUserLogsRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/logs")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.ListUserLogs(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListUserLogs_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListUserLogsRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/logs")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.ListUserLogs(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
