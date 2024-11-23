using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateDatabaseRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateDatabaseRequest();

        // Assert
        Assert.NotEmpty(request.DatabaseId);
        Assert.Equal(string.Empty, request.Name);
        Assert.False(request.Enabled);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var databaseId = IdUtils.GenerateUniqueId();
        var name = "My Database";
        var enabled = true;

        var request = new CreateDatabaseRequest();

        // Act
        request.DatabaseId = databaseId;
        request.Name = name;
        request.Enabled = enabled;

        // Assert
        Assert.Equal(databaseId, request.DatabaseId);
        Assert.Equal(name, request.Name);
        Assert.Equal(enabled, request.Enabled);
    }

    public static TheoryData<CreateDatabaseRequest> ValidRequestsData =
        [
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                Name = "Valid Database Name",
                Enabled = true
            },
            new()
            {
                DatabaseId = "validDatabaseId123",
                Name = "Another Valid Database",
                Enabled = false
            }
        ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateDatabaseRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateDatabaseRequest> InvalidRequestsData = new()
        {
            new()
            {
                DatabaseId = null!,
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = "",
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = "invalid chars!",
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = ".startsWithSymbol",
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = new string('a', 37),
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                Name = null!
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                Name = ""
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                Name = new string('a', 129)
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateDatabaseRequest request)
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
        var request = new CreateDatabaseRequest
        {
            DatabaseId = "",
            Name = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateDatabaseRequest
        {
            DatabaseId = "",
            Name = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
