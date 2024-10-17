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
        var mockTeamsClient = new Mock<ITeamsClient>();

        // Act
        var appwriteClient = new AppwriteClient(mockAccountClient.Object, mockTeamsClient.Object);

        // Assert
        Assert.Equal(mockAccountClient.Object, appwriteClient.Account);
        Assert.Equal(mockTeamsClient.Object, appwriteClient.Teams);
    }

    [Fact]
    public void Session_InitiallyNull_ReturnsNull()
    {
        // Arrange
        var mockAccountClient = new Mock<IAccountClient>();
        var mockTeamsClient = new Mock<ITeamsClient>();
        var appwriteClient = new AppwriteClient(mockAccountClient.Object, mockTeamsClient.Object);

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
        var mockTeamsClient = new Mock<ITeamsClient>();
        mockAccountClient.As<ISessionAware>();
        var appwriteClient = new AppwriteClient(mockAccountClient.Object, mockTeamsClient.Object);

        // Act
        appwriteClient.SetSession(TestConstants.Session);

        // Assert
        Assert.Equal(TestConstants.Session, appwriteClient.Session);
    }

    [Fact]
    public void SetSession_UpdatesSessionInAccountClient()
    {
        // Arrange
        var mockAccountClient = new Mock<IAccountClient>();
        var mockTeamsClient = new Mock<ITeamsClient>();
        mockAccountClient.As<ISessionAware>();
        var appwriteClient = new AppwriteClient(mockAccountClient.Object, mockTeamsClient.Object);

        // Act
        appwriteClient.SetSession(TestConstants.Session);

        // Assert
        mockAccountClient.As<ISessionAware>().Verify(a => a.UpdateSession(TestConstants.Session), Times.Once);
    }
}
