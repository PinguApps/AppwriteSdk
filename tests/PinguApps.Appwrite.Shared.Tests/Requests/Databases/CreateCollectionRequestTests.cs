using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateCollectionRequestTests : DatabaseIdBaseRequestTests<CreateCollectionRequest, CreateCollectionRequestValidator>
{
    protected override CreateCollectionRequest CreateValidRequest => new()
    {
        CollectionId = IdUtils.GenerateUniqueId(),
        Name = "Pingu"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateCollectionRequest();

        // Assert
        Assert.NotEmpty(request.CollectionId);
        Assert.Equal(string.Empty, request.Name);
        Assert.NotNull(request.Permissions);
        Assert.False(request.DocumentSecurity);
        Assert.True(request.Enabled);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var collectionId = IdUtils.GenerateUniqueId();
        var name = "My Collection";
        var permissions = new List<Permission> { Permission.Read().Any() };
        var documentSecurity = true;
        var enabled = true;

        var request = new CreateCollectionRequest();

        // Act
        request.CollectionId = collectionId;
        request.Name = name;
        request.Permissions = permissions;
        request.DocumentSecurity = documentSecurity;
        request.Enabled = enabled;

        // Assert
        Assert.Equal(collectionId, request.CollectionId);
        Assert.Equal(name, request.Name);
        Assert.Equal(permissions, request.Permissions);
        Assert.Equal(documentSecurity, request.DocumentSecurity);
        Assert.Equal(enabled, request.Enabled);
    }

    public static TheoryData<CreateCollectionRequest> ValidRequestsData =
        [
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
                CollectionId = "validCollectionId123",
                Name = "Another Valid Collection",
                Permissions = [],
                DocumentSecurity = false,
                Enabled = false
            }
        ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateCollectionRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateCollectionRequest> InvalidRequestsData = new()
        {
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = null!,
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = "",
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = "invalid chars!",
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = ".startsWithSymbol",
                Name = "Pingu"
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = new string('a', 37),
                Name = "Pingu"
            },
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
    public void IsValid_WithInvalidData_ReturnsFalse(CreateCollectionRequest request)
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
        var request = new CreateCollectionRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = "",
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
        var request = new CreateCollectionRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = "",
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
