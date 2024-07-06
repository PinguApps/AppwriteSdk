namespace PinguApps.Appwrite.Shared.Tests;
public class AppwriteErrorTests
{
    [Fact]
    public void AppwriteError_Constructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var expectedMessage = "An error occurred";
        var expectedCode = 400;
        var expectedType = "BadRequest";
        var expectedVersion = "v1";

        // Act
        var error = new AppwriteError(expectedMessage, expectedCode, expectedType, expectedVersion);

        // Assert
        Assert.Equal(expectedMessage, error.Message);
        Assert.Equal(expectedCode, error.Code);
        Assert.Equal(expectedType, error.Type);
        Assert.Equal(expectedVersion, error.Version);
    }
}
