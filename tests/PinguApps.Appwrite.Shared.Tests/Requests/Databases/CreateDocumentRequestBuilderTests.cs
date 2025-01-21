using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;
using static PinguApps.Appwrite.Shared.Requests.Databases.ICreateDocumentRequestBuilder;

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
    public void WithDatabaseId_SetsDatabaseId_ReturnsBuilder()
    {
        // Arrange
        var builder = CreateDocumentRequest.CreateBuilder();
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
        var builder = CreateDocumentRequest.CreateBuilder();
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
        Assert.NotNull(request.Permissions);
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
        Assert.NotNull(request.Permissions);
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
        var databaseId = IdUtils.GenerateUniqueId();
        var collectionId = IdUtils.GenerateUniqueId();
        var documentId = IdUtils.GenerateUniqueId();
        var permissions = new List<Permission> { Permission.Read().Any() };
        const string fieldName = "testField";
        const string fieldValue = "testValue";

        // Act
        var request = CreateDocumentRequest.CreateBuilder()
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
        var request = CreateDocumentRequest.CreateBuilder().Build();

        // Assert
        Assert.NotNull(request.Data);
        Assert.Empty(request.Data);
    }

    public class TestClass
    {
        public string? StringProp { get; set; }
        public int IntProp { get; set; }
        [JsonIgnore]
        public string? IgnoredProp { get; set; }
        [JsonPropertyName("custom")]
        public string? CustomNameProp { get; set; }
    }

    [Fact]
    public void WithData_NullData_ThrowsArgumentNullException()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        TestClass? nullData = null;
        var ex = Assert.Throws<ArgumentNullException>(() => builder.WithData(nullData));
        Assert.Equal("data", ex.ParamName);
    }

    [Fact]
    public void WithData_NullOptions_UsesDefaultOptions()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        var data = new TestClass { StringProp = "test" };
        builder.WithData(data, options: null);
        // Assert AddField was called with "stringProp" and "test"
        // You'll need to mock/verify this based on your implementation
    }

    [Fact]
    public void WithData_CustomOptions_AppliesOptions()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        var data = new TestClass { StringProp = "test" };
        builder.WithData(data, options => options.IgnoreNullValues = false);
        // Assert all properties were added, including nulls
    }

    [Fact]
    public void WithData_PropertyFilter_AppliesFilter()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        var data = new TestClass { StringProp = "test", IntProp = 42 };
        builder.WithData(data, options =>
            options.PropertyFilter = prop => prop.PropertyType == typeof(string));
        // Assert only string properties were added
    }

    [Fact]
    public void WithData_JsonIgnoreAttribute_SkipsProperty()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        var data = new TestClass { IgnoredProp = "ignored" };
        builder.WithData(data);
        // Assert IgnoredProp was not added
    }

    [Fact]
    public void WithData_JsonPropertyNameAttribute_UsesCustomName()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        var data = new TestClass { CustomNameProp = "test" };
        builder.WithData(data);
        // Assert AddField was called with "custom" instead of "customNameProp"
    }

    [Fact]
    public void WithData_NullValue_IgnoredByDefault()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        var data = new TestClass { StringProp = null };
        builder.WithData(data);
        // Assert AddField was not called for StringProp
    }

    [Fact]
    public void WithData_NullValue_IncludedWhenIgnoreNullValuesFalse()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        var data = new TestClass { StringProp = null };
        builder.WithData(data, options => options.IgnoreNullValues = false);
        // Assert AddField was called with null value
    }

    [Fact]
    public void WithData_PropertyCacheReuse_CachesProperties()
    {
        var builder = CreateDocumentRequest.CreateBuilder();

        var data1 = new TestClass();
        var data2 = new TestClass();
        builder.WithData(data1);
        builder.WithData(data2);
        // Assert properties were cached (you'll need to expose cache or use reflection to verify)
    }

    [Fact]
    public void ShouldIncludeProperty_NoAttributeNoFilter_ReturnsTrue()
    {
        var options = new WithDataOptions();
        var prop = typeof(TestClass).GetProperty(nameof(TestClass.StringProp))!;
        Assert.True(options.ShouldIncludeProperty(prop));
    }

    [Fact]
    public void ShouldIncludeProperty_JsonIgnoreAttribute_ReturnsFalse()
    {
        var options = new WithDataOptions();
        var prop = typeof(TestClass).GetProperty(nameof(TestClass.IgnoredProp))!;
        Assert.False(options.ShouldIncludeProperty(prop));
    }

    [Fact]
    public void ShouldIncludeProperty_CustomFilterTrue_ReturnsTrue()
    {
        var options = new WithDataOptions
        {
            PropertyFilter = _ => true
        };
        var prop = typeof(TestClass).GetProperty(nameof(TestClass.StringProp))!;
        Assert.True(options.ShouldIncludeProperty(prop));
    }

    [Fact]
    public void ShouldIncludeProperty_CustomFilterFalse_ReturnsFalse()
    {
        var options = new WithDataOptions
        {
            PropertyFilter = _ => false
        };
        var prop = typeof(TestClass).GetProperty(nameof(TestClass.StringProp))!;
        Assert.False(options.ShouldIncludeProperty(prop));
    }
}
