using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task UpdateDatabase_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateDatabaseRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            Name = "New Name"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.DatabaseResponse);

        // Act
        var result = await _appwriteClient.Databases.UpdateDatabase(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateDatabase_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateDatabaseRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            Name = "New Name"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.UpdateDatabase(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateDatabase_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateDatabaseRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            Name = "New Name"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.UpdateDatabase(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
