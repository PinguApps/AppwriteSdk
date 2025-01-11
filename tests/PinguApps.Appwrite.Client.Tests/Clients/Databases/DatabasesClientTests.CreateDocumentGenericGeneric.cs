using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Databases;
public partial class DatabasesClientTests
{

    [Fact]
    public async Task CreateDocumentGenericGeneric_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateDocumentRequest<TestData>()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Data = new TestData()
            {
                Name = "Test",
                Age = 25
            }
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.DocumentGenericResponse);

        // Act
        var result = await _appwriteClient.Databases.CreateDocument<TestData, TestDataResponse>(request);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Test", result.Result.AsT0.Data.Name);
        Assert.Equal(25, result.Result.AsT0.Data.Age);
    }

    [Fact]
    public async Task CreateDocumentGenericGeneric_ShouldIncludeSessionHeaders_WhenProvided()
    {
        // Arrange
        var request = new CreateDocumentRequest<TestData>()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Data = new TestData()
            {
                Name = "Test",
                Age = 25
            }
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(TestConstants.AppJson, TestConstants.DocumentResponse);

        _appwriteClient.SetSession(TestConstants.Session);

        // Act
        var result = await _appwriteClient.Databases.CreateDocument<TestData, TestDataResponse>(request);

        // Assert
        _mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    public async Task CreateDocumentGenericGeneric_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateDocumentRequest<TestData>()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Data = new TestData()
            {
                Name = "Test",
                Age = 25
            }
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.CreateDocument<TestData, TestDataResponse>(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateDocumentGenericGeneric_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateDocumentRequest<TestData>()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Data = new TestData()
            {
                Name = "Test",
                Age = 25
            }
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/documents")
            .ExpectedHeaders()
            .WithJsonContent(request, _jsonSerializerOptions)
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.CreateDocument<TestData, TestDataResponse>(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
