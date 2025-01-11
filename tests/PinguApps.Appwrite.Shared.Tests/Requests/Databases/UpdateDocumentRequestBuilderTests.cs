using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;
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
        Assert.NotNull(request.Permissions);
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
        Assert.NotNull(request.Permissions);
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
    public enum TestEnum
    {
        FirstValue,
        SecondValue
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

    [Fact]
    public void AddField_WhenValueIsEnum_StoresEnumAsString()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        var enumValue = TestEnum.FirstValue;

        // Act
        builder.AddField("enumField", enumValue);

        // Assert
        var request = builder.Build();
        var data = request.Data;

        Assert.True(data.ContainsKey("enumField"));
        Assert.Equal("FirstValue", data["enumField"]);
    }

    [Fact]
    public void AddField_WhenValueIsPrimitive_StoresValue()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        sbyte primitiveValue = 42;

        // Act
        builder.AddField("field", primitiveValue);

        // Assert
        var request = builder.Build();
        Assert.Equal(primitiveValue, request.Data["field"]);
    }

    [Fact]
    public void AddField_WhenValueIsString_StoresValue()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        string stringValue = "test";

        // Act
        builder.AddField("field", stringValue);

        // Assert
        var request = builder.Build();
        Assert.Equal(stringValue, request.Data["field"]);
    }

    [Fact]
    public void AddField_WhenValueIsDateTime_StoresValue()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        DateTime dateValue = new DateTime(2024, 1, 1);

        // Act
        builder.AddField("field", dateValue);

        // Assert
        var request = builder.Build();
        Assert.Equal(dateValue, request.Data["field"]);
    }

    [Fact]
    public void AddField_WhenValueIsDateTimeOffset_StoresValue()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        DateTimeOffset dateOffsetValue = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

        // Act
        builder.AddField("field", dateOffsetValue);

        // Assert
        var request = builder.Build();
        Assert.Equal(dateOffsetValue, request.Data["field"]);
    }

    [Fact]
    public void AddField_WhenValueIsDecimal_StoresValue()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        decimal decimalValue = 42.42m;

        // Act
        builder.AddField("field", decimalValue);

        // Assert
        var request = builder.Build();
        Assert.Equal(decimalValue, request.Data["field"]);
    }

    [Fact]
    public void AddField_WhenValueIsEnum_StoresStringValue()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        TestEnum enumValue = TestEnum.FirstValue;

        // Act
        builder.AddField("field", enumValue);

        // Assert
        var request = builder.Build();
        Assert.Equal("FirstValue", request.Data["field"]);
    }

    [Fact]
    public void AddField_WhenValueIsNonStandardType_DoesNotStoreValue()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        var complexValue = new TestModel { RegularProperty = "test" };

        // Act
        builder.AddField("field", complexValue);

        // Assert
        var request = builder.Build();
        Assert.False(request.Data.ContainsKey("field"));
    }

    [Fact]
    public void AddField_WhenValueIsEnumerableOfNonStandardType_DoesNotStoreValue()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();
        var complexList = new List<TestModel>
        {
            new() { RegularProperty = "test" },
            new() { RegularProperty = "test2" }
        };

        // Act
        builder.AddField("field", complexList);

        // Assert
        var request = builder.Build();
        Assert.False(request.Data.ContainsKey("field"));
    }

    [Fact]
    public void WithChanges_WhenTypeIsDocument_HandlesDocumentChanges()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();

        var beforeDoc = new Document<TestData>(
            Id: "doc1",
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: DateTime.UtcNow.AddHours(-1),
            UpdatedAt: DateTime.UtcNow.AddHours(-1),
            Permissions: null,
            Data: new TestData
            {
                Name = "Before",
                Value = 1
            }
        );

        var afterDoc = new Document<TestData>(
            Id: "doc1",
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: beforeDoc.CreatedAt,
            UpdatedAt: DateTime.UtcNow,
            Permissions: null,
            Data: new TestData
            {
                Name = "After",
                Value = 2
            }
        );

        // Act
        builder.WithChanges(beforeDoc, afterDoc);

        // Assert
        var request = builder.Build();
        Assert.True(request.Data.ContainsKey("name"));
        Assert.Equal("After", request.Data["name"]);
        Assert.True(request.Data.ContainsKey("value"));
        Assert.Equal(2, request.Data["value"]);
    }

    private class TestData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    [Fact]
    public void WithChanges_WhenEnumerableValuesAreDifferent_DetectsChange()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();

        var beforeDoc = new Document<TestDataWithList>(
            Id: "doc1",
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: DateTime.UtcNow.AddHours(-1),
            UpdatedAt: DateTime.UtcNow.AddHours(-1),
            Permissions: null,
            Data: new TestDataWithList
            {
                Items = new List<string> { "item1", "item2" }
            }
        );

        var afterDoc = new Document<TestDataWithList>(
            Id: "doc1",
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: beforeDoc.CreatedAt,
            UpdatedAt: DateTime.UtcNow,
            Permissions: null,
            Data: new TestDataWithList
            {
                Items = new List<string> { "item1", "item3" }  // Changed item2 to item3
            }
        );

        // Act
        builder.WithChanges(beforeDoc, afterDoc);

        // Assert
        var request = builder.Build();
        Assert.True(request.Data.ContainsKey("items"));
        var items = Assert.IsType<List<string>>(request.Data["items"]);
        Assert.Equal(new List<string> { "item1", "item3" }, items);
    }

    private class TestDataWithList
    {
        [JsonPropertyName("items")]
        public List<string> Items { get; set; } = new();
    }

    [Fact]
    public void WithChanges_WhenDocumentDataIsNull_DoesNothing()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();

        var before = new Document<TestData>(
            Id: "doc1",
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: DateTime.UtcNow.AddHours(-1),
            UpdatedAt: DateTime.UtcNow.AddHours(-1),
            Permissions: null,
            Data: null!  // Force null despite non-nullable
        );

        var after = new Document<TestData>(
            Id: "doc1",
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: before.CreatedAt,
            UpdatedAt: DateTime.UtcNow,
            Permissions: null,
            Data: null!  // Force null despite non-nullable
        );

        // Act
        builder.WithChanges(before, after);

        // Assert
        var request = builder.Build();
        Assert.Empty(request.Data);
    }

    [Fact]
    public void WithChanges_WhenDocumentIdsAreDifferent_AddsAllProperties()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();

        var before = new Document<TestData>(
            Id: "doc1",  // Not null/empty
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: DateTime.UtcNow.AddHours(-1),
            UpdatedAt: DateTime.UtcNow.AddHours(-1),
            Permissions: null,
            Data: new TestData
            {
                Name = "Before",
                Value = 1
            }
        );

        var after = new Document<TestData>(
            Id: "doc2",  // Different ID
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: before.CreatedAt,
            UpdatedAt: DateTime.UtcNow,
            Permissions: null,
            Data: new TestData
            {
                Name = "After",
                Value = 1  // Same value, but should still be added because IDs don't match
            }
        );

        // Act
        builder.WithChanges(before, after);

        // Assert
        var request = builder.Build();
        // Should add all properties, even if they haven't changed
        Assert.True(request.Data.ContainsKey("name"));
        Assert.Equal("After", request.Data["name"]);
        Assert.True(request.Data.ContainsKey("value"));
        Assert.Equal(1, request.Data["value"]);
    }

    [Fact]
    public void WithChanges_WhenBothIdsAreNull_DoesNotCompareProperties()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();

        var before = new Document<TestData>(
            Id: "",
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: DateTime.UtcNow.AddHours(-1),
            UpdatedAt: DateTime.UtcNow.AddHours(-1),
            Permissions: null,
            Data: new TestData
            {
                Name = "Before",
                Value = 1
            }
        );

        var after = new Document<TestData>(
            Id: "",
            CollectionId: "col1",
            DatabaseId: "db1",
            CreatedAt: before.CreatedAt,
            UpdatedAt: DateTime.UtcNow,
            Permissions: null,
            Data: new TestData
            {
                Name = "After",
                Value = 2
            }
        );

        // Act
        builder.WithChanges(before, after);

        // Assert
        var request = builder.Build();
        Assert.NotEmpty(request.Data);
    }


    // Create a document type with a complex property
    public class ComplexType
    {
        public string SomeValue { get; set; } = string.Empty;
    }

    public class TestDataWithComplexType
    {
        public ComplexType? ComplexProperty { get; set; }
    }

    [Fact]
    public void WithChanges_WhenNonStandardPropertyIsSetToNull_ShouldSkipProperty()
    {
        // Arrange
        var builder = new UpdateDocumentRequestBuilder();


        // Create before document with a non-null complex property
        var beforeDoc = new Document<TestDataWithComplexType>(
            Id: "test-id",
            CollectionId: "test-collection",
            DatabaseId: "test-database",
            CreatedAt: DateTime.UtcNow,
            UpdatedAt: DateTime.UtcNow,
            Permissions: null,
            Data: new TestDataWithComplexType
            {
                ComplexProperty = new ComplexType { SomeValue = "test" }
            }
        );

        // Create after document with the same ID but null complex property
        var afterDoc = new Document<TestDataWithComplexType>(
            Id: "test-id",
            CollectionId: "test-collection",
            DatabaseId: "test-database",
            CreatedAt: DateTime.UtcNow,
            UpdatedAt: DateTime.UtcNow,
            Permissions: null,
            Data: new TestDataWithComplexType
            {
                ComplexProperty = null
            }
        );

        // Act
        var request = builder
            .WithChanges(beforeDoc, afterDoc)
            .Build();

        // Assert
        Assert.Empty(request.Data);  // The property should be skipped, resulting in no changes
    }
}
