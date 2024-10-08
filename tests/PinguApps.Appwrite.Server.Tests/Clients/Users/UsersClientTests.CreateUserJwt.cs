using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    public static TheoryData<CreateUserJwtRequest> CreateUserJwt_ValidRequestData =
        [
            new CreateUserJwtRequest
            {
                UserId = IdUtils.GenerateUniqueId()
            },
            new CreateUserJwtRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Duration = 1800,
                SessionId = IdUtils.GenerateUniqueId()
            }
        ];

    [Theory]
    [MemberData(nameof(CreateUserJwt_ValidRequestData))]
    public async Task CreateUserJwt_ShouldReturnSuccess_WhenApiCallSucceeds(CreateUserJwtRequest request)
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/jwts")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.JwtResponse);

        // Act
        var result = await _appwriteClient.Users.CreateUserJwt(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateUserJwt_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateUserJwtRequest
        {
            UserId = "user123"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/jwts")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.CreateUserJwt(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateUserJwt_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateUserJwtRequest
        {
            UserId = "user123"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/users/{request.UserId}/jwts")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.CreateUserJwt(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
