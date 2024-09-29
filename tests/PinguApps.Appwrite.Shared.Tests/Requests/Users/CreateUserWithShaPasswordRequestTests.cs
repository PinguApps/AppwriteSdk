using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserWithShaPasswordRequestTests : CreateUserWithPasswordBaseRequestTests<CreateUserWithShaPasswordRequest, CreateUserWithShaPasswordRequestValidator>
{
    protected override CreateUserWithShaPasswordRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateUserWithShaPasswordRequest();

        // Assert
        Assert.Null(request.PasswordVersion);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var version = "sha1";

        // Arrange
        var request = new CreateUserWithShaPasswordRequest();

        // Act
        request.PasswordVersion = version;

        // Assert
        Assert.Equal(version, request.PasswordVersion);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("sha1")]
    [InlineData("sha224")]
    [InlineData("sha256")]
    [InlineData("sha384")]
    [InlineData("sha512/224")]
    [InlineData("sha512/256")]
    [InlineData("sha512")]
    [InlineData("sha3-224")]
    [InlineData("sha3-256")]
    [InlineData("sha3-384")]
    [InlineData("sha3-512")]
    public void IsValid_WithValidData_ReturnsTrue(string? version)
    {
        // Arrange
        var request = new CreateUserWithShaPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordVersion = version
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("Invalid")]
    [InlineData("sha")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? version)
    {
        // Arrange
        var request = new CreateUserWithShaPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordVersion = version
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
        var request = new CreateUserWithShaPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordVersion = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateUserWithShaPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordVersion = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
