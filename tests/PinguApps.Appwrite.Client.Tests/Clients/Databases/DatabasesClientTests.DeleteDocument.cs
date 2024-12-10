using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task DeleteDocument_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new DeleteDocumentRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.NoContent);

        // Act
        var result = await _appwriteClient.Databases.DeleteDocument(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task DeleteDocument_ShouldIncludeSessionHeaders_WhenProvided()
    {
        // Arrange
        var request = new DeleteDocumentRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.NoContent);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Databases.DeleteDocument(request);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    public async Task DeleteDocument_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new DeleteDocumentRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.DeleteDocument(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task DeleteDocument_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new DeleteDocumentRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Delete, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.DeleteDocument(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
