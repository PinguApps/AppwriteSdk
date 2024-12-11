using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateDatabaseRequestTests : DatabaseIdBaseRequestTests<UpdateDatabaseRequest, UpdateDatabaseRequestValidator>
{
    protected override UpdateDatabaseRequest CreateValidRequest => new()
    {
        Name = "Pingu"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateDatabaseRequest();

        // Assert
        Assert.Equal(string.Empty, request.Name);
        Assert.False(request.Enabled);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var name = "Updated Database";
        var enabled = true;

        var request = new UpdateDatabaseRequest();

        // Act
        request.Name = name;
        request.Enabled = enabled;

        // Assert
        Assert.Equal(name, request.Name);
        Assert.Equal(enabled, request.Enabled);
    }

    public static TheoryData<UpdateDatabaseRequest> ValidRequestsData = new()
        {
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                Name = "Valid Database Name",
                Enabled = true
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                Name = "Another Valid Database",
                Enabled = false
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateDatabaseRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateDatabaseRequest> InvalidRequestsData = new()
        {
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
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateDatabaseRequest request)
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
        var request = new UpdateDatabaseRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            Name = "",
            Enabled = false
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateDatabaseRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            Name = "",
            Enabled = false
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
