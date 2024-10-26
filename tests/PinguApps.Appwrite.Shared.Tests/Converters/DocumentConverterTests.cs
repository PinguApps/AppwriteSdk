using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class DocumentConverterTests
{
    private readonly JsonSerializerOptions _options;

    public DocumentConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = { new DocumentConverter() }
        };
    }

    [Fact]
    public void Read_ValidJson_ReturnsDocument()
    {
        var json = @"
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
                ""customField"": ""customValue""
            }";

        var document = JsonSerializer.Deserialize<Document>(json, _options);

        Assert.NotNull(document);
        Assert.Equal("1", document.Id);
        Assert.Equal("col1", document.CollectionId);
        Assert.Equal("db1", document.DatabaseId);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00"), document.CreatedAt);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00"), document.UpdatedAt);
        Assert.Single(document.Permissions);
        Assert.Equal(PermissionType.Read, document.Permissions[0].PermissionType);
        Assert.Equal(RoleType.Any, document.Permissions[0].RoleType);
        Assert.Equal("customValue", document["customField"]);
    }

    [Fact]
    public void Read_InvalidJson_ThrowsJsonException()
    {
        var json = @"
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""invalid-date"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void Read_MissingRequiredFields_ThrowsJsonException()
    {
        var json = @"
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void Write_ValidDocument_WritesJson()
    {
        var document = new Document(
            "1",
            "col1",
            "db1",
            DateTime.Parse("2020-10-15T06:38:00.000+00:00"),
            DateTime.Parse("2020-10-15T06:38:00.000+00:00"),
            [Permission.Read().Any()],
            new Dictionary<string, object?> { { "customField", "customValue" } }
        );

        var json = JsonSerializer.Serialize(document, _options);

        var expectedJson = @"
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
                ""customField"": ""customValue""
            }".ReplaceLineEndings("").Replace(" ", "");

        Assert.Equal(JsonDocument.Parse(expectedJson).RootElement.ToString(), JsonDocument.Parse(json).RootElement.ToString());
    }

    [Fact]
    public void Write_NullValue_WritesNull()
    {
        var document = new Document(
            "1",
            "col1",
            "db1",
            DateTime.Parse("2020-10-15T06:38:00.000+00:00"),
            DateTime.Parse("2020-10-15T06:38:00.000+00:00"),
            [Permission.Read().Any()],
            new Dictionary<string, object?> { { "customField", null } }
        );

        var json = JsonSerializer.Serialize(document, _options);

        var expectedJson = @"
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
                ""customField"": null
            }".ReplaceLineEndings("").Replace(" ", "");

        Assert.Equal(JsonDocument.Parse(expectedJson).RootElement.ToString(), JsonDocument.Parse(json).RootElement.ToString());
    }

    [Fact]
    public void ReadValue_UnsupportedTokenType_ThrowsJsonException()
    {
        var json = @"
            {
                ""unsupported"": {}
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void ReadArray_ValidJsonArray_ReturnsArray()
    {
        var json = @"
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
                ""arrayField"": [""value1"", ""value2""]
            }";

        var document = JsonSerializer.Deserialize<Document>(json, _options);

        Assert.NotNull(document);
        var arrayField = document["arrayField"] as IReadOnlyCollection<object?>;
        Assert.NotNull(arrayField);
        Assert.Contains("value1", arrayField);
        Assert.Contains("value2", arrayField);
    }

    [Fact]
    public void ReadObject_ValidJsonObject_ReturnsObject()
    {
        var json = @"
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
                ""objectField"": { ""key1"": ""value1"", ""key2"": ""value2"" }
            }";

        var document = JsonSerializer.Deserialize<Document>(json, _options);

        Assert.NotNull(document);
        var objectField = document["objectField"] as Dictionary<string, object?>;
        Assert.NotNull(objectField);
        Assert.Equal("value1", objectField["key1"]);
        Assert.Equal("value2", objectField["key2"]);
    }

    [Fact]
    public void Read_InvalidJsonTokenType_ThrowsJsonException()
    {
        var json = @"
        [
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
                ""customField"": ""customValue""
            }
        ]";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void Read_MissingCollectionId_ThrowsJsonException()
    {
        var json = @"
        {
            ""$id"": ""1"",
            ""$databaseId"": ""db1"",
            ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$permissions"": [""read(\""any\"")""]
        }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void Read_MissingDatabaseId_ThrowsJsonException()
    {
        var json = @"
        {
            ""$id"": ""1"",
            ""$collectionId"": ""col1"",
            ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$permissions"": [""read(\""any\"")""]
        }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void Read_MissingCreatedAt_ThrowsJsonException()
    {
        var json = @"
        {
            ""$id"": ""1"",
            ""$collectionId"": ""col1"",
            ""$databaseId"": ""db1"",
            ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$permissions"": [""read(\""any\"")""]
        }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void Read_MissingUpdatedAt_ThrowsJsonException()
    {
        var json = @"
        {
            ""$id"": ""1"",
            ""$collectionId"": ""col1"",
            ""$databaseId"": ""db1"",
            ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$permissions"": [""read(\""any\"")""]
        }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void Read_MissingPermissions_ThrowsJsonException()
    {
        var json = @"
        {
            ""$id"": ""1"",
            ""$collectionId"": ""col1"",
            ""$databaseId"": ""db1"",
            ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00""
        }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document>(json, _options));
    }

    [Fact]
    public void Read_NullProperty_InsertedIntoData()
    {
        var json = @"
        {
            ""$id"": ""1"",
            ""$collectionId"": ""col1"",
            ""$databaseId"": ""db1"",
            ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$permissions"": [""read(\""any\"")""],
            ""customField"": null
        }";

        var document = JsonSerializer.Deserialize<Document>(json, _options);

        Assert.NotNull(document);
        Assert.True(document.Data.ContainsKey("customField"));
        Assert.Null(document["customField"]);
    }

    [Fact]
    public void Read_Comment_ThrowsJsonException()
    {
        var json = @"{}";

        Assert.Throws<JsonException>(() =>
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
            while (reader.TokenType is not JsonTokenType.EndObject)
            {
                reader.Read();
            }

            var docReader = new DocumentConverter();

            docReader.ReadValue(ref reader, _options);
        });
    }

    [Fact]
    public void Write_IntValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "intField", 123 }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"intField\":123", json);
    }

    [Fact]
    public void Write_LongValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "longField", 12345L }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"longField\":12345", json);
    }

    [Fact]
    public void Write_FloatValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "floatField", 1.23f }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"floatField\":1.23", json);
    }

    [Fact]
    public void Write_DoubleValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "doubleField", 1.23d }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"doubleField\":1.23", json);
    }

    [Fact]
    public void Write_DecimalValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "decimalField", 1.23m }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"decimalField\":1.23", json);
    }

    [Fact]
    public void Write_BoolValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "boolField", true }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"boolField\":true", json);
    }

    [Fact]
    public void Write_DateTimeValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "datetimeField", DateTime.Parse("2020-10-15T06:38:00.000+00:00") }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"datetimeField\":\"2020-10-15T06:38:00.000+00:00\"", json);
    }

    [Fact]
    public void Write_ListValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "listField", new List<string>() { "val1","val2" } }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"listField\":[\"val1\",\"val2\"]", json);
    }

    [Fact]
    public void Write_DictValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "dictField", new Dictionary<string, object?> {
                    { "key", "val" }
                } }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"dictField\":{\"key\":\"val\"}}", json);
    }

    [Fact]
    public void Write_ObjectValue_SerializesCorrectly()
    {
        var document = new Document("1", "col1", "db1", DateTime.UtcNow, DateTime.UtcNow, [], new Dictionary<string, object?>
        {
            { "objectField", new { } }
        });

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"objectField\":{}}", json);
    }


}
