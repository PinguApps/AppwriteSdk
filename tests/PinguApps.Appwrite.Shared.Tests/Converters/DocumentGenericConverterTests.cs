using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class DocumentGenericConverterTests
{
    private readonly JsonSerializerOptions _options;

    public DocumentGenericConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters = { new DocumentGenericConverter<TestData>() }
        };
    }

    public class TestData
    {
        public string? Field1 { get; set; }
        public int Field2 { get; set; }
        public bool Field3 { get; set; }
        public DateTime? Field4 { get; set; }
        public List<string>? Field5 { get; set; }
        public Dictionary<string, object?>? Field6 { get; set; }
        public float? FloatField { get; set; }
        public long? LongField { get; set; }
        public double? DoubleField { get; set; }
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
            ""Field1"": ""value1"",
            ""Field2"": 42,
            ""Field3"": true,
            ""Field4"": ""2020-10-15T06:38:00.000+00:00"",
            ""Field5"": [""item1"", ""item2""],
            ""Field6"": { ""key1"": ""value1"", ""key2"": 2 }
        }";

        var document = JsonSerializer.Deserialize<Document<TestData>>(json, _options);

        Assert.NotNull(document);
        Assert.Equal("1", document.Id);
        Assert.Equal("col1", document.CollectionId);
        Assert.Equal("db1", document.DatabaseId);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00"), document.CreatedAt);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00"), document.UpdatedAt);
        Assert.Single(document.Permissions);
        Assert.Equal(PermissionType.Read, document.Permissions[0].PermissionType);
        Assert.Equal(RoleType.Any, document.Permissions[0].RoleType);

        Assert.NotNull(document.Data);
        Assert.Equal("value1", document.Data.Field1);
        Assert.Equal(42, document.Data.Field2);
        Assert.True(document.Data.Field3);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00"), document.Data.Field4);
        Assert.Equal(new List<string> { "item1", "item2" }, document.Data.Field5);

        Assert.NotNull(document.Data.Field6);
        var field6 = document.Data.Field6!;
        Assert.Equal(2, field6.Count);

        // Extract values from JsonElement
        Assert.True(field6.ContainsKey("key1"));
        Assert.Equal("value1", field6["key1"]?.ToString());

        Assert.True(field6.ContainsKey("key2"));
        Assert.Equal(2, Convert.ToInt32(field6["key2"]?.ToString()));
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
                ""Field1"": ""value1""
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
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
                ""Field1"": ""value1""
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
    }

    [Fact]
    public void Write_ValidDocument_WritesJson()
    {
        var testData = new TestData
        {
            Field1 = "value1",
            Field2 = 42,
            Field3 = true,
            Field4 = DateTime.Parse("2020-10-15T06:38:00.000+00:00"),
            Field5 = ["item1", "item2"],
            Field6 = new Dictionary<string, object?> { { "key1", "value1" }, { "key2", 2 } }
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.Parse("2020-10-15T06:38:00.000+00:00"),
            DateTime.Parse("2020-10-15T06:38:00.000+00:00"),
            [Permission.Read().Any()],
            testData
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
                ""Field1"": ""value1"",
                ""Field2"": 42,
                ""Field3"": true,
                ""Field4"": ""2020-10-15T06:38:00.000+00:00"",
                ""Field5"": [""item1"", ""item2""],
                ""Field6"": { ""key1"": ""value1"", ""key2"": 2 },
                ""FloatField"": null,
                ""LongField"": null,
                ""DoubleField"": null
            }".ReplaceLineEndings("").Replace(" ", "");

        Assert.Equal(JsonDocument.Parse(expectedJson).RootElement.ToString(), JsonDocument.Parse(json).RootElement.ToString());
    }

    [Fact]
    public void Write_NullData_WritesJsonWithNoDataProperties()
    {
        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [Permission.Read().Any()],
            null!
        );

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"$id\"", json);
        Assert.DoesNotContain("\"Field1\"", json);
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
                ""Field1"": null
            }";

        var document = JsonSerializer.Deserialize<Document<TestData>>(json, _options);

        Assert.NotNull(document);
        Assert.NotNull(document.Data);
        Assert.Null(document.Data.Field1);
    }

    [Fact]
    public void Write_NullValue_SerializesCorrectly()
    {
        var testData = new TestData
        {
            Field1 = null
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [Permission.Read().Any()],
            testData
        );

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"Field1\":null", json);
    }

    //[Fact]
    //public void ReadValue_UnsupportedTokenType_ThrowsJsonException()
    //{
    //    var json = @"
    //        {
    //            ""$id"": ""1"",
    //            ""$collectionId"": ""col1"",
    //            ""$databaseId"": ""db1"",
    //            ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
    //            ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
    //            ""$permissions"": [""read(\""any\"")""],
    //            ""unsupported"": /** comment */
    //        }";

    //    Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
    //}

    [Fact]
    public void Write_CustomObject_SerializesUsingJsonSerializer()
    {
        var testData = new TestData
        {
            Field6 = new Dictionary<string, object?>
            {
                { "nestedObject", new { Prop1 = "value1", Prop2 = 2 } }
            }
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [Permission.Read().Any()],
            testData
        );

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"Prop1\":\"value1\"", json);
        Assert.Contains("\"Prop2\":2", json);
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
                    ""Field1"": ""value1""
                }
            ]";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
    }

    [Fact]
    public void Write_DateTimeValue_SerializesCorrectly()
    {
        var testData = new TestData
        {
            Field4 = DateTime.Parse("2020-10-15T06:38:00.000+00:00")
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            testData
        );

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"Field4\":\"2020-10-15T06:38:00.000+00:00\"", json);
    }

    [Fact]
    public void Write_NullDataProperty_WritesNull()
    {
        var testData = new TestData
        {
            Field5 = null
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            testData
        );

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"Field5\":null", json);
    }

    [Fact]
    public void Write_BooleanValue_SerializesCorrectly()
    {
        var testData = new TestData
        {
            Field3 = true
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            testData
        );

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"Field3\":true", json);
    }

    [Fact]
    public void Write_NumberValues_SerializesCorrectly()
    {
        var testData = new TestData
        {
            Field2 = 123
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            testData
        );

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"Field2\":123", json);
    }

    [Fact]
    public void Read_MissingId_ThrowsJsonException()
    {
        var json = @"
            {
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
                ""Field1"": ""value1""
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
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
                ""$permissions"": [""read(\""any\"")""],
                ""Field1"": ""value1""
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
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
                ""$permissions"": [""read(\""any\"")""],
                ""Field1"": ""value1""
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
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
                ""$permissions"": [""read(\""any\"")""],
                ""Field1"": ""value1""
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
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
                ""$permissions"": [""read(\""any\"")""],
                ""Field1"": ""value1""
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
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
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""Field1"": ""value1""
            }";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Document<TestData>>(json, _options));
    }

    [Fact]
    public void Write_NullDocumentData_SerializesCorrectly()
    {
        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            null!
        );

        var json = JsonSerializer.Serialize(document, _options);

        Assert.Contains("\"$id\"", json);
        Assert.DoesNotContain("\"Field1\"", json);
    }

    // Custom converter that returns null during deserialization
    public class NullReturningConverter<T> : JsonConverter<T> where T : class
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Always return null
            reader.Skip(); // Skip the current value to avoid infinite loops
            return null;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            // Write null
            writer.WriteNullValue();
        }
    }

    [Fact]
    public void Read_DataDeserializationReturnsNull_DataSetToNewInstance()
    {
        var json = @"
            {
                ""$id"": ""1"",
                ""$collectionId"": ""col1"",
                ""$databaseId"": ""db1"",
                ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
                ""$permissions"": [""read(\""any\"")""],
                ""Field1"": ""value1"",
                ""Field2"": 42
            }";

        // Create new options with the NullReturningConverter for TestData
        var optionsWithNullConverter = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Converters =
            {
                new NullReturningConverter<TestData>(),
                new DocumentGenericConverter<TestData>(),
                new MultiFormatDateTimeConverter(),
                new PermissionListConverter()
            }
        };

        var document = JsonSerializer.Deserialize<Document<TestData>>(json, optionsWithNullConverter);

        Assert.NotNull(document);
        Assert.NotNull(document.Data);
        // Since data deserialization returned null, Data should be set to new TData()
        // So Data's properties should have default values
        Assert.Null(document.Data.Field1);
        Assert.Equal(0, document.Data.Field2);
    }

    [Fact]
    public void ReadValue_UnsupportedTokenType_ThrowsJsonException()
    {
        var json = @"{
            ""Field1"": /* Comment */ ""value1""
        }";

        var readerOptions = new JsonReaderOptions
        {
            CommentHandling = JsonCommentHandling.Allow
        };

        var bytes = Encoding.UTF8.GetBytes(json);

        var reader = new Utf8JsonReader(bytes, readerOptions);

        var converter = new DocumentGenericConverter<TestData>();

        // Read the StartObject token
        reader.Read(); // JsonTokenType.StartObject

        // Read the PropertyName token
        reader.Read(); // JsonTokenType.PropertyName

        var propertyName = reader.GetString()!;

        // Read the Comment token
        reader.Read(); // JsonTokenType.Comment

        // At this point, reader.TokenType is Comment, which is not handled in ReadValue
        // Calling ReadValue should now hit the default case and throw JsonException
        try
        {
            converter.ReadValue(ref reader, _options);
            Assert.Fail("Did not throw JsonException");
        }
        catch (JsonException)
        {
        }
    }

    [Fact]
    public void ReadValue_FloatNumber_ReturnsSingle()
    {
        var json = @"
        {
            ""$id"": ""1"",
            ""$collectionId"": ""col1"",
            ""$databaseId"": ""db1"",
            ""$createdAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$updatedAt"": ""2020-10-15T06:38:00.000+00:00"",
            ""$permissions"": [""read(\""any\"")""],
            ""FloatField"": 1.23
        }";

        var document = JsonSerializer.Deserialize<Document<TestData>>(json, _options);

        Assert.NotNull(document);
        Assert.NotNull(document.Data);
        Assert.Equal(1.23f, document.Data.FloatField);
    }

    [Fact]
    public void WriteValue_UndefinedValueKind_CallsJsonSerializer()
    {
        var converter = new DocumentGenericConverter<TestData>();

        // Create a default-initialized JsonElement (ValueKind is Undefined)
        JsonElement undefinedElement = default;

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Since JsonSerializer.Serialize will throw an exception when trying to serialize an undefined JsonElement,
        // we can expect an InvalidOperationException
        Assert.Throws<JsonException>(() => converter.WriteValue(writer, undefinedElement, _options));
    }

    [Fact]
    public void WriteValue_LongNumber_WritesLongValue()
    {
        var testData = new TestData
        {
            LongField = (long)int.MaxValue + 1  // Value larger than int.MaxValue
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            testData
        );

        var json = JsonSerializer.Serialize(document, _options);

        // Verify that the LongField is serialized correctly
        var jsonDoc = JsonDocument.Parse(json);
        Assert.True(jsonDoc.RootElement.TryGetProperty("LongField", out var longFieldElement));
        Assert.Equal(JsonValueKind.Number, longFieldElement.ValueKind);
        Assert.Equal((long)int.MaxValue + 1, longFieldElement.GetInt64());
    }

    [Fact]
    public void WriteValue_DoubleNumber_WritesDoubleValue()
    {
        var testData = new TestData
        {
            DoubleField = 1.23e20  // A large double value
        };

        var document = new Document<TestData>(
            "1",
            "col1",
            "db1",
            DateTime.UtcNow,
            DateTime.UtcNow,
            [],
            testData
        );

        var json = JsonSerializer.Serialize(document, _options);

        // Verify that the DoubleField is serialized correctly
        var jsonDoc = JsonDocument.Parse(json);
        Assert.True(jsonDoc.RootElement.TryGetProperty("DoubleField", out var doubleFieldElement));
        Assert.Equal(JsonValueKind.Number, doubleFieldElement.ValueKind);
        Assert.Equal(1.23e20, doubleFieldElement.GetDouble());
    }
}
