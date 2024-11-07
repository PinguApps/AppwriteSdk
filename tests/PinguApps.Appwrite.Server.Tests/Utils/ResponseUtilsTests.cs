using System.Net;
using Moq;
using OneOf.Types;
using PinguApps.Appwrite.Server.Utils;
using PinguApps.Appwrite.Shared.Tests;
using Refit;

namespace PinguApps.Appwrite.Server.Tests.Utils;
public class ResponseUtilsTests
{
    [Fact]
    public void GetApiResponse_Success_ReturnsContent()
    {
        var mockApiResponse = new Mock<IApiResponse>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(true);

        var result = mockApiResponse.Object.GetApiResponse();

        Assert.True(result.Success);
        Assert.IsType<Success>(result.Result.AsT0);
    }

    [Fact]
    public async Task GetApiResponse_Failure_ReturnsError()
    {
        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        {
            Content = new StringContent(TestConstants.AppwriteError)
        };
        var exception = await ApiException.Create(new HttpRequestMessage(), HttpMethod.Get, response, new RefitSettings());

        var mockApiResponse = new Mock<IApiResponse>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(false);
        mockApiResponse.As<IApiResponse>().Setup(x => x.Error).Returns(exception);

        var result = mockApiResponse.Object.GetApiResponse();

        Assert.False(result.Success);
        Assert.True(result.IsAppwriteError);
        Assert.True(result.Result.IsT1);
    }

    [Fact]
    public async Task GetApiResponse_FailureButNullErrorContent_ThrowsException()
    {
        var exception = await ApiException.Create(new HttpRequestMessage(), HttpMethod.Get, new HttpResponseMessage(HttpStatusCode.InternalServerError), new RefitSettings());

        var mockApiResponse = new Mock<IApiResponse>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(false);
        mockApiResponse.As<IApiResponse>().Setup(x => x.Error).Returns(exception);

        Assert.Throws<Exception>(() => mockApiResponse.Object.GetApiResponse());
    }

    [Fact]
    public void GetApiResponse_FailureButNullError_ThrowsException()
    {
        var mockApiResponse = new Mock<IApiResponse>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(false);
        mockApiResponse.As<IApiResponse>().Setup(x => x.Error).Returns((ApiException)null!);

        Assert.Throws<Exception>(() => mockApiResponse.Object.GetApiResponse());
    }

    [Fact]
    public void GenericGetApiResponse_Success_ReturnsContent()
    {
        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(true);
        mockApiResponse.Setup(r => r.Content).Returns("Success");

        var result = mockApiResponse.Object.GetApiResponse();

        Assert.True(result.Success);
        Assert.Equal("Success", result.Result);
    }

    [Fact]
    public void GenericGetApiResponse_SuccessButNullContent_ReturnsInternalError()
    {
        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(true);
        mockApiResponse.Setup(r => r.Content).Returns((string?)null);

        var result = mockApiResponse.Object.GetApiResponse();

        Assert.False(result.Success);
        Assert.True(result.Result.IsT2);
    }

    [Fact]
    public async Task GenericGetApiResponse_Failure_ReturnsError()
    {
        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        {
            Content = new StringContent(TestConstants.AppwriteError)
        };
        var exception = await ApiException.Create(new HttpRequestMessage(), HttpMethod.Get, response, new RefitSettings());

        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(false);
        mockApiResponse.As<IApiResponse>().Setup(x => x.Error).Returns(exception);

        var result = mockApiResponse.Object.GetApiResponse();

        Assert.False(result.Success);
        Assert.True(result.IsAppwriteError);
        Assert.True(result.Result.IsT1);
    }

    [Fact]
    public async Task GenericGetApiResponse_FailureButNullErrorContent_ThrowsException()
    {
        var exception = await ApiException.Create(new HttpRequestMessage(), HttpMethod.Get, new HttpResponseMessage(HttpStatusCode.InternalServerError), new RefitSettings());

        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(false);
        mockApiResponse.As<IApiResponse>().Setup(x => x.Error).Returns(exception);

        Assert.Throws<Exception>(() => mockApiResponse.Object.GetApiResponse());
    }

    [Fact]
    public void GenericGetApiResponse_FailureButNullError_ThrowsException()
    {
        var mockApiResponse = new Mock<IApiResponse<string>>();
        mockApiResponse.As<IApiResponse>().Setup(x => x.IsSuccessStatusCode).Returns(false);
        mockApiResponse.As<IApiResponse>().Setup(x => x.Error).Returns((ApiException)null!);

        Assert.Throws<Exception>(() => mockApiResponse.Object.GetApiResponse());
    }

    [Fact]
    public void GetExceptionResponse_ReturnsInternalError()
    {
        var exception = new Exception("Test exception");

        var result = exception.GetExceptionResponse();

        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.True(result.Result.IsT2);
        Assert.Equal("Test exception", result.Result.AsT2.Message);
    }

    [Fact]
    public void GenericGetExceptionResponse_ReturnsInternalError()
    {
        var exception = new Exception("Test exception");

        var result = exception.GetExceptionResponse<string>();

        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
        Assert.True(result.Result.IsT2);
        Assert.Equal("Test exception", result.Result.AsT2.Message);
    }
}
