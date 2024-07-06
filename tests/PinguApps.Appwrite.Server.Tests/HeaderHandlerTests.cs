using Moq;
using Moq.Protected;
using PinguApps.Appwrite.Server.Handlers;
using PinguApps.Appwrite.Shared.Tests;

namespace PinguApps.Appwrite.Server.Tests;
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

        var headerHandler = new HeaderHandler(Constants.ProjectId, Constants.ApiKey)
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
}
