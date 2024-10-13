using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserWithScryptModifiedPasswordRequestTests : CreateUserWithPasswordBaseRequestTests<CreateUserWithScryptModifiedPasswordRequest, CreateUserWithScryptModifiedPasswordRequestValidator>
{
    protected override CreateUserWithScryptModifiedPasswordRequest CreateValidRequest => new()
    {
        PasswordSalt = "MySalt",
        PasswordSaltSeparator = ",",
        PasswordSignerKey = "MyKey"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateUserWithScryptModifiedPasswordRequest();

        // Assert
        Assert.Equal(string.Empty, request.PasswordSalt);
        Assert.Equal(string.Empty, request.PasswordSaltSeparator);
        Assert.Equal(string.Empty, request.PasswordSignerKey);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var salt = "MySalt";
        var seperator = "MySeperator";
        var signerKey = "MySignerKey";

        // Arrange
        var request = new CreateUserWithScryptModifiedPasswordRequest();

        // Act
        request.PasswordSalt = salt;
        request.PasswordSaltSeparator = seperator;
        request.PasswordSignerKey = signerKey;

        // Assert
        Assert.Equal(salt, request.PasswordSalt);
        Assert.Equal(seperator, request.PasswordSaltSeparator);
        Assert.Equal(signerKey, request.PasswordSignerKey);
    }

    [Theory]
    [InlineData("any salt should work", "MySeperator", "MySignerKey")]
    public void IsValid_WithValidData_ReturnsTrue(string salt, string seperator, string signerKey)
    {
        // Arrange
        var request = new CreateUserWithScryptModifiedPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordSalt = salt,
            PasswordSaltSeparator = seperator,
            PasswordSignerKey = signerKey
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null, "MySeperator", "MyKey")]
    [InlineData("", "MySeperator", "MyKey")]
    [InlineData("MySalt", null, "MyKey")]
    [InlineData("MySalt", "", "MyKey")]
    [InlineData("MySalt", "MySeparator", null)]
    [InlineData("MySalt", "MySeparator", "")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? salt, string? seperator, string? signerKey)
    {
        // Arrange
        var request = new CreateUserWithScryptModifiedPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordSalt = salt!,
            PasswordSaltSeparator = seperator!,
            PasswordSignerKey = signerKey!
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
        var request = new CreateUserWithScryptModifiedPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordSalt = "",
            PasswordSaltSeparator = "",
            PasswordSignerKey = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateUserWithScryptModifiedPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordSalt = "",
            PasswordSaltSeparator = "",
            PasswordSignerKey = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
