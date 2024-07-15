using System.Text;
using Moq;
using Moq.Protected;
using PinguApps.Appwrite.Client.Handlers;
using PinguApps.Appwrite.Client.Internals;

namespace PinguApps.Appwrite.Client.Tests.Handlers;
public class ClientCookieSessionHandlerTests
{
    [Fact]
    public async Task SendAsync_WhenResponseHasSessionCookie_SavesSessionCorrectly()
    {
        // Arrange
        var mockInnerHandler = new Mock<HttpMessageHandler>();
        var mockAppwriteClient = new Mock<IAppwriteClient>();
        var sessionData = new CookieSessionData { Id = "123456", Secret = "test_secret" };
        var encodedSessionData = Convert.ToBase64String(Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(sessionData)));
        var cookieValue = $"a_session={encodedSessionData}; Path=/; HttpOnly";

        mockInnerHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Headers = { { "Set-Cookie", cookieValue } }
            })
            .Verifiable();

        var handler = new ClientCookieSessionHandler(new Lazy<IAppwriteClient>(() => mockAppwriteClient.Object))
        {
            InnerHandler = mockInnerHandler.Object
        };
        var httpClient = new HttpClient(handler);

        // Act
        await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));

        // Assert
        mockAppwriteClient.Verify(client => client.SetSession("test_secret"), Times.Once);
    }
}
