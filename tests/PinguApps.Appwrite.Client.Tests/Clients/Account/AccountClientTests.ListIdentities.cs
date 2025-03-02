﻿using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task ListIdentities_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new ListIdentitiesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/account/identities")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.IdentitiesListResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.ListIdentities(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListIdentities_ShouldProvideQueries_WhenQueriesProvided()
    {
        // Arrange
        var query = Query.Limit(5);
        var request = new ListIdentitiesRequest()
        {
            Queries = [query]
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/account/identities")
            .ExpectedHeaders(true)
            .WithQueryString($"queries[]={query.GetQueryString()}")
            .Respond(TestConstants.AppJson, TestConstants.IdentitiesListResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.ListIdentities(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListIdentities_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new ListIdentitiesRequest();

        // Act
        var result = await _appwriteClient.Account.ListIdentities(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task ListIdentities_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListIdentitiesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/account/identities")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.ListIdentities(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListIdentities_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListIdentitiesRequest();

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/account/identities")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Account.ListIdentities(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
