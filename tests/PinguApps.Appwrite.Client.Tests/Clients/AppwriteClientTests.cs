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
        var mockAccountClient = new Mock<IAccountClient>();

        // Act
        var appwriteClient = new AppwriteClient(mockAccountClient.Object);

        // Assert
        Assert.Equal(mockAccountClient.Object, appwriteClient.Account);
    }

    [Fact]
    public void Session_InitiallyNull_ReturnsNull()
    {
        // Arrange
        var mockAccountClient = new Mock<IAccountClient>();
        var appwriteClient = new AppwriteClient(mockAccountClient.Object);

        // Act
        var session = appwriteClient.Session;

        // Assert
        Assert.Null(session);
    }

    [Fact]
    public void SetSession_UpdatesSession()
    {
        // Arrange
        var mockAccountClient = new Mock<IAccountClient>();
        mockAccountClient.As<ISessionAware>();
        var appwriteClient = new AppwriteClient(mockAccountClient.Object);

        // Act
        appwriteClient.SetSession(Constants.Session);

        // Assert
        Assert.Equal(Constants.Session, appwriteClient.Session);
    }

    [Fact]
    public void SetSession_UpdatesSessionInAccountClient()
    {
        // Arrange
        var mockAccountClient = new Mock<IAccountClient>();
        mockAccountClient.As<ISessionAware>();
        var appwriteClient = new AppwriteClient(mockAccountClient.Object);

        // Act
        appwriteClient.SetSession(Constants.Session);

        // Assert
        mockAccountClient.As<ISessionAware>().Verify(a => a.UpdateSession(Constants.Session), Times.Once);
    }
}
