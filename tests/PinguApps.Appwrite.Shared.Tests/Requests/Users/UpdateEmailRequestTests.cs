using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdateEmailRequestTests : UserIdBaseRequestTests<UpdateEmailRequest, UpdateEmailRequestValidator>
{
    protected override UpdateEmailRequest CreateValidRequest => new()
    {
        Email = "pingu@example.com"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateEmailRequest();

        // Assert
        Assert.Equal(string.Empty, request.Email);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var email = "pingu@example.com";

        // Arrange
        var request = new UpdateEmailRequest();

        // Act
        request.Email = email;

        // Assert
        Assert.Equal(email, request.Email);
    }

    [Theory]
    [InlineData("valid@example.com")]
    [InlineData("another.valid@example.com")]
    public void IsValid_WithValidData_ReturnsTrue(string email)
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = email
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("invalid-email")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? email)
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = email!
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
        var request = new UpdateEmailRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateEmailRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
