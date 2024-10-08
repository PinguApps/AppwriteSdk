using System.Net;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Tests;
using PinguApps.Appwrite.Shared.Utils;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients.Users;
public partial class UsersClientTests
{
    public static TheoryData<UpdateUserLabelsRequest> UpdateUserLabels_ValidRequestData = new()
        {
            new UpdateUserLabelsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Labels = ["label 1", "label 2"]
            },
            new UpdateUserLabelsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Labels = ["label 3", "label 4"]
            }
        };

    [Theory]
    [MemberData(nameof(UpdateUserLabels_ValidRequestData))]
    public async Task UpdateUserLabels_ShouldReturnSuccess_WhenApiCallSucceeds(UpdateUserLabelsRequest request)
    {
        // Arrange
        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/{request.UserId}/labels")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(Constants.AppJson, Constants.UserResponse);

        // Act
        var result = await _appwriteClient.Users.UpdateUserLabels(request);

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(result.Result);
        Assert.Equal(userId, result.Result.Id);
        _mockHttp.VerifyNoOutstandingExpectation();
    }

    [Fact]
    public async Task UpdateUserLabels_ShouldHandleException_WhenApiCallFails()
    {
        // Arrange
        var request = new UpdateUserLabelsRequest
        {
            UserId = "user123",
            Labels = new string[] { "label1", "label2" }
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/user123/labels")
            .WithJsonContent(request)
            .ExpectedHeaders()
            .Respond(HttpStatusCode.BadRequest, Constants.AppJson, Constants.AppwriteError);

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
            Labels = new string[] { "label1", "label2" }
        };

        _mockHttp.Expect(HttpMethod.Patch, $"{Constants.Endpoint}/users/user123/labels")
            .WithJsonContent(request)
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
