using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    public static TheoryData<UpdateUserLabelsRequest> UpdateUserLabels_ValidRequestData =
        [
            new UpdateUserLabelsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Labels = ["label1", "label2"]
            },
            new UpdateUserLabelsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Labels = ["label3", "label4"]
            }
        ];

    [Theory]
    [MemberData(nameof(UpdateUserLabels_ValidRequestData))]
    public async Task UpdateUserLabels_ShouldReturnSuccess_WhenApiCallSucceeds(UpdateUserLabelsRequest request)
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/users/{request.UserId}/labels")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Respond(TestConstants.AppJson, TestConstants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.UpdateUserLabels(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public async Task UpdateUserLabels_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateUserLabelsRequest
        {
            UserId = "user123",
            Labels = ["label1", "label2"]
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/users/user123/labels")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, TestConstants.AppJson, TestConstants.AppwriteError);

        // Act
        var result = await _appwriteClient.Users.UpdateUserLabels(request);

        // Assert
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
    }

    [Fact]
    public async Task UpdateUserLabels_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new UpdateUserLabelsRequest
        {
            UserId = "user123",
            Labels = ["label1", "label2"]
        };

        _mockHttp.Expect(HttpMethod.Put, $"{TestConstants.Endpoint}/users/user123/labels")
            .WithJsonContent(request, _jsonSerializerOptions)
            .ExpectedHeaders()
            .Throw(new HttpRequestException("An error occurred"));

        // Act
        var result = await _appwriteClient.Users.UpdateUserLabels(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.Equal("An error occurred", result.Result.AsT2.Message);
    }
}
