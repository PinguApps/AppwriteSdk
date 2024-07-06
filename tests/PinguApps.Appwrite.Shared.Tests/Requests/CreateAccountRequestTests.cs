using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class CreateAccountRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateAccountRequest();

        // Assert
        Assert.NotNull(request.UserId);
        Assert.NotEmpty(request.UserId);
        Assert.Equal(string.Empty, request.Email);
        Assert.Equal(string.Empty, request.Password);
        Assert.Null(request.Name);
    }

    [Theory]
    [InlineData("test@example.com", "password123", "Test User")]
    [InlineData("another@example.com", "diffPassword", null)]
    public void Properties_CanBeSet(string email, string password, string? name)
    {
        // Arrange
        var request = new CreateAccountRequest();

        // Act
        request.Email = email;
        request.Password = password;
        request.Name = name;

        // Assert
        Assert.Equal(email, request.Email);
        Assert.Equal(password, request.Password);
        Assert.Equal(name, request.Name);
    }
}
