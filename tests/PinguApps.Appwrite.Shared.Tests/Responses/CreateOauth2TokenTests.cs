using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class CreateOauth2TokenTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var uri = "https://example.com";

        // Act
        var response = new CreateOauth2Token(uri);

        // Assert
        Assert.Equal(uri, response.Uri);
    }
}
