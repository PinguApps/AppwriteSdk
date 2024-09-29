using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserRequestTests : UserIdBaseRequestTests<CreateUserRequest, CreateUserRequestValidator>
{
    protected override CreateUserRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateUserRequest();

        // Assert
        Assert.Null(request.Email);
        Assert.Null(request.Phone);
        Assert.Null(request.Password);
        Assert.Null(request.Name);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var email = "pingu@example.com";
        var phone = "+4412345678901";
        var password = "ThisIsMySecretPassword";
        var name = "Pingu";

        // Arrange
        var request = new CreateUserRequest();

        // Act
        request.Email = email;
        request.Phone = phone;
        request.Password = password;
        request.Name = name;

        // Assert
        Assert.Equal(email, request.Email);
        Assert.Equal(phone, request.Phone);
        Assert.Equal(password, request.Password);
        Assert.Equal(name, request.Name);
    }

    [Theory]
    [InlineData(null, null, null, null)]
    [InlineData("pingu@example.com", null, null, null)]
    [InlineData(null, "+4412345678901", null, null)]
    [InlineData(null, null, "MyPa55w0rd!", null)]
    [InlineData(null, null, null, "My Name")]
    public void IsValid_WithValidData_ReturnsTrue(string? email, string? phone, string? password, string? name)
    {
        // Arrange
        var request = new CreateUserRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = email,
            Phone = phone,
            Password = password,
            Name = name
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static IEnumerable<object?[]> GetInvalidData()
    {
        yield return new object?[] { "", null, null, null };
        yield return new object?[] { "not an email", null, null, null };
        yield return new object?[] { null, "", null, null };
        yield return new object?[] { null, "1234567890", null, null };
        yield return new object?[] { null, "+456123aaa", null, null };
        yield return new object?[] { null, "+456123!!!", null, null };
        yield return new object?[] { null, "+1234567890123456789", null, null };
        yield return new object?[] { null, null, "", null };
        yield return new object?[] { null, null, "tooFew", null };
        yield return new object?[] { null, null, null, "" };
        yield return new object?[] { null, null, null, new string('a', 129) };
    }

    [Theory]
    [MemberData(nameof(GetInvalidData))]
    public void IsValid_WithInvalidData_ReturnsFalse(string? email, string? phone, string? password, string? name)
    {
        // Arrange
        var request = new CreateUserRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = email,
            Phone = phone,
            Password = password,
            Name = name
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
        var request = new CreateUserRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "not an email",
            Phone = "123",
            Password = "short",
            Name = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateUserRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "not an email",
            Phone = "123",
            Password = "short",
            Name = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
