using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class Create2faChallengeConfirmationRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new Create2faChallengeConfirmationRequest();

        // Assert
        Assert.Equal(string.Empty, request.ChallengeId);
        Assert.Equal(string.Empty, request.Otp);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new Create2faChallengeConfirmationRequest();
        var challengeId = "Challenge";
        var otp = "Otp";

        // Act
        request.ChallengeId = challengeId;
        request.Otp = otp;

        // Assert
        Assert.Equal(challengeId, request.ChallengeId);
        Assert.Equal(otp, request.Otp);
    }

    [Theory]
    [InlineData("A string", "A string")]
    [InlineData("123456", "123456")]
    [InlineData("A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. ", "A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. A much longer string. ")]
    public void IsValid_WithValidInputs_ReturnsTrue(string challenge, string otp)
    {
        // Arrange
        var request = new Create2faChallengeConfirmationRequest
        {
            ChallengeId = challenge,
            Otp = otp
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("", "123456")]
    [InlineData(null, "123456")]
    [InlineData("123456", "")]
    [InlineData("123456", null)]
    public void IsValid_WithInvalidInputs_ReturnsFalse(string? challenge, string? otp)
    {
        // Arrange
        var request = new Create2faChallengeConfirmationRequest
        {
            ChallengeId = challenge!,
            Otp = otp!
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
        var request = new Create2faChallengeConfirmationRequest();

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new Create2faChallengeConfirmationRequest();

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
