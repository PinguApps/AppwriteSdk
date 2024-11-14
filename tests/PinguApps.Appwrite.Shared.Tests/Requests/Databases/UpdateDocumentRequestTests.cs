using FluentValidation;
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
        Assert.NotNull(request.Data);
        Assert.Empty(request.Data);
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
        UpdateDocumentRequest
            .CreateBuilder()
            .WithDatabaseId(IdUtils.GenerateUniqueId())
            .WithCollectionId(IdUtils.GenerateUniqueId())
            .WithDocumentId(IdUtils.GenerateUniqueId())
            .AddField("name", "Valid Name")
            .AddField("age", 30)
            .Build()
    ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateDocumentRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateDocumentRequest> InvalidRequestsData
    {
        get
        {
            var data = new TheoryData<UpdateDocumentRequest>();

            var nullData = UpdateDocumentRequest
                .CreateBuilder()
                .WithDatabaseId(IdUtils.GenerateUniqueId())
                .WithCollectionId(IdUtils.GenerateUniqueId())
                .WithDocumentId(IdUtils.GenerateUniqueId())
                .Build();

            nullData.Data = null!;

            data.Add(nullData);

            var nullPermissions = UpdateDocumentRequest
                .CreateBuilder()
                .WithDatabaseId(IdUtils.GenerateUniqueId())
                .WithCollectionId(IdUtils.GenerateUniqueId())
                .WithDocumentId(IdUtils.GenerateUniqueId())
                .Build();

            nullPermissions.Permissions = null!;

            data.Add(nullPermissions);

            return data;
        }
    }

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateDocumentRequest request)
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
        var request = UpdateDocumentRequest
            .CreateBuilder()
            .WithDatabaseId(IdUtils.GenerateUniqueId())
            .WithCollectionId(IdUtils.GenerateUniqueId())
            .WithDocumentId(IdUtils.GenerateUniqueId())
            .Build();

        request.Data = null!;
        request.Permissions = null!;

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = UpdateDocumentRequest
            .CreateBuilder()
            .WithDatabaseId(IdUtils.GenerateUniqueId())
            .WithCollectionId(IdUtils.GenerateUniqueId())
            .WithDocumentId(IdUtils.GenerateUniqueId())
            .Build();

        request.Data = null!;
        request.Permissions = null!;

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
