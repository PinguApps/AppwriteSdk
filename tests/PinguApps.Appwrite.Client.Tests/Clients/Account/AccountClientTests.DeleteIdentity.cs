using System.Net;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task DeleteIdentity_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new DeleteIdentityRequest { IdentityId = "validIdentityId" };

        _mockHttp.Expect(HttpMethod.Delete, $"{Constants.Endpoint}/account/identities/{request.IdentityId}")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.NoContent);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteIdentity(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task DeleteIdentity_ShouldHitDifferentEndpoint_WhenNewIdentityIdIsUsed()
    {
        // Arrange
        var identityId = "myIdentityId";
        var request = new DeleteIdentityRequest { IdentityId = identityId };
        var requestUri = $"{Constants.Endpoint}/account/identities/{identityId}";
        var mockRequest = _mockHttp.Expect(HttpMethod.Delete, requestUri)
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.NoContent);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteIdentity(request);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
        var matches = _mockHttp.GetMatchCount(mockRequest);
        Assert.Equal(1, matches);
    }

    [Fact]
    public async Task DeleteIdentity_ShouldReturnError_WhenSessionIsNull()
    {
        // Arrange
        var request = new DeleteIdentityRequest { IdentityId = "validIdentityId" };

        // Act
        var result = await _appwriteClient.Account.DeleteIdentity(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsInternalError);
        Assert.Equal(ISessionAware.SessionExceptionMessage, result.Result.AsT2.Message);
    }

    [Fact]
    public async Task DeleteIdentity_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new DeleteIdentityRequest { IdentityId = "validIdentityId" };

        _mockHttp.Expect(HttpMethod.Delete, $"{Constants.Endpoint}/account/identities/{request.IdentityId}")
            .ExpectedHeaders(true)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteIdentity(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task DeleteIdentity_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new DeleteIdentityRequest { IdentityId = "validIdentityId" };

        _mockHttp.Expect(HttpMethod.Delete, $"{Constants.Endpoint}/account/identities/{request.IdentityId}")
            .ExpectedHeaders(true)
            .Throw(new HttpRequestException("An error occurred"));

        _appwriteClient.SetSession(Constants.Session);

        // Act
        var result = await _appwriteClient.Account.DeleteIdentity(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
