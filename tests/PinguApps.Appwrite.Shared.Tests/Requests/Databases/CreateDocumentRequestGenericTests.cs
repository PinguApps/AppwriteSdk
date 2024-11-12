using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;

// Test model for our generic type
public class CreateDocumentTestData
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}

public class CreateDocumentRequestGenericTests : DatabaseCollectionIdBaseRequestTests<CreateDocumentRequest<CreateDocumentTestData>, CreateDocumentRequestValidator<CreateDocumentTestData>>
{
    protected override CreateDocumentRequest<CreateDocumentTestData> CreateValidDatabaseCollectionIdRequest => new()
    {
        DocumentId = IdUtils.GenerateUniqueId(),
        Data = new CreateDocumentTestData { Name = "Pingu", Age = 25 }
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateDocumentRequest<CreateDocumentTestData>();

        // Assert
        Assert.NotEmpty(request.DocumentId);
        Assert.Null(request.Data);
        Assert.NotNull(request.Permissions);
        Assert.Empty(request.Permissions);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var documentId = IdUtils.GenerateUniqueId();
        var data = new CreateDocumentTestData { Name = "Pingu", Age = 30 };
        var permissions = new List<Permission> { Permission.Read().Any() };

        var request = new CreateDocumentRequest<CreateDocumentTestData>();

        // Act
        request.DocumentId = documentId;
        request.Data = data;
        request.Permissions = permissions;

        // Assert
        Assert.Equal(documentId, request.DocumentId);
        Assert.Equal(data, request.Data);
        Assert.Equal(permissions, request.Permissions);
    }

    public static TheoryData<CreateDocumentRequest<CreateDocumentTestData>> ValidRequestsData =>
    [
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId(),
            Data = new CreateDocumentTestData { Name = "Valid Name", Age = 25 },
            Permissions = [Permission.Read().Any()]
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = "validDocumentId123",
            Data = new CreateDocumentTestData { Name = "Another Valid Name", Age = 30 },
            Permissions = []
        }
    ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateDocumentRequest<CreateDocumentTestData> request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateDocumentRequest<CreateDocumentTestData>> InvalidRequestsData =>
    [
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = null!,
            Data = new CreateDocumentTestData { Name = "Test", Age = 25 }
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = "",
            Data = new CreateDocumentTestData { Name = "Test", Age = 25 }
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = "invalid chars!",
            Data = new CreateDocumentTestData { Name = "Test", Age = 25 }
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = ".startsWithSymbol",
            Data = new CreateDocumentTestData { Name = "Test", Age = 25 }
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = new string('a', 37),
            Data = new CreateDocumentTestData { Name = "Test", Age = 25 }
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId(),
            Data = null!
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = IdUtils.GenerateUniqueId(),
            Data = new CreateDocumentTestData { Name = "Test", Age = 25 },
            Permissions = null!
        }
    ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateDocumentRequest<CreateDocumentTestData> request)
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
        var request = new CreateDocumentRequest<CreateDocumentTestData>
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = "",
            Data = null!,
            Permissions = null!
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateDocumentRequest<CreateDocumentTestData>
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            DocumentId = "",
            Data = null!,
            Permissions = null!
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
