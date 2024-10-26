using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class DocumentListConverterTests
{
    private readonly JsonSerializerOptions _options;

    public DocumentListConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Converters = { new DocumentListConverter() }
        };
    }

    [Fact]
    public void Read_ShouldDeserializeDocumentList()
    {
        var json = "[{\"$id\":\"1\",\"$collectionId\":\"c1\",\"$databaseId\":\"d1\",\"$createdAt\":\"2020-10-15T06:38:00.000+00:00\",\"$updatedAt\":\"2020-10-15T06:38:00.000+00:00\",\"$permissions\":[]}, {\"$id\":\"2\",\"$collectionId\":\"c2\",\"$databaseId\":\"d2\",\"$createdAt\":\"2020-10-15T06:38:00.000+00:00\",\"$updatedAt\":\"2020-10-15T06:38:00.000+00:00\",\"$permissions\":[]}]";
        var documents = JsonSerializer.Deserialize<IReadOnlyList<Document>>(json, _options);

        Assert.NotNull(documents);
        Assert.Equal(2, documents.Count);
        Assert.Equal("1", documents[0].Id);
        Assert.Equal("2", documents[1].Id);
    }

    [Fact]
    public void Read_ShouldThrowJsonExceptionForInvalidStartToken()
    {
        var json = "{\"id\":\"1\"}";
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<IReadOnlyList<Document>>(json, _options));
        Assert.Equal("Expected start of array", exception.Message);
    }

    [Fact]
    public void Write_ShouldSerializeDocumentList()
    {
        var documents = new List<Document>
        {
            new Document("5e5ea5c16897e", "5e5ea5c15117e", "5e5ea5c15117e", DateTime.UtcNow, DateTime.UtcNow, [], []),
            new Document("5e5ea5c16897f", "5e5ea5c15117e", "5e5ea5c15117e", DateTime.UtcNow, DateTime.UtcNow, [], [])
        };

        var json = JsonSerializer.Serialize((IReadOnlyList<Document>)documents, _options);

        Assert.Contains("\"$id\":\"5e5ea5c16897e\"", json);
        Assert.Contains("\"$id\":\"5e5ea5c16897f\"", json);
    }

    [Fact]
    public void Write_ShouldHandleEmptyList()
    {
        var documents = new List<Document>();

        var json = JsonSerializer.Serialize((IReadOnlyList<Document>)documents, _options);

        Assert.Equal("[]", json);
    }
}
