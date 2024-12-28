using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class DocumentListGenericConverterTests
{
    public class TestData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "Test";

        [JsonPropertyName("age")]
        public int Age { get; set; } = 25;
    }


    private readonly JsonSerializerOptions _options;

    public DocumentListGenericConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Converters = { new DocumentListGenericConverter() }
        };
    }

    [Fact]
    public void Read_ShouldDeserializeDocumentList()
    {
        var json = "[{\"$id\":\"1\",\"$collectionId\":\"c1\",\"$databaseId\":\"d1\",\"$createdAt\":\"2020-10-15T06:38:00.000+00:00\",\"$updatedAt\":\"2020-10-15T06:38:00.000+00:00\",\"$permissions\":[],\"name\":\"Test\",\"age\":25}, {\"$id\":\"2\",\"$collectionId\":\"c2\",\"$databaseId\":\"d2\",\"$createdAt\":\"2020-10-15T06:38:00.000+00:00\",\"$updatedAt\":\"2020-10-15T06:38:00.000+00:00\",\"$permissions\":[],\"name\":\"Test2\",\"age\":30}]";
        var documents = JsonSerializer.Deserialize<IReadOnlyList<Document<TestData>>>(json, _options);

        Assert.NotNull(documents);
        Assert.Equal(2, documents.Count);
        Assert.Equal("1", documents[0].Id);
        Assert.Equal("2", documents[1].Id);
        Assert.Equal("Test", documents[0].Data.Name);
        Assert.Equal(25, documents[0].Data.Age);
        Assert.Equal("Test2", documents[1].Data.Name);
        Assert.Equal(30, documents[1].Data.Age);
    }

    [Fact]
    public void Read_ShouldThrowJsonExceptionForInvalidStartToken()
    {
        var json = "{\"id\":\"1\"}";
        var exception = Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<IReadOnlyList<Document<TestData>>>(json, _options));
        Assert.Equal("Expected start of array", exception.Message);
    }

    [Fact]
    public void Write_ShouldSerializeDocumentList()
    {
        var documents = new List<Document<TestData>>
        {
            new Document<TestData>("5e5ea5c16897e", "5e5ea5c15117e", "5e5ea5c15117e",
                DateTime.UtcNow, DateTime.UtcNow, [], new TestData { Name = "Test1", Age = 25 }),
            new Document<TestData>("5e5ea5c16897f", "5e5ea5c15117e", "5e5ea5c15117e",
                DateTime.UtcNow, DateTime.UtcNow, [], new TestData { Name = "Test2", Age = 30 })
        };

        var json = JsonSerializer.Serialize((IReadOnlyList<Document<TestData>>)documents, _options);

        Assert.Contains("\"$id\":\"5e5ea5c16897e\"", json);
        Assert.Contains("\"$id\":\"5e5ea5c16897f\"", json);
        Assert.Contains("\"name\":\"Test1\"", json);
        Assert.Contains("\"name\":\"Test2\"", json);
        Assert.Contains("\"age\":25", json);
        Assert.Contains("\"age\":30", json);
    }

    [Fact]
    public void Write_ShouldHandleEmptyList()
    {
        var documents = new List<Document<TestData>>();

        var json = JsonSerializer.Serialize((IReadOnlyList<Document<TestData>>)documents, _options);

        Assert.Equal("[]", json);
    }

    [Fact]
    public void CreateConverter_ShouldReturnNull_WhenNotDocumentGenericType()
    {
        // Arrange
        var converter = new DocumentListGenericConverter();
        var options = new JsonSerializerOptions();
        var listType = typeof(IReadOnlyList<string>); // Using string as a non-Document<T> type

        // Act
        var result = converter.CreateConverter(listType, options);

        // Assert
        Assert.Null(result);
    }
}
