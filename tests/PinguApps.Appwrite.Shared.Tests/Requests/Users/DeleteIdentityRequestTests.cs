using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class DeleteIdentityRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new DeleteIdentityRequest();

        // Assert
        Assert.Equal(string.Empty, request.IdentityId);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var id = "newId";

        // Arrange
        var request = new DeleteIdentityRequest();

        // Act
        request.IdentityId = id;

        // Assert
        Assert.Equal(id, request.IdentityId);
    }

    [Theory]
    [InlineData("any Id should work")]
    [InlineData("symbols-_.")]
    public void IsValid_WithValidData_ReturnsTrue(string id)
    {
        // Arrange
        var request = new DeleteIdentityRequest
        {
            IdentityId = id
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? id)
    {
        // Arrange
        var request = new DeleteIdentityRequest
        {
            IdentityId = id!
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
        var request = new DeleteIdentityRequest
        {
            IdentityId = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new DeleteIdentityRequest
        {
            IdentityId = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
