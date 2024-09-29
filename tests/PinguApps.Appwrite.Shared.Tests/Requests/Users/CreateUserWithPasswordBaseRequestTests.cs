using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public abstract class CreateUserWithPasswordBaseRequestTests<TRequest, TValidator> : UserIdBaseRequest<TRequest, TValidator>
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
        Assert.Equal(string.Empty, request.Email);
        Assert.Equal(string.Empty, request.Password);
        Assert.Null(request.Name);
    }

    [Fact]
    public void CreateUserWithPasswordBase_Properties_CanBeSet()
    {
        // Arrange
        var email = "pingu@example.com";
        var password = "MySuperSecretPassword";
        var name = "My Name";
        var request = CreateValidRequest;

        // Act
        request.Email = email;
        request.Password = password;
        request.Name = name;

        // Assert
        Assert.Equal(email, request.Email);
        Assert.Equal(password, request.Password);
        Assert.Equal(name, request.Name);
    }

    [Theory]
    [InlineData("pingu@example.com", "MySuperSecretPassword123!", null)]
    [InlineData("pingu@example.com", "MySuperSecretPassword123!", "My Name")]
    public void CreateUserWithPasswordBase_IsValid_WithValidData_ReturnsTrue(string email, string password, string? name)
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = IdUtils.GenerateUniqueId();
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
        yield return new object?[] { null, "MySuperSecretPassword", null };
        yield return new object?[] { "", "MySuperSecretPassword", null };
        yield return new object?[] { "not an email", "MySuperSecretPassword", null };
        yield return new object?[] { "pingu@example.com", null, null };
        yield return new object?[] { "pingu@example.com", "", null };
        yield return new object?[] { "pingu@example.com", "MySuperSecretPassword", "" };
        yield return new object?[] { "pingu@example.com", "MySuperSecretPassword", new string('a', 129) };
    }

    [Theory]
    [MemberData(nameof(CreateUserWithPasswordBase_GetInvalidData))]
    public void CreateUserWithPasswordBase_IsValid_WithInvalidData_ReturnsFalse(string? email, string? password, string? name)
    {
        // Arrange
        var request = CreateValidRequest;
        request.UserId = IdUtils.GenerateUniqueId();
        request.Email = email!;
        request.Password = password!;
        request.Name = name;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
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
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
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
