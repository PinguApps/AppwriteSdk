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
        // Act
        var appwriteServer = new AppwriteClient(mockAccountClient.Object, mockUsersClient.Object);
        // Assert
        Assert.Equal(mockAccountClient.Object, appwriteServer.Account);
        Assert.Equal(mockUsersClient.Object, appwriteServer.Users);
    }
}
