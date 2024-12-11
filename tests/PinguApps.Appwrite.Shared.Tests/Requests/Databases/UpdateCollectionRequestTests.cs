using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateCollectionRequestTests : DatabaseCollectionIdBaseRequestTests<UpdateCollectionRequest, UpdateCollectionRequestValidator>
{
    protected override UpdateCollectionRequest CreateValidDatabaseCollectionIdRequest => new()
    {
        Name = "Pingu"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateCollectionRequest();

        // Assert
        Assert.Equal(string.Empty, request.Name);
        Assert.NotNull(request.Permissions);
        Assert.False(request.DocumentSecurity);
        Assert.False(request.Enabled);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var name = "Updated Collection";
        var permissions = new List<Permission> { Permission.Read().Any() };
        var documentSecurity = true;
        var enabled = true;

        var request = new UpdateCollectionRequest();

        // Act
        request.Name = name;
        request.Permissions = permissions;
        request.DocumentSecurity = documentSecurity;
        request.Enabled = enabled;

        // Assert
        Assert.Equal(name, request.Name);
        Assert.Equal(permissions, request.Permissions);
        Assert.Equal(documentSecurity, request.DocumentSecurity);
        Assert.Equal(enabled, request.Enabled);
    }

    public static TheoryData<UpdateCollectionRequest> ValidRequestsData = new()
        {
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Name = "Valid Collection Name",
                Permissions = [Permission.Read().Any()],
                DocumentSecurity = true,
                Enabled = true
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Name = "Another Valid Collection",
                Permissions = [],
                DocumentSecurity = false,
                Enabled = false
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateCollectionRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateCollectionRequest> InvalidRequestsData = new()
        {
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Name = null!
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Name = ""
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Name = new string('a', 129)
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Name = "Pingu",
                Permissions = null!
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateCollectionRequest request)
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
        var request = new UpdateCollectionRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Name = "",
            Permissions = null!,
            DocumentSecurity = false,
            Enabled = false
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateCollectionRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Name = "",
            Permissions = null!,
            DocumentSecurity = false,
            Enabled = false
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
