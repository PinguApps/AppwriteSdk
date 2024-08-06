using System.Net;
using Moq;
using PinguApps.Appwrite.Client.Utils;
using PinguApps.Appwrite.Shared.Tests;
using Refit;

namespace PinguApps.Appwrite.Client.Tests.Utils;
public class ResponseUtilsTests
{
    [Fact]
    public void GetApiResponse_Success_ReturnsContent()
    {
        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.SetupGet(r => r.IsSuccessStatusCode).Returns(true);
        mockApiResponse.SetupGet(r => r.Content).Returns("Success");

        var result = mockApiResponse.Object.GetApiResponse();

        Assert.True(result.Success);
        Assert.Equal("Success", result.Result);
    }

    [Fact]
    public void GetApiResponse_SuccessButNullContent_ReturnsInternalError()
    {
        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.SetupGet(r => r.IsSuccessStatusCode).Returns(true);
        mockApiResponse.SetupGet(r => r.Content).Returns((string?)null);

        var result = mockApiResponse.Object.GetApiResponse();

        Assert.False(result.Success);
        Assert.True(result.Result.IsT2);
    }

    [Fact]
    public async Task GetApiResponse_Failure_ReturnsError()
    {
        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        {
            Content = new StringContent(Constants.AppwriteError)
        };
        var exception = await ApiException.Create(new HttpRequestMessage(), HttpMethod.Get, response, new RefitSettings());

        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.SetupGet(r => r.IsSuccessStatusCode).Returns(false);
        mockApiResponse.SetupGet(x => x.Error).Returns(exception);

        var result = mockApiResponse.Object.GetApiResponse();

        Assert.False(result.Success);
        Assert.True(result.IsAppwriteError);
        Assert.True(result.Result.IsT1);
    }

    [Fact]
    public async Task GetApiResponse_FailureButNullErrorContent_ThrowsException()
    {
        var exception = await ApiException.Create(new HttpRequestMessage(), HttpMethod.Get, new HttpResponseMessage(HttpStatusCode.InternalServerError), new RefitSettings());

        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.SetupGet(r => r.IsSuccessStatusCode).Returns(false);
        mockApiResponse.SetupGet(x => x.Error).Returns(exception);

        Assert.Throws<Exception>(() => mockApiResponse.Object.GetApiResponse());
    }

    [Fact]
    public async Task GetApiResponse_FailureButNullError_ThrowsException()
    {
        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.SetupGet(r => r.IsSuccessStatusCode).Returns(false);
        mockApiResponse.SetupGet(x => x.Error).Returns((ApiException)null!);

        Assert.Throws<Exception>(() => mockApiResponse.Object.GetApiResponse());
    }

    [Fact]
    public void GetExceptionResponse_ReturnsInternalError()
    {
        var exception = new Exception("Test exception");

        var result = exception.GetExceptionResponse<string>();

        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.True(result.Result.IsT2);
        Assert.Equal("Test exception", result.Result.AsT2.Message);
    }
}
