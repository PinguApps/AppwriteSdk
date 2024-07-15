using System.Text;
using Moq;
using PinguApps.Appwrite.Client.Handlers;
using PinguApps.Appwrite.Client.Internals;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Handlers;
public class ClientCookieSessionHandlerTests
{
    private readonly MockHttpMessageHandler _mockHttp;
    private readonly Mock<IAppwriteClient> _mockAppwriteClient;
    private readonly HttpClient _httpClient;

    public ClientCookieSessionHandlerTests()
    {
        _mockHttp = new MockHttpMessageHandler();
        _mockAppwriteClient = new Mock<IAppwriteClient>();
        var handler = new ClientCookieSessionHandler(new Lazy<IAppwriteClient>(() => _mockAppwriteClient.Object))
        {
            InnerHandler = _mockHttp
        };
        _httpClient = new HttpClient(handler);
    }

    [Fact]
    public async Task SendAsync_WhenResponseHasSessionCookie_SavesSessionCorrectly()
    {
        // Arrange
        var sessionData = new CookieSessionData { Id = "123456", Secret = "test_secret" };
        var encodedSessionData = Convert.ToBase64String(Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(sessionData)));
        var cookieValue = $"a_session={encodedSessionData}; Path=/; HttpOnly";

        _mockHttp.When(HttpMethod.Get, "http://test.com")
            .Respond(req =>
                     new HttpResponseMessage
                     {
                         StatusCode = System.Net.HttpStatusCode.OK,
                         Headers = { { "Set-Cookie", cookieValue } }
                     });

        // Act
        await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));

        // Assert
        _mockAppwriteClient.Verify(client => client.SetSession("test_secret"), Times.Once);
    }

    [Fact]
    public async Task SendAsync_NoSetCookieHeader_DoesNotSetSession()
    {
        // Arrange

        _mockHttp.When(HttpMethod.Get, "http://test.com")
            .Respond(req =>
                     new HttpResponseMessage
                     {
                         StatusCode = System.Net.HttpStatusCode.OK
                     });

        // Act
        await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));

        // Assert
        _mockAppwriteClient.Verify(client => client.SetSession(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task SendAsync_NoASessionCookie_DoesNotSetSession()
    {
        // Arrange
        _mockHttp.When(HttpMethod.Get, "http://test.com")
            .Respond(req =>
                     new HttpResponseMessage
                     {
                         StatusCode = System.Net.HttpStatusCode.OK,
                         Headers = { { "Set-Cookie", "not_a_session=abc123; Path=/; HttpOnly" } }
                     });

        // Act
        await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));

        // Assert
        _mockAppwriteClient.Verify(client => client.SetSession(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task SendAsync_InvalidBase64InASessionCookie_DoesNotSetSession()
    {
        // Arrange
        var invalidBase64 = "not_base64";
        _mockHttp.When(HttpMethod.Get, "http://test.com")
            .Respond(req =>
                     new HttpResponseMessage
                     {
                         StatusCode = System.Net.HttpStatusCode.OK,
                         Headers = { { "Set-Cookie", $"not_a_session={invalidBase64}; Path=/; HttpOnly" } }
                     });

        // Act
        await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));

        // Assert
        _mockAppwriteClient.Verify(client => client.SetSession(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task SendAsync_InvalidJsonInDecodedBase64_DoesNotSetSession()
    {
        // Arrange
        var invalidJsonBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes("{\"SomeKey\": \"SomeValue\"}"));
        _mockHttp.When(HttpMethod.Get, "http://test.com")
            .Respond(req =>
                     new HttpResponseMessage
                     {
                         StatusCode = System.Net.HttpStatusCode.OK,
                         Headers = { { "Set-Cookie", $"a_session={invalidJsonBase64}; Path=/; HttpOnly" } }
                     });

        // Act
        await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));

        // Assert
        _mockAppwriteClient.Verify(client => client.SetSession(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task SendAsync_SessionCookieMarkedAsDeleted_ClearsSession()
    {
        // Arrange
        var deletedSessionCookie = "a_session=deleted; Path=/; HttpOnly";
        _mockHttp.When(HttpMethod.Get, "http://test.com")
            .Respond(req =>
                     new HttpResponseMessage
                     {
                         StatusCode = System.Net.HttpStatusCode.OK,
                         Headers = { { "Set-Cookie", deletedSessionCookie } }
                     });

        // Act
        await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));

        // Assert
        _mockAppwriteClient.Verify(client => client.SetSession(null), Times.Once);
    }

    [Fact]
    public async Task SendAsync_InvalidJsonInSessionCookie_DoesNotThrowJsonException()
    {
        // Arrange
        var invalidJsonBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes("invalid_json"));
        var invalidJsonSessionCookie = $"a_session={invalidJsonBase64}; Path=/; HttpOnly";
        _mockHttp.When(HttpMethod.Get, "http://test.com")
            .Respond(req =>
                     new HttpResponseMessage
                     {
                         StatusCode = System.Net.HttpStatusCode.OK,
                         Headers = { { "Set-Cookie", invalidJsonSessionCookie } }
                     });

        Exception? caughtException = null;

        try
        {
            // Act
            await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, "http://test.com"));
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }

        // Assert
        Assert.Null(caughtException);
        _mockAppwriteClient.Verify(client => client.SetSession(It.IsAny<string>()), Times.Never);
    }

}
