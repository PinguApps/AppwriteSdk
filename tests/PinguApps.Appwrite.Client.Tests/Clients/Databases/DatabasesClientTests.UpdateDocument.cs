using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task UpdateDocument_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = UpdateDocumentRequest.CreateBuilder()
            .WithDatabaseId(IdUtils.GenerateUniqueId())
            .WithCollectionId(IdUtils.GenerateUniqueId())
            .WithDocumentId(IdUtils.GenerateUniqueId())
            .AddField("test", "test")
            .Build();

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.DocumentResponse);

        // Act
        var result = await _appwriteClient.Databases.UpdateDocument(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateDocument_ShouldIncludeSessionHeaders_WhenProvided()
    {
        // Arrange
        var request = UpdateDocumentRequest.CreateBuilder()
            .WithDatabaseId(IdUtils.GenerateUniqueId())
            .WithCollectionId(IdUtils.GenerateUniqueId())
            .WithDocumentId(IdUtils.GenerateUniqueId())
            .AddField("test", "test")
            .Build();

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.DocumentResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Databases.UpdateDocument(request);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    public async Task UpdateDocument_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = UpdateDocumentRequest.CreateBuilder()
            .WithDatabaseId(IdUtils.GenerateUniqueId())
            .WithCollectionId(IdUtils.GenerateUniqueId())
            .WithDocumentId(IdUtils.GenerateUniqueId())
            .AddField("test", "test")
            .Build();

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.UpdateDocument(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateDocument_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = UpdateDocumentRequest.CreateBuilder()
            .WithDatabaseId(IdUtils.GenerateUniqueId())
            .WithCollectionId(IdUtils.GenerateUniqueId())
            .WithDocumentId(IdUtils.GenerateUniqueId())
            .AddField("test", "test")
            .Build();

        _mockHttp.Expect(HttpMethod.Patch, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.UpdateDocument(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
