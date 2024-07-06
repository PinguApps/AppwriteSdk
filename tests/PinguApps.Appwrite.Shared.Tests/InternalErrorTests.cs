namespace PinguApps.Appwrite.Shared.Tests;
public class InternalErrorTests
{
    [Fact]
    public void Constructor_AssignsMessage()
    {
        // Arrange
        var expectedMessage = "An error occurred";

        // Act
        var internalError = new InternalError(expectedMessage);

        // Assert
        Assert.Equal(expectedMessage, internalError.Message);
    }
}
