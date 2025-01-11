using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class UpdateDocumentRequestConverterTests
{
    private readonly UpdateDocumentRequestConverter _converter;
    private readonly JsonSerializerOptions _defaultOptions;
    private readonly JsonSerializerOptions _sdkOptions;

    public UpdateDocumentRequestConverterTests()
    {
        _converter = new UpdateDocumentRequestConverter();

        // Setup default options without SDK marker
        _defaultOptions = new JsonSerializerOptions();

        // Setup options with SDK marker
        _sdkOptions = new JsonSerializerOptions();
        _sdkOptions.Converters.Add(new SdkMarkerConverter());
    }

    [Fact]
    public void Read_ThrowsNotImplementedException()
    {
        // Arrange
        var json = "{}";
        var reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
        var threw = false;

        // Act
        try
        {
            _converter.Read(ref reader, typeof(UpdateDocumentRequest), _defaultOptions);
        }
        catch (NotImplementedException)
        {
            threw = true;
        }

        // Assert
        Assert.True(threw, "Expected NotImplementedException was not thrown");
    }

    [Fact]
    public void Write_WithoutSdk_WritesCollectionAndDatabaseIds()
    {
        // Arrange
        var request = new UpdateDocumentRequest
        {
            CollectionId = "col123",
            DatabaseId = "db456",
            Data = []
        };

        // Act
        var json = JsonSerializer.Serialize(request, _defaultOptions);

        // Assert
        var jsonDoc = JsonDocument.Parse(json);
        Assert.Equal("col123", jsonDoc.RootElement.GetProperty("$collectionId").GetString());
        Assert.Equal("db456", jsonDoc.RootElement.GetProperty("$databaseId").GetString());
    }

    [Fact]
    public void Write_WithSdk_DoesNotWriteCollectionAndDatabaseIds()
    {
        // Arrange
        var request = new UpdateDocumentRequest
        {
            CollectionId = "col123",
            DatabaseId = "db456",
            Data = []
        };

        // Act
        var json = JsonSerializer.Serialize(request, _sdkOptions);

        // Assert
        var jsonDoc = JsonDocument.Parse(json);
        Assert.False(jsonDoc.RootElement.TryGetProperty("$collectionId", out _));
        Assert.False(jsonDoc.RootElement.TryGetProperty("$databaseId", out _));
    }

    [Fact]
    public void Write_WithPermissions_WritesPermissionsProperty()
    {
        // Arrange
        var request = new UpdateDocumentRequest
        {
            Permissions = [Permission.Read().Any()],
            Data = []
        };

        // Act
        var json = JsonSerializer.Serialize(request, _defaultOptions);

        // Assert
        var jsonDoc = JsonDocument.Parse(json);
        Assert.True(jsonDoc.RootElement.TryGetProperty("permissions", out var permissionsElement));
        Assert.Equal(JsonValueKind.Array, permissionsElement.ValueKind);
    }

    [Fact]
    public void Write_WithoutPermissions_DoesNotWritePermissionsProperty()
    {
        // Arrange
        var request = new UpdateDocumentRequest
        {
            Permissions = null,
            Data = []
        };

        // Act
        var json = JsonSerializer.Serialize(request, _defaultOptions);

        // Assert
        var jsonDoc = JsonDocument.Parse(json);
        Assert.False(jsonDoc.RootElement.TryGetProperty("permissions", out _));
    }

    [Fact]
    public void Write_WithData_WritesDataProperty()
    {
        // Arrange
        var request = new UpdateDocumentRequest
        {
            Data = new Dictionary<string, object?>
            {
                { "name", "John" },
                { "age", 30 }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(request, _defaultOptions);

        // Assert
        var jsonDoc = JsonDocument.Parse(json);
        Assert.True(jsonDoc.RootElement.TryGetProperty("data", out var dataElement));
        Assert.Equal("John", dataElement.GetProperty("name").GetString());
        Assert.Equal(30, dataElement.GetProperty("age").GetInt32());
    }

    [Fact]
    public void Write_WithEmptyData_DoesNotWriteDataProperty()
    {
        // Arrange
        var request = new UpdateDocumentRequest
        {
            Data = []
        };

        // Act
        var json = JsonSerializer.Serialize(request, _defaultOptions);

        // Assert
        var jsonDoc = JsonDocument.Parse(json);
        Assert.False(jsonDoc.RootElement.TryGetProperty("data", out _));
    }

    [Fact]
    public void Write_WithComplexDataTypes_SerializesCorrectly()
    {
        // Arrange
        var request = new UpdateDocumentRequest
        {
            Data = new Dictionary<string, object?>
            {
                { "array", new[] { 1, 2, 3 } },
                { "nested", new Dictionary<string, object>
                    {
                        { "key", "value" }
                    }
                }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(request, _defaultOptions);

        // Assert
        var jsonDoc = JsonDocument.Parse(json);
        var dataElement = jsonDoc.RootElement.GetProperty("data");
        Assert.Equal(JsonValueKind.Array, dataElement.GetProperty("array").ValueKind);
        Assert.Equal(JsonValueKind.Object, dataElement.GetProperty("nested").ValueKind);
    }

    [Fact]
    public void Write_WithAllProperties_GeneratesCorrectJson()
    {
        // Arrange
        var request = new UpdateDocumentRequest
        {
            CollectionId = "col123",
            DatabaseId = "db456",
            Permissions = [Permission.Read().Any()],
            Data = new Dictionary<string, object?>
            {
                { "name", "John" }
            }
        };

        // Act
        var json = JsonSerializer.Serialize(request, _defaultOptions);

        // Assert
        var jsonDoc = JsonDocument.Parse(json);
        Assert.Equal("col123", jsonDoc.RootElement.GetProperty("$collectionId").GetString());
        Assert.Equal("db456", jsonDoc.RootElement.GetProperty("$databaseId").GetString());
        Assert.True(jsonDoc.RootElement.TryGetProperty("permissions", out _));
        Assert.True(jsonDoc.RootElement.TryGetProperty("data", out var dataElement));
        Assert.Equal("John", dataElement.GetProperty("name").GetString());
    }
}
