using Moq;
using PinguApps.Appwrite.Server.Clients;

namespace PinguApps.Appwrite.Server.Tests.Servers;
public class AppwriteServerTests
{
    [Fact]
    public void Constructor_AssignsAccountServerCorrectly()
    {
        // Arrange
        var mockAccountClient = new Mock<IAccountClient>();
        var mockUsersClient = new Mock<IUsersClient>();
        var mockTeamsClient = new Mock<ITeamsClient>();
        var mockDatabasesClient = new Mock<IDatabasesClient>();
        // Act
        var appwriteServer = new AppwriteClient(mockAccountClient.Object, mockUsersClient.Object, mockTeamsClient.Object, mockDatabasesClient.Object);
        // Assert
        Assert.Equal(mockAccountClient.Object, appwriteServer.Account);
        Assert.Equal(mockUsersClient.Object, appwriteServer.Users);
        Assert.Equal(mockTeamsClient.Object, appwriteServer.Teams);
        Assert.Equal(mockDatabasesClient.Object, appwriteServer.Databases);
    }
}
