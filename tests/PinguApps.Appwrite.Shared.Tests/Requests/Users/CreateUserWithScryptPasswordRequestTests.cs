using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateUserWithScryptPasswordRequestTests : CreateUserWithPasswordBaseRequestTests<CreateUserWithScryptPasswordRequest, CreateUserWithScryptPasswordRequestValidator>
{
    protected override CreateUserWithScryptPasswordRequest CreateValidRequest => new()
    {
        PasswordSalt = "passwordSalt"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateUserWithScryptPasswordRequest();

        // Assert
        Assert.Equal(string.Empty, request.PasswordSalt);
        Assert.Equal(0, request.PasswordCpu);
        Assert.Equal(0, request.PasswordMemory);
        Assert.Equal(0, request.PasswordParallel);
        Assert.Equal(0, request.PasswordLength);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var salt = "MySalt";
        var cpu = 1;
        var memory = 2;
        var parallel = 3;
        var length = 4;

        // Arrange
        var request = new CreateUserWithScryptPasswordRequest();

        // Act
        request.PasswordSalt = salt;
        request.PasswordCpu = cpu;
        request.PasswordMemory = memory;
        request.PasswordParallel = parallel;
        request.PasswordLength = length;

        // Assert
        Assert.Equal(salt, request.PasswordSalt);
        Assert.Equal(cpu, request.PasswordCpu);
        Assert.Equal(memory, request.PasswordMemory);
        Assert.Equal(parallel, request.PasswordParallel);
        Assert.Equal(length, request.PasswordLength);
    }

    [Theory]
    [InlineData("any salt should work", 0, 0, 0, 0)]
    [InlineData("symbols-_.", 1, 2, 3, 4)]
    public void IsValid_WithValidData_ReturnsTrue(string salt, int cpu, int memory, int parallel, int length)
    {
        // Arrange
        var request = new CreateUserWithScryptPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordSalt = salt,
            PasswordCpu = cpu,
            PasswordMemory = memory,
            PasswordParallel = parallel,
            PasswordLength = length
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null, 0, 0, 0, 0)]
    [InlineData("", 0, 0, 0, 0)]
    public void IsValid_WithInvalidData_ReturnsFalse(string? salt, int cpu, int memory, int parallel, int length)
    {
        // Arrange
        var request = new CreateUserWithScryptPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordSalt = salt!,
            PasswordCpu = cpu,
            PasswordMemory = memory,
            PasswordParallel = parallel,
            PasswordLength = length
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
        var request = new CreateUserWithScryptPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordSalt = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateUserWithScryptPasswordRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Email = "pingu@example.com",
            Password = "MyPassword",
            PasswordSalt = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
