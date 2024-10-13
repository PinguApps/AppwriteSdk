using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class UpdatePreferencesRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePreferencesRequest();

        // Assert
        Assert.NotNull(request.Preferences);
        Assert.Empty(request.Preferences);
    }

    [Theory]
    [MemberData(nameof(PropertiesToBeSet))]
    public void Properties_CanBeSet(IDictionary<string, string> dict)
    {
        // Arrange
        var request = new UpdatePreferencesRequest();

        // Act
        request.Preferences = dict;

        // Assert
        Assert.Equal(dict, request.Preferences);
    }

    public static IEnumerable<object[]> PropertiesToBeSet()
    {
        yield return new object[] { new Dictionary<string, string> { { "key1", "val1" }, { "key2", "val2" } } };
        yield return new object[] { new Dictionary<string, string>() };
    }

    [Fact]
    public void IsValid_WithValidPhoneAndPassword_ReturnsTrue()
    {
        // Arrange
        var request = new UpdatePreferencesRequest
        {
            Preferences = new Dictionary<string, string> { { "key1", "val1" }, { "key2", "val2" } }
        };

        // Act
        bool isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void IsValid_WithInvalidInputs_ReturnsFalse()
    {
        // Arrange
        var request = new UpdatePreferencesRequest
        {
            Preferences = null!
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
        var request = new UpdatePreferencesRequest
        {
            Preferences = null!
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdatePreferencesRequest
        {
            Preferences = null!
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
