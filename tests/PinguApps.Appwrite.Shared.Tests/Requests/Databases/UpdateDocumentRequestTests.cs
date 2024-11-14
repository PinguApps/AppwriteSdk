using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateDocumentRequestTests : DatabaseCollectionDocumentIdBaseRequestTests<UpdateDocumentRequest, UpdateDocumentRequestValidator>
{
    protected override UpdateDocumentRequest CreateValidDatabaseCollectionDocumentIdRequest => new()
    {
        Data = new Dictionary<string, object?>
        {
            { "name", "Pingu" },
            { "age", 25 }
        }
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateDocumentRequest();

        // Assert
        Assert.Null(request.Data);
        Assert.NotNull(request.Permissions);
        Assert.Empty(request.Permissions);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = UpdateDocumentRequest
            .CreateBuilder()
            .AddField("name", "Pingu")
            .AddField("age", 30)
            .AddPermission(Permission.Read().Any())
            .Build();

        // Assert
        Assert.NotNull(request.Data);
        var name = request.Data["name"];
        Assert.Equal("Pingu", name);
        var age = request.Data["age"];
        Assert.Equal(30, age);
        Assert.NotNull(request.Permissions);
        Assert.Single(request.Permissions);
        Assert.Equal(Permission.Read().Any(), request.Permissions.First());
    }

    public static TheoryData<UpdateDocumentRequest> ValidRequestsData =>
    [
        UpdateDocumentRequest
            .CreateBuilder()
            .WithDatabaseId(IdUtils.GenerateUniqueId())
            .WithCollectionId(IdUtils.GenerateUniqueId())
            .WithDocumentId(IdUtils.GenerateUniqueId())
            .AddField("name", "Pingu")
            .AddField("age", 25)
            .AddPermission(Permission.Read().Any())
            .Build(),

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
