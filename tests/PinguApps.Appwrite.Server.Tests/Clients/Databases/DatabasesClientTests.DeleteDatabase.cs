using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task DeleteDatabase_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new DeleteDatabaseRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.NoContent);

        // Act
        var result = await _appwriteClient.Databases.DeleteDatabase(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task DeleteDatabase_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new DeleteDatabaseRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.DeleteDatabase(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task DeleteDatabase_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new DeleteDatabaseRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.DeleteDatabase(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
