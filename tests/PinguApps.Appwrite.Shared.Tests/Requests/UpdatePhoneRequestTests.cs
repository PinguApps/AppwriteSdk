using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;

public class UpdatePhoneRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePhoneRequest();

        // Assert
        Assert.NotNull(request.Password);
        Assert.NotNull(request.Phone);
        Assert.Equal(string.Empty, request.Password);
        Assert.Equal(string.Empty, request.Phone);
    }

    [Theory]
    [InlineData("password", "+123456789")]
    [InlineData("drowssap", "+987654321")]
    public void Properties_CanBeSet(string password, string phone)
    {
        // Arrange
        var request = new UpdatePhoneRequest();

        // Act
        request.Password = password;
        request.Phone = phone;

        // Assert
        Assert.Equal(password, request.Password);
        Assert.Equal(phone, request.Phone);
    }
}
