using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    [Theory]
    [InlineData("identity123")]
    [InlineData("identity456")]
    public async Task DeleteIdentity_ShouldReturnSuccess_WhenApiCallSucceeds(string identityId)
    {
        // Arrange
        var request = new DeleteIdentityRequest
        {
            IdentityId = identityId
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/users/identities/{identityId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.NoContent);

        // Act
        var result = await _appwriteClient.Users.DeleteIdentity(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task DeleteIdentity_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new DeleteIdentityRequest
        {
            IdentityId = "identity123"
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/users/identities/identity123")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.DeleteIdentity(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task DeleteIdentity_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new DeleteIdentityRequest
        {
            IdentityId = "identity123"
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/users/identities/identity123")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.DeleteIdentity(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
