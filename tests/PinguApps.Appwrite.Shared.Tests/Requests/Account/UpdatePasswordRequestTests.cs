using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;

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

    [Theory]
    [InlineData(null, "Password")]
    [InlineData("Password", "Passw0rd")]
    public void IsValid_WithValidData_ReturnsTrue(string? oldPassword, string newPassword)
    {
        // Arrange
        var request = new UpdatePasswordRequest
        {
            NewPassword = newPassword,
            OldPassword = oldPassword
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("Password", "")] // Empty new
    [InlineData("pass", "Password")] // Short old
    [InlineData("Password", "pass")] // Short new
    public void IsValid_WithInvalidData_ReturnsFalse(string oldPassword, string newPassword)
    {
        // Arrange
        var request = new UpdatePasswordRequest
        {
            OldPassword = oldPassword,
            NewPassword = newPassword
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new UpdatePhoneRequest
        {
            Phone = "invalid",
            Password = "short"
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdatePhoneRequest
        {
            Phone = "invalid",
            Password = "short"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
