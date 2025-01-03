using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Tests.Converters;

public class NullableDateTimeConverterTests
{
    private readonly JsonSerializerOptions _options;

    public NullableDateTimeConverterTests()
    {
        _options = new JsonSerializerOptions()
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        _options.Converters.Add(new NullableDateTimeConverter());
    }

    [Fact]
    public void Read_ValidDateString_ReturnsDateTime()
    {
        var json = "\"2023-01-01T00:00:00.000+00:00\"";
        var result = JsonSerializer.Deserialize<DateTime?>(json, _options);
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1), result.Value);
    }

    [Fact]
    public void Read_EmptyString_ReturnsNull()
    {
        var json = "\"\"";
        var result = JsonSerializer.Deserialize<DateTime?>(json, _options);
        Assert.Null(result);
    }

    [Fact]
    public void Read_NullToken_ReturnsNull()
    {
        var json = "null";
        var result = JsonSerializer.Deserialize<DateTime?>(json, _options);
        Assert.Null(result);
    }

    public class NullableDateTimeObject
    {
        [JsonPropertyName("x")]
        [JsonConverter(typeof(NullableDateTimeConverter))]
        public DateTime? X { get; set; }
    }

    [Fact]
    public void Read_NullTokenInObject_ReturnsNull()
    {
        var json = "{\"x\": null}";
        var result = JsonSerializer.Deserialize<NullableDateTimeObject>(json, _options);
        Assert.NotNull(result);
        Assert.Null(result.X);
    }

    [Fact]
    public void Read_InvalidDateString_ThrowsJsonException()
    {
        var json = "\"invalid-date\"";
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DateTime?>(json, _options));
    }

    [Fact]
    public void Read_UnexpectedTokenType_ThrowsJsonException()
    {
        var json = "123";
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DateTime?>(json, _options));
    }

    [Fact]
    public void Write_NonNullDateTime_WritesExpectedString()
    {
        var dateTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var json = JsonSerializer.Serialize<DateTime?>(dateTime, _options);
        Assert.Equal("\"2023-01-01T00:00:00.000+00:00\"", json);
    }

    [Fact]
    public void Write_NullDateTime_WritesNullValue()
    {
        var json = JsonSerializer.Serialize<DateTime?>(null, _options);
        Assert.Equal("null", json);
    }

    [Fact]
    public void Write_NullDateTimeInObject_WritesNullValue()
    {
        var json = JsonSerializer.Serialize(new NullableDateTimeObject(), _options);
        Assert.Equal("{\"x\":null}", json);
    }

    [Fact]
    public void Write_WhenValueIsNull_WritesNullValue()
    {
        // Arrange
        var converter = new NullableDateTimeConverter();
        DateTime? nullDateTime = null;

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Act
        converter.Write(writer, nullDateTime, _options);
        writer.Flush();

        // Assert
        var json = Encoding.UTF8.GetString(stream.ToArray());
        Assert.Equal("null", json);
    }

    [Fact]
    public void Read_DirectNullToken_ReturnsNull()
    {
        // Arrange
        var converter = new NullableDateTimeConverter();
        var json = "null";
        var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
        reader.Read(); // Advance to first token

        // Act
        var result = converter.Read(ref reader, typeof(DateTime?), _options);

        // Assert
        Assert.Null(result);
    }
}
