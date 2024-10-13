using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public abstract class CreateUserWithPasswordBaseRequestTests<TRequest, TValidator>
        where TRequest : CreateUserWithPasswordBaseRequest<TRequest, TValidator>
        where TValidator : AbstractValidator<TRequest>, new()
{
    protected abstract TRequest CreateValidRequest { get; }

    [Fact]
    public void CreateUserWithPasswordBase_Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = CreateValidRequest;

        // Assert
        Assert.NotEmpty(request.UserId);
        Assert.Equal(string.Empty, request.Email);
        Assert.Equal(string.Empty, request.Password);
        Assert.Null(request.Name);
    }

    [Fact]
    public void CreateUserWithPasswordBase_Properties_CanBeSet()
    {
        // Arrange
        var userId = IdUtils.GenerateUniqueId();
        var email = "pingu@example.com";
        var password = "MySuperSecretPassword";
        var name = "My Name";
        var request = CreateValidRequest;

        // Act
        request.UserId = userId;
        request.Email = email;
        request.Password = password;
        request.Name = name;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(email, request.Email);
        Assert.Equal(password, request.Password);
        Assert.Equal(name, request.Name);
    }

    [Theory]
    [InlineData("anId", "pingu@example.com", "MySuperSecretPassword123!", null)]
    [InlineData("with.Some-Symbols_too", "pingu@example.com", "MySuperSecretPassword123!", "My Name")]
    public void CreateUserWithPasswordBase_IsValid_WithValidData_ReturnsTrue(string userId, string email, string password, string? name)
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = userId;
        request.Email = email;
        request.Password = password;
        request.Name = name;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    // Need to rework these - as null is not ok for email and password
    public static IEnumerable<object?[]> CreateUserWithPasswordBase_GetInvalidData()
    {
        yield return new object?[] { null, "pingu@example.com", "MySuperSecretPassword", null };
        yield return new object?[] { "", "pingu@example.com", "MySuperSecretPassword", null };
        yield return new object?[] { "invalid chars!", "pingu@example.com", "MySuperSecretPassword", null };
        yield return new object?[] { ".startsWithSymbol", "pingu@example.com", "MySuperSecretPassword", null };
        yield return new object?[] { new string('a', 37), "pingu@example.com", "MySuperSecretPassword", null };
        yield return new object?[] { IdUtils.GenerateUniqueId(), null, "MySuperSecretPassword", null };
        yield return new object?[] { IdUtils.GenerateUniqueId(), "", "MySuperSecretPassword", null };
        yield return new object?[] { IdUtils.GenerateUniqueId(), "not an email", "MySuperSecretPassword", null };
        yield return new object?[] { IdUtils.GenerateUniqueId(), "pingu@example.com", null, null };
        yield return new object?[] { IdUtils.GenerateUniqueId(), "pingu@example.com", "", null };
        yield return new object?[] { IdUtils.GenerateUniqueId(), "pingu@example.com", "MySuperSecretPassword", "" };
        yield return new object?[] { IdUtils.GenerateUniqueId(), "pingu@example.com", "MySuperSecretPassword", new string('a', 129) };
    }

    [Theory]
    [MemberData(nameof(CreateUserWithPasswordBase_GetInvalidData))]
    public void CreateUserWithPasswordBase_IsValid_WithInvalidData_ReturnsFalse(string? userId, string? email, string? password, string? name)
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = userId!;
        request.Email = email!;
        request.Password = password!;
        request.Name = name;

        // Act
        var isValid = request.IsValid();

        var DELETEME = request.Validate();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void CreateUserWithPasswordBase_Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = IdUtils.GenerateUniqueId();
        request.Email = "not an email";
        request.Password = "";
        request.Name = new string('a', 129);

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void CreateUserWithPasswordBase_Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = IdUtils.GenerateUniqueId();
        request.Email = "not an email";
        request.Password = "";
        request.Name = new string('a', 129);

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
