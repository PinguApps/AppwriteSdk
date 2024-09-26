using Moq;
using Moq.Protected;
using PinguApps.Appwrite.Server.Handlers;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Tests;

namespace PinguApps.Appwrite.Server.Tests.Handlers;
public class HeaderHandlerTests
{
    [Fact]
    public async Task SendAsync_AddsRequiredHeaders()
    {
        // Arrange
        var mockInnerHandler = new Mock<HttpMessageHandler>();
        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage())
            .Verifiable();

        var config = new Config(Constants.Endpoint, Constants.ProjectId, Constants.ApiKey);

        var headerHandler = new HeaderHandler(config)
        {
            InnerHandler = mockInnerHandler.Object
        };
        var httpClient = new HttpClient(headerHandler);

        // Act
        await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));

        // Assert
        mockInnerHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Headers.Contains("x-appwrite-project") &&
                req.Headers.GetValues("x-appwrite-project").Contains(Constants.ProjectId) &&
                req.Headers.Contains("x-appwrite-key") &&
                req.Headers.GetValues("x-appwrite-key").Contains(Constants.ApiKey)),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenApiKeyIsNull()
    {
        // Arrange
        var config = new Config(Constants.Endpoint, Constants.ProjectId, null);

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new HeaderHandler(config));
        Assert.Equal("config.ApiKey", exception.ParamName);
    }
}
