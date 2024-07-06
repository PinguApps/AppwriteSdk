using Moq;
using PinguApps.Appwrite.Server.Servers;

namespace PinguApps.Appwrite.Server.Tests.Servers;
public class AppwriteServerTests
{
    [Fact]
    public void Constructor_AssignsAccountServerCorrectly()
    {
        // Arrange
        var mockAccountServer = new Mock<IAccountServer>();
        // Act
        var appwriteServer = new AppwriteServer(mockAccountServer.Object);
        // Assert
        Assert.Equal(mockAccountServer.Object, appwriteServer.Account);
    }
}
