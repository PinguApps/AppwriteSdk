using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task GetDocumentGeneric_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new GetDocumentRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId(),
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.DocumentGenericResponse);

        // Act
        var result = await _appwriteClient.Databases.GetDocument<TestData>(request);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Test", result.Result.AsT0.Data.Name);
        Assert.Equal(25, result.Result.AsT0.Data.Age);
    }

    [Fact]
    public async Task GetDocumentGeneric_ShouldProvideQueryParams_WhenQueriesProvided()
    {
        // Arrange
        var query = Query.Select(["col1", "col2"]);
        var request = new GetDocumentRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId(),
            Queries = [query]
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}")
            .Respond(TestConstants.AppJson, TestConstants.DocumentGenericResponse);

        // Act
        var result = await _appwriteClient.Databases.GetDocument<TestData>(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task GetDocumentGeneric_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new GetDocumentRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId(),
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.GetDocument<TestData>(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task GetDocumentGeneric_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new GetDocumentRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId(),
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents/{request.DocumentId}")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.GetDocument<TestData>(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
