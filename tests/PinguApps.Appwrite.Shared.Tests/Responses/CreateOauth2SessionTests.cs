using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class CreateOauth2SessionTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var uri = "https://exmaple.com";

        // Act
        var response = new CreateOauth2Session(uri);

        // Assert
        Assert.Equal(uri, response.Uri);
    }
}
