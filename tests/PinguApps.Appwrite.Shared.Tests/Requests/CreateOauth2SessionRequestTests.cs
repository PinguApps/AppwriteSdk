using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class CreateOauth2SessionRequestTests
{
    public class TestableCreateOauth2SessionRequest : CreateOauth2SessionRequest
    {
        public string ExposedPath => Path;
    }

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new TestableCreateOauth2SessionRequest();

        // Assert
        Assert.Equal(string.Empty, request.Provider);
        Assert.Null(request.SuccessUri);
        Assert.Null(request.FailureUri);
        Assert.Null(request.Scopes);
        Assert.Equal("/account/tokens/oauth2/{provider}", request.ExposedPath);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var provider = "google";
        var success = "https://example.com/success";
        var failure = "https://example.com/failure";
        var scopes = new List<string>
        {
            "scope1",
            "scope2"
        };

        var request = new CreateOauth2SessionRequest();

        // Act
        request.Provider = provider;
        request.SuccessUri = success;
        request.FailureUri = failure;
        request.Scopes = scopes;

        // Assert
        Assert.Equal(provider, request.Provider);
        Assert.Equal(success, request.SuccessUri);
        Assert.Equal(failure, request.FailureUri);
        Assert.Equal(scopes, request.Scopes);
    }

    public static IEnumerable<object?[]> GetValidData()
    {
        yield return new object?[] { "google", null, null, null };
        yield return new object?[] { "google", "https://example.com/success", "https://example.com/failure", new List<string> { "scope1" } };
    }

    [Theory]
    [MemberData(nameof(GetValidData))]
    public void IsValid_WithValidData_ReturnsTrue(string provider, string? success, string? failure, List<string> scopes)
    {
        // Arrange
        var request = new CreateOauth2SessionRequest
        {
            Provider = provider,
            SuccessUri = success,
            FailureUri = failure,
            Scopes = scopes
        };

        // Act
        var isValid = request.IsValid();

        var validation = request.Validate();

        // Assert
        Assert.True(isValid);
    }

    public static IEnumerable<object?[]> GetInvalidData()
    {
        yield return new object?[] { "", null, null, null };
        yield return new object?[] { "Google", null, null, null };
        yield return new object?[] { "google", "", null, null };
        yield return new object?[] { "google", "not a url", null, null };
        yield return new object?[] { "google", null, "", null };
        yield return new object?[] { "google", null, "not a url", null };
        yield return new object?[] { "google", null, null, new List<string>() };
        yield return new object?[] { "google", null, null, Enumerable.Range(0, 101).Select(x => x.ToString()).ToList() };
        yield return new object?[] { "google", null, null, new List<string> { new('a', 4097) } };
    }

    [Theory]
    [MemberData(nameof(GetInvalidData))]
    public void IsValid_WithInvalidData_ReturnsFalse(string? provider, string? success, string? failure, List<string> scopes)
    {
        // Arrange
        var request = new CreateOauth2SessionRequest
        {
            Provider = provider!,
            SuccessUri = success,
            FailureUri = failure,
            Scopes = scopes
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
        var request = new CreateOauth2SessionRequest
        {
            Provider = "",
            SuccessUri = "not a url"
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateOauth2SessionRequest
        {
            Provider = "",
            SuccessUri = "not a url"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
