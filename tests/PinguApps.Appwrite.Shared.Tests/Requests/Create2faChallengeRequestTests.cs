using FluentValidation;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class Create2faChallengeRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new Create2faChallengeRequest();

        // Assert
        Assert.Equal(SecondFactor.Email, request.Factor);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new Create2faChallengeRequest();

        // Act
        request.Factor = SecondFactor.Phone;

        // Assert
        Assert.Equal(SecondFactor.Phone, request.Factor);
    }

    [Theory]
    [InlineData(SecondFactor.Email)]
    [InlineData(SecondFactor.Phone)]
    [InlineData(SecondFactor.Totp)]
    [InlineData(SecondFactor.RecoveryCode)]
    public void IsValid_WithValidInputs_ReturnsTrue(SecondFactor factor)
    {
        // Arrange
        var request = new Create2faChallengeRequest
        {
            Factor = factor
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData((SecondFactor)999)]
    public void IsValid_WithInvalidInputs_ReturnsFalse(SecondFactor factor)
    {
        // Arrange
        var request = new Create2faChallengeRequest
        {
            Factor = factor
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
        var request = new Create2faChallengeRequest
        {
            Factor = (SecondFactor)999
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new Create2faChallengeRequest
        {
            Factor = (SecondFactor)999
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
