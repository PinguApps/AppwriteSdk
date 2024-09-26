using Moq;
using PinguApps.Appwrite.Server.Clients;

namespace PinguApps.Appwrite.Server.Tests.Servers;
public class AppwriteServerTests
{
    [Fact]
    public void Constructor_AssignsAccountServerCorrectly()
    {
        // Arrange
        var mockAccountServer = new Mock<IAccountClient>();
        // Act
        var appwriteServer = new AppwriteClient(mockAccountServer.Object);
        // Assert
        Assert.Equal(mockAccountServer.Object, appwriteServer.Account);
    }
}
