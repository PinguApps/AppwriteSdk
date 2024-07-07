using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class UpdateEmailRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateEmailRequest();

        // Assert
        Assert.NotNull(request.Email);
        Assert.NotNull(request.Password);
        Assert.Equal(string.Empty, request.Email);
        Assert.Equal(string.Empty, request.Password);
    }

    [Theory]
    [InlineData("test@example.com", "password123")]
    [InlineData("another@example.com", "diffPassword")]
    public void Properties_CanBeSet(string email, string password)
    {
        // Arrange
        var request = new UpdateEmailRequest();

        // Act
        request.Email = email;
        request.Password = password;

        // Assert
        Assert.Equal(email, request.Email);
        Assert.Equal(password, request.Password);
    }
}
