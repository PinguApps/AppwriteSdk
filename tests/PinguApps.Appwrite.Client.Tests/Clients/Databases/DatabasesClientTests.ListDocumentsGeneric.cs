using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task ListDocumentsGeneric_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new ListDocumentsRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.DocumentsListGenericResponse);

        // Act
        var result = await _appwriteClient.Databases.ListDocuments<TestData>(request);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Test", result.Result.AsT0.Documents[0].Data.Name);
        Assert.Equal(25, result.Result.AsT0.Documents[0].Data.Age);
    }

    [Fact]
    public async Task ListDocumentsGeneric_ShouldIncludeSessionHeaders_WhenProvided()
    {
        // Arrange
        var request = new ListDocumentsRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders(true)
            .Respond(TestConstants.AppJson, TestConstants.DocumentsListGenericResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Databases.ListDocuments<TestData>(request);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    public async Task ListDocumentsGeneric_ShouldProvideQueryParams_WhenQueriesProvided()
    {
        // Arrange
        var query = Query.Limit(5);
        var request = new ListDocumentsRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Queries = [query]
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders()
            .WithQueryString($"queries[]={query.GetQueryString()}")
            .Respond(TestConstants.AppJson, TestConstants.DocumentsListGenericResponse);

        // Act
        var result = await _appwriteClient.Databases.ListDocuments<TestData>(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task ListDocumentsGeneric_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new ListDocumentsRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.ListDocuments<TestData>(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task ListDocumentsGeneric_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ListDocumentsRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId()
        };

        _mockHttp.Expect(HttpMethod.Get, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.ListDocuments<TestData>(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
