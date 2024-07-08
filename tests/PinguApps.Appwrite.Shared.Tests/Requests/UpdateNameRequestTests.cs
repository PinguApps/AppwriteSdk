using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class UpdateNameRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateNameRequest();

        // Assert
        Assert.NotNull(request.Name);
        Assert.Equal(string.Empty, request.Name);
    }

    [Theory]
    [InlineData("name1")]
    [InlineData("name2")]
    public void Properties_CanBeSet(string name)
    {
        // Arrange
        var request = new UpdateNameRequest();

        // Act
        request.Name = name;

        // Assert
        Assert.Equal(name, request.Name);
    }
}
