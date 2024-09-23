using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
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

    [Theory]
    [InlineData("A string")]
    public void Properties_CanBeSet(string identityId)
    {
        // Arrange
        var request = new DeleteIdentityRequest();

        // Act
        request.IdentityId = identityId;

        // Assert
        Assert.Equal(identityId, request.IdentityId);
    }

    [Fact]
    public void IsValid_WithValidInputs_ReturnsTrue()
    {
        // Arrange
        var request = new DeleteIdentityRequest
        {
            IdentityId = "validIdentityId"
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void IsValid_WithInvalidInputs_ReturnsFalse(string? identityId)
    {
        // Arrange
        var request = new DeleteIdentityRequest
        {
            IdentityId = identityId!
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
