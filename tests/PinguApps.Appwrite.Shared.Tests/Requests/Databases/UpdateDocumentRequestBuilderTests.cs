using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateDocumentRequestBuilderTests
{
    [Fact]
    public void CreateBuilder_ReturnsNewBuilderInstance()
    {
        // Act
        var builder = UpdateDocumentRequest.CreateBuilder();

        // Assert
        Assert.NotNull(builder);
        Assert.IsAssignableFrom<IUpdateDocumentRequestBuilder>(builder);
    }

    [Fact]
    public void WithDatabaseId_SetsDatabaseId_ReturnsBuilder()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var databaseId = IdUtils.GenerateUniqueId();

        // Act
        var result = builder.WithDatabaseId(databaseId);
        var request = result.Build();

        // Assert
        Assert.Same(builder, result);
        Assert.Equal(databaseId, request.DatabaseId);
    }

    [Fact]
    public void WithCollectionId_SetsCollectionId_ReturnsBuilder()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var collectionId = IdUtils.GenerateUniqueId();

        // Act
        var result = builder.WithCollectionId(collectionId);
        var request = result.Build();

        // Assert
        Assert.Same(builder, result);
        Assert.Equal(collectionId, request.CollectionId);
    }

    [Fact]
    public void WithDocumentId_SetsDocumentId_ReturnsBuilder()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
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
        var builder = UpdateDocumentRequest.CreateBuilder();
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
        var builder = UpdateDocumentRequest.CreateBuilder();
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
        var builder = UpdateDocumentRequest.CreateBuilder();
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
        var builder = UpdateDocumentRequest.CreateBuilder();
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
        var builder = UpdateDocumentRequest.CreateBuilder();

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
        var databaseId = IdUtils.GenerateUniqueId();
        var collectionId = IdUtils.GenerateUniqueId();
        var documentId = IdUtils.GenerateUniqueId();
        var permissions = new List<Permission> { Permission.Read().Any() };
        const string fieldName = "testField";
        const string fieldValue = "testValue";

        // Act
        var request = UpdateDocumentRequest.CreateBuilder()
            .WithDatabaseId(databaseId)
            .WithCollectionId(collectionId)
            .WithDocumentId(documentId)
            .WithPermissions(permissions)
            .AddField(fieldName, fieldValue)
            .Build();

        // Assert
        Assert.Equal(databaseId, request.DatabaseId);
        Assert.Equal(collectionId, request.CollectionId);
        Assert.Equal(documentId, request.DocumentId);
        Assert.Same(permissions, request.Permissions);
        Assert.Equal(fieldValue, request.Data[fieldName]);
    }

    [Fact]
    public void Build_WithNoFieldsAdded_CreatesEmptyDataDictionary()
    {
        // Act
        var request = UpdateDocumentRequest.CreateBuilder().Build();

        // Assert
        Assert.NotNull(request.Data);
        Assert.Empty(request.Data);
    }

    private class TestModel
    {
        public string? RegularProperty { get; set; }

        [JsonPropertyName("custom_name")]
        public string? PropertyWithJsonName { get; set; }

        // Property that can't be read
        public string WriteOnlyProperty
        {
            set { }
        }

        public IEnumerable<int>? CollectionProperty { get; set; }
    }

    [Fact]
    public void WithChanges_WhenBeforeIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        TestModel? before = null;
        var after = new TestModel();

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => builder.WithChanges(before!, after));
        Assert.Equal("before", exception.ParamName);
    }

    [Fact]
    public void WithChanges_WhenAfterIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var before = new TestModel();
        TestModel? after = null;

        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => builder.WithChanges(before, after!));
        Assert.Equal("after", exception.ParamName);
    }

    [Fact]
    public void WithChanges_WithWriteOnlyProperty_SkipsProperty()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var before = new TestModel();
        var after = new TestModel();

        // Act
        var request = builder.WithChanges(before, after).Build();

        // Assert
        Assert.Empty(request.Data);
    }

    [Fact]
    public void WithChanges_WithJsonPropertyNameAttribute_UsesCustomName()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var before = new TestModel { PropertyWithJsonName = "old" };
        var after = new TestModel { PropertyWithJsonName = "new" };

        // Act
        var request = builder.WithChanges(before, after).Build();

        // Assert
        Assert.True(request.Data.ContainsKey("custom_name"));
        Assert.Equal("new", request.Data["custom_name"]);
    }

    [Fact]
    public void WithChanges_BothValuesNull_NoChange()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var before = new TestModel { RegularProperty = null };
        var after = new TestModel { RegularProperty = null };

        // Act
        var request = builder.WithChanges(before, after).Build();

        // Assert
        Assert.Empty(request.Data);
    }

    [Fact]
    public void WithChanges_CollectionPropertyChanged_AddsToData()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var before = new TestModel { CollectionProperty = [1, 2] };
        var after = new TestModel { CollectionProperty = [1] };

        // Act
        var request = builder.WithChanges(before, after).Build();

        // Assert
        Assert.True(request.Data.ContainsKey("CollectionProperty"));
        Assert.Equal(after.CollectionProperty, request.Data["CollectionProperty"]);
    }

    [Fact]
    public void WithChanges_CollectionPropertySameReference_NoChange()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var collection = new[] { 1 };
        var before = new TestModel { CollectionProperty = collection };
        var after = new TestModel { CollectionProperty = collection };

        // Act
        var request = builder.WithChanges(before, after).Build();

        // Assert
        Assert.Empty(request.Data);
    }

    [Fact]
    public void WithChanges_PropertyChangedFromNullToValue_AddsToData()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var before = new TestModel { RegularProperty = null };
        var after = new TestModel { RegularProperty = "value" };

        // Act
        var request = builder.WithChanges(before, after).Build();

        // Assert
        Assert.True(request.Data.ContainsKey("RegularProperty"));
        Assert.Equal("value", request.Data["RegularProperty"]);
    }

    [Fact]
    public void WithChanges_PropertyChangedFromValueToNull_AddsToData()
    {
        // Arrange
        var builder = UpdateDocumentRequest.CreateBuilder();
        var before = new TestModel { RegularProperty = "value" };
        var after = new TestModel { RegularProperty = null };

        // Act
        var request = builder.WithChanges(before, after).Build();

        // Assert
        Assert.True(request.Data.ContainsKey("RegularProperty"));
        Assert.Null(request.Data["RegularProperty"]);
    }
}
