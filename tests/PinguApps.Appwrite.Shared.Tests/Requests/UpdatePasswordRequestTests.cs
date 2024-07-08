using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;

public class UpdatePasswordRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePasswordRequest();

        // Assert
        Assert.NotNull(request.NewPassword);
        Assert.Equal(string.Empty, request.NewPassword);
        Assert.Null(request.OldPassword);
    }

    [Theory]
    [InlineData("oldPassword", "newPassword")]
    [InlineData(null, "anotherPassword")]
    public void Properties_CanBeSet(string? oldPassword, string newPassword)
    {
        // Arrange
        var request = new UpdatePasswordRequest();

        // Act
        request.OldPassword = oldPassword;
        request.NewPassword = newPassword;

        // Assert
        Assert.Equal(oldPassword, request.OldPassword);
        Assert.Equal(newPassword, request.NewPassword);
    }
}
