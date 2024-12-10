using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task UpdateCollection_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new UpdateCollectionRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Name = "New Name"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.CollectionResponse);

        // Act
        var result = await _appwriteClient.Databases.UpdateCollection(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateCollection_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateCollectionRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Name = "New Name"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.UpdateCollection(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateCollection_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateCollectionRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Name = "New Name"
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.UpdateCollection(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
