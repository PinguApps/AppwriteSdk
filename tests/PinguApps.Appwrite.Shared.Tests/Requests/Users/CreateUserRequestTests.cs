using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateUserRequest();

        // Assert
        Assert.NotEmpty(request.UserId);
        Assert.Null(request.Email);
        Assert.Null(request.Phone);
        Assert.Null(request.Password);
        Assert.Null(request.Name);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var userId = IdUtils.GenerateUniqueId();
        var email = "pingu@example.com";
        var phone = "+4412345678901";
        var password = "MySuperSecretPassword";
        var name = "My Name";

        var request = new CreateUserRequest();

        // Act
        request.UserId = userId;
        request.Email = email;
        request.Phone = phone;
        request.Password = password;
        request.Name = name;

        // Assert
        Assert.Equal(userId, request.UserId);
        Assert.Equal(email, request.Email);
        Assert.Equal(phone, request.Phone);
        Assert.Equal(password, request.Password);
        Assert.Equal(name, request.Name);
    }

    public static TheoryData<CreateUserRequest> ValidRequestsData = new()
        {
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = "pingu@example.com",
                Phone = "+44123456",
                Password = "SuperSecretPassword",
                Name = "Valid Name"
            },
            new()
            {
                UserId = "uses.All_Symbol-s",
                Email = null,
                Phone = null,
                Password = null,
                Name = null
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateUserRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateUserRequest> InvalidRequestsData = new()
        {
            new()
            {
                UserId = null!,
                Email = null,
                Phone = null,
                Password = null,
                Name = null
            },
            new()
            {
                UserId = "",
                Email = null,
                Phone = null,
                Password = null,
                Name = null
            },
            new()
            {
                UserId = "invalid chars!",
                Email = null,
                Phone = null,
                Password = null,
                Name = null
            },
            new()
            {
                UserId = ".startsWithSymbol",
                Email = null,
                Phone = null,
                Password = null,
                Name = null
            },
            new()
            {
                UserId = new string('a', 37),
                Email = null,
                Phone = null,
                Password = null,
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = "",
                Phone = null,
                Password = null,
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = "not an email",
                Phone = null,
                Password = null,
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = null,
                Phone = "",
                Password = null,
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = null,
                Phone = "1234567890",
                Password = null,
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = null,
                Phone = "+456123aaa",
                Password = null,
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = null,
                Phone = "+456123!!!",
                Password = null,
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = null,
                Phone = "+1234567890123456789",
                Password = null,
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = null,
                Phone = null,
                Password = "",
                Name = null
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = null,
                Phone = null,
                Password = null,
                Name = ""
            },
            new()
            {
                UserId = IdUtils.GenerateUniqueId(),
                Email = null,
                Phone = null,
                Password = null,
                Name = new string('a', 129)
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateUserRequest request)
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
        var request = new CreateUserRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Phone = "123"
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
            Phone = "123"
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
