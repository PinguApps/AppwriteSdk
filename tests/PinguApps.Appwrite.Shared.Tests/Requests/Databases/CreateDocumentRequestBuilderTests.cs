using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateDocumentRequestBuilderTests
{
    [Fact]
    public void CreateBuilder_ReturnsNewBuilderInstance()
    {
        // Act
        var builder = CreateDocumentRequest.CreateBuilder();

        // Assert
        Assert.NotNull(builder);
        Assert.IsAssignableFrom<ICreateDocumentRequestBuilder>(builder);
    }

    [Fact]
    public void WithDocumentId_SetsDocumentId_ReturnsBuilder()
    {
        // Arrange
        var builder = CreateDocumentRequest.CreateBuilder();
        var documentId = IdUtils.GenerateUniqueId();

        // Act
        var result = builder.WithDocumentId(documentId);
        var request = result.Build();

        // Assert
        Assert.Same(builder, result);
        Assert.Equal(documentId, request.DocumentId);
    }

    [Fact]
    public void WithPermissions_SetsPermissions_ReturnsBuilder()
    {
        // Arrange
        var builder = CreateDocumentRequest.CreateBuilder();
        var permissions = new List<Permission> { Permission.Read().Any() };

        // Act
        var result = builder.WithPermissions(permissions);
        var request = result.Build();

        // Assert
        Assert.Same(builder, result);
        Assert.Same(permissions, request.Permissions);
    }

    [Fact]
    public void AddPermission_AddsPermissionToList_ReturnsBuilder()
    {
        // Arrange
        var builder = CreateDocumentRequest.CreateBuilder();
        var permission = Permission.Read().Any();

        // Act
        var result = builder.AddPermission(permission);
        var request = result.Build();

        // Assert
        Assert.Same(builder, result);
        Assert.Contains(permission, request.Permissions);
        Assert.Single(request.Permissions);
    }

    [Fact]
    public void AddPermission_CanAddMultiplePermissions_ReturnsBuilder()
    {
        // Arrange
        var builder = CreateDocumentRequest.CreateBuilder();
        var permission1 = Permission.Read().Any();
        var permission2 = Permission.Write().Any();

        // Act
        builder.AddPermission(permission1)
              .AddPermission(permission2);
        var request = builder.Build();

        // Assert
        Assert.Equal(2, request.Permissions.Count);
        Assert.Contains(permission1, request.Permissions);
        Assert.Contains(permission2, request.Permissions);
    }

    [Fact]
    public void AddField_AddsFieldToData_ReturnsBuilder()
    {
        // Arrange
        var builder = CreateDocumentRequest.CreateBuilder();
        const string fieldName = "testField";
        const string fieldValue = "testValue";

        // Act
        var result = builder.AddField(fieldName, fieldValue);
        var request = result.Build();

        // Assert
        Assert.Same(builder, result);
        Assert.Equal(fieldValue, request.Data[fieldName]);
    }

    [Fact]
    public void AddField_CanAddMultipleFields_ReturnsBuilder()
    {
        // Arrange
        var builder = CreateDocumentRequest.CreateBuilder();

        // Act
        builder.AddField("string", "value")
               .AddField("number", 42)
               .AddField("boolean", true)
               .AddField("null", null);

        var request = builder.Build();

        // Assert
        Assert.Equal(4, request.Data.Count);
        Assert.Equal("value", request.Data["string"]);
        Assert.Equal(42, request.Data["number"]);
        Assert.Equal(true, request.Data["boolean"]);
        Assert.Null(request.Data["null"]);
    }

    [Fact]
    public void Build_CreatesRequestWithAllSetValues()
    {
        // Arrange
        var documentId = IdUtils.GenerateUniqueId();
        var permissions = new List<Permission> { Permission.Read().Any() };
        const string fieldName = "testField";
        const string fieldValue = "testValue";

        // Act
        var request = CreateDocumentRequest.CreateBuilder()
            .WithDocumentId(documentId)
            .WithPermissions(permissions)
            .AddField(fieldName, fieldValue)
            .Build();

        // Assert
        Assert.Equal(documentId, request.DocumentId);
        Assert.Same(permissions, request.Permissions);
        Assert.Equal(fieldValue, request.Data[fieldName]);
    }

    [Fact]
    public void Build_WithNoFieldsAdded_CreatesEmptyDataDictionary()
    {
        // Act
        var request = CreateDocumentRequest.CreateBuilder().Build();

        // Assert
        Assert.NotNull(request.Data);
        Assert.Empty(request.Data);
    }
}
