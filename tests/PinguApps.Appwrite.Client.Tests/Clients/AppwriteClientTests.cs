using Moq;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Shared.Tests;

namespace PinguApps.Appwrite.Client.Tests.Clients;
public class AppwriteClientTests
{
    [Fact]
    public void Constructor_SetsAccountClient()
    {
        // Arrange
        var mockAccountClient = new Mock<IClientAccountClient>();
        var mockTeamsClient = new Mock<IClientTeamsClient>();
        var mockDatabasesClient = new Mock<IClientDatabasesClient>();

        // Act
        var appwriteClient = new ClientAppwriteClient(mockAccountClient.Object, mockTeamsClient.Object, mockDatabasesClient.Object);

        // Assert
        Assert.Equal(mockAccountClient.Object, appwriteClient.Account);
        Assert.Equal(mockTeamsClient.Object, appwriteClient.Teams);
        Assert.Equal(mockDatabasesClient.Object, appwriteClient.Databases);
    }

    [Fact]
    public void Session_InitiallyNull_ReturnsNull()
    {
        // Arrange
        var mockAccountClient = new Mock<IClientAccountClient>();
        var mockTeamsClient = new Mock<IClientTeamsClient>();
        var mockDatabasesClient = new Mock<IClientDatabasesClient>();
        var appwriteClient = new ClientAppwriteClient(mockAccountClient.Object, mockTeamsClient.Object, mockDatabasesClient.Object);

        // Act
        var session = appwriteClient.Session;

        // Assert
        Assert.Null(session);
    }

    [Fact]
    public void SetSession_UpdatesSession()
    {
        // Arrange
        var mockAccountClient = new Mock<IClientAccountClient>();
        var mockTeamsClient = new Mock<IClientTeamsClient>();
        var mockDatabasesClient = new Mock<IClientDatabasesClient>();
        mockAccountClient.As<ISessionAware>();
        mockTeamsClient.As<ISessionAware>();
        mockDatabasesClient.As<ISessionAware>();
        var appwriteClient = new ClientAppwriteClient(mockAccountClient.Object, mockTeamsClient.Object, mockDatabasesClient.Object);

        // Act
        appwriteClient.SetSession(TestConstants.Session);

        // Assert
        Assert.Equal(TestConstants.Session, appwriteClient.Session);
    }

    [Fact]
    public void SetSession_UpdatesSessionInAccountClient()
    {
        // Arrange
        var mockAccountClient = new Mock<IClientAccountClient>();
        var mockTeamsClient = new Mock<IClientTeamsClient>();
        var mockDatabasesClient = new Mock<IClientDatabasesClient>();
        mockAccountClient.As<ISessionAware>();
        mockTeamsClient.As<ISessionAware>();
        mockDatabasesClient.As<ISessionAware>();
        var appwriteClient = new ClientAppwriteClient(mockAccountClient.Object, mockTeamsClient.Object, mockDatabasesClient.Object);

        // Act
        appwriteClient.SetSession(TestConstants.Session);

        // Assert
        mockAccountClient.As<ISessionAware>().Verify(a => a.UpdateSession(TestConstants.Session), Times.Once);
    }
}
