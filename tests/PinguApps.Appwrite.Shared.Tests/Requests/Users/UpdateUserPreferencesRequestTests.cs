using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdateUserPreferencesRequestTests : UserIdBaseRequestTests<UpdateUserPreferencesRequest, UpdateUserPreferencesRequestValidator>
{
    protected override UpdateUserPreferencesRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateUserPreferencesRequest();

        // Assert
        Assert.NotNull(request.Preferences);
        Assert.Empty(request.Preferences);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var preferences = new Dictionary<string, string>
            {
                { "theme", "dark" },
                { "notifications", "enabled" }
            };

        // Arrange
        var request = new UpdateUserPreferencesRequest();

        // Act
        request.Preferences = preferences;

        // Assert
        Assert.Collection(request.Preferences,
            item =>
            {
                Assert.Equal("theme", item.Key);
                Assert.Equal("dark", item.Value);
            },
            item =>
            {
                Assert.Equal("notifications", item.Key);
                Assert.Equal("enabled", item.Value);
            }
        );
        Assert.Equal(preferences, request.Preferences);
    }

    public static TheoryData<UpdateUserPreferencesRequest> ValidRequestsData = new()
        {
            new UpdateUserPreferencesRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Preferences = new Dictionary<string, string>
                {
                    { "theme", "dark" },
                    { "notifications", "enabled" }
                }
            },
            new UpdateUserPreferencesRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Preferences = new Dictionary<string, string>()
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateUserPreferencesRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateUserPreferencesRequest> InvalidRequestsData = new()
        {
            new UpdateUserPreferencesRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Preferences = null!
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateUserPreferencesRequest request)
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
        var request = new UpdateUserPreferencesRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Preferences = null!
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateUserPreferencesRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Preferences = null!
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
