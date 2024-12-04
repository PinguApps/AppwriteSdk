﻿using System.Net;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Databases;
public partial class DatabasesClientTests
{
    [Fact]
    public async Task CreateUrlAttribute_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateURLAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "created"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/attributes/url")
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.AttributeUrlResponse);

        // Act
        var result = await _appwriteClient.Databases.CreateUrlAttribute(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task CreateUrlAttribute_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new CreateURLAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "created"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/attributes/url")
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Databases.CreateUrlAttribute(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task CreateUrlAttribute_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateURLAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "created"
        };

        _mockHttp.Expect(HttpMethod.Post, $"{TestConstants.Endpoint}/databases/{request.DatabaseId}/collections/{request.CollectionId}/attributes/url")
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Databases.CreateUrlAttribute(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
