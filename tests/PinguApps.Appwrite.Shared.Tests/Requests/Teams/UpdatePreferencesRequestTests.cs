using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class UpdatePreferencesRequestTests : TeamIdBaseRequestTests<UpdatePreferencesRequest, UpdatePreferencesRequestValidator>
{
    protected override UpdatePreferencesRequest CreateValidRequest => new();
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePreferencesRequest();

        // Assert
        Assert.NotNull(request.Preferences);
        Assert.Empty(request.Preferences);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var preferences = new Dictionary<string, string>
        {
            { "theme", "dark" },
            { "notifications", "enabled" }
        };

        var request = new UpdatePreferencesRequest();

        // Act
        request.Preferences = preferences;

        // Assert
        Assert.Equal(preferences, request.Preferences);
    }

    public static TheoryData<UpdatePreferencesRequest> ValidRequestsData =>
    [
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Preferences = new Dictionary<string, string>
            {
                { "theme", "dark" },
                { "notifications", "enabled" }
            }
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Preferences = new Dictionary<string, string>()
        }
    ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdatePreferencesRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdatePreferencesRequest> InvalidRequestsData =>
    [
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Preferences = null!
        }
    ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdatePreferencesRequest request)
    {
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
            TeamId = IdUtils.GenerateUniqueId(),
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
            TeamId = IdUtils.GenerateUniqueId(),
            Preferences = null!
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
