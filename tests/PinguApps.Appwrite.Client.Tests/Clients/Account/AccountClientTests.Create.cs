using System.Net;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public async Task Create_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateAccountRequest()
        {
            Email = "email@example.com",
            Password = "password",
            Name = "name"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(Constants.AppJson, Constants.UserResponse);

        // Act
        var result = await _appwriteClient.Account.Create(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task Create_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateAccountRequest()
        {
            Email = "email@example.com",
            Password = "password",
            Name = "name"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

        // Act
        var result = await _appwriteClient.Account.Create(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task Create_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateAccountRequest()
        {
            Email = "email@example.com",
            Password = "password",
            Name = "name"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{Constants.Endpoint}/account")
            .ExpectedHeaders()
            .WithJsonContent(request)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Account.Create(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
