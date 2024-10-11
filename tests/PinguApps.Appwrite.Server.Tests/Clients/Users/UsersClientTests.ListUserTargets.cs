using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    public static TheoryData<ListUserTargetsRequest> ListUserTargets_ValidRequestData =
        new TheoryData<ListUserTargetsRequest>
        {
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId()
            }
        };

    [Theory]
    [MemberData(nameof(ListUserTargets_ValidRequestData))]
    public async Task ListUserTargets_ShouldReturnSuccess_WhenApiCallSucceeds(ListUserTargetsRequest request)
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/targets")
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.TargetListResponse);

        // Act
        var result = await _appwriteClient.Users.ListUserTargets(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListUserTargets_ShouldProvideQueries_WhenQueriesProvided()
    {
        // Arrange
        var query = Query.Limit(5);
        var request = new ListUserTargetsRequest()
        {
            UserId = IdUtils.GenerateUniqueId(),
            Queries = [query]
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/targets")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}")
            .Respond(Constants.AppJson, Constants.TargetListResponse);

        // Act
        var result = await _appwriteClient.Users.ListUserTargets(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListUserTargets_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListUserTargetsRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/targets")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.ListUserTargets(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListUserTargets_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListUserTargetsRequest
        {
            UserId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{Constants.Endpoint}/users/{request.UserId}/targets")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.ListUserTargets(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
