using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class AlwaysWriteNullableDateTimeConverterTests
{
    private readonly AlwaysWriteNullableDateTimeConverter _converter;
    private readonly JsonSerializerOptions _options;

    public AlwaysWriteNullableDateTimeConverterTests()
    {
        _converter = new AlwaysWriteNullableDateTimeConverter();
        _options = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        _options.Converters.Add(_converter);
    }

    [Fact]
    public void Write_WhenValueIsNull_WritesNullValue()
    {
        // Arrange
        DateTime? value = null;
        var json = JsonSerializer.SerializeToUtf8Bytes(value, _options);
        using var doc = JsonDocument.Parse(json);
        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Act
        _converter.Write(writer, value, _options);
        writer.Flush();

        // Assert
        stream.Position = 0;
        using var result = JsonDocument.Parse(stream);
        Assert.Equal(JsonValueKind.Null, result.RootElement.ValueKind);
    }

    [Fact]
    public void Write_WhenValueHasValue_CallsBaseConverter()
    {
        // Arrange
        var testDate = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        DateTime? value = testDate;

        // Act
        var json = JsonSerializer.Serialize(value, _options);
        var deserializedValue = JsonSerializer.Deserialize<DateTime?>(json, _options);

        // Assert
        Assert.NotNull(deserializedValue);
        Assert.Equal(testDate, deserializedValue.Value);
    }

    // Test class to verify serialization behavior in a property context
    private class TestClass
    {
        [JsonConverter(typeof(AlwaysWriteNullableDateTimeConverter))]
        public DateTime? Date { get; set; }
    }

    [Fact]
    public void Serialize_WhenPropertyIsNull_IncludesNullInOutput()
    {
        // Arrange
        var testObject = new TestClass { Date = null };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);

        // Assert
        Assert.Contains("\"Date\":null", json);
    }

    [Fact]
    public void Serialize_WhenPropertyHasValue_SerializesDateTime()
    {
        // Arrange
        var testDate = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var testObject = new TestClass { Date = testDate };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);
        var deserialized = JsonSerializer.Deserialize<TestClass>(json, _options);

        // Assert
        Assert.NotNull(deserialized?.Date);
        Assert.Equal(testDate, deserialized.Date.Value);
    }
}
