using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class MultiFormatDateTimeConverterTests
{
    private readonly JsonSerializerOptions _options;

    public MultiFormatDateTimeConverterTests()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new MultiFormatDateTimeConverter());
    }

    [Fact]
    public void Read_ValidDateStringWithTimeZone_ReturnsDateTime()
    {
        var json = "\"2023-01-01T00:00:00.000Z\"";
        var result = JsonSerializer.Deserialize<DateTime>(json, _options);

        // Convert both to UTC to compare
        var expectedDateTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var actualDateTime = result.ToUniversalTime();

        Assert.Equal(expectedDateTime, actualDateTime);
    }

    [Fact]
    public void Read_ValidDateStringWithoutTimeZone_ReturnsDateTime()
    {
        var json = "\"2023-01-01 00:00:00.000\"";
        var result = JsonSerializer.Deserialize<DateTime>(json, _options);
        Assert.Equal(new DateTime(2023, 1, 1, 0, 0, 0), result);
    }

    [Fact]
    public void Read_InvalidDateString_ThrowsJsonException()
    {
        var json = "\"invalid-date\"";
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DateTime>(json, _options));
    }

    [Fact]
    public void Read_UnexpectedTokenType_ThrowsJsonException()
    {
        var json = "123";
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<DateTime>(json, _options));
    }

    [Fact]
    public void Write_ValidDateTime_WritesExpectedString()
    {
        var dateTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var json = JsonSerializer.Serialize(dateTime, _options);
        Assert.Equal("\"2023-01-01T00:00:00.000Z\"", json);
    }

    public class MultiFormatDateTimeObject
    {
        [JsonPropertyName("x")]
        [JsonConverter(typeof(MultiFormatDateTimeConverter))]
        public DateTime X { get; set; }
    }

    [Fact]
    public void Read_ValidDateStringInObject_ReturnsDateTime()
    {
        var json = "{\"x\": \"2023-01-01T00:00:00.000Z\"}";
        var result = JsonSerializer.Deserialize<MultiFormatDateTimeObject>(json, _options);
        Assert.NotNull(result);


        // Convert both to UTC to compare
        var expectedDateTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var actualDateTime = result.X.ToUniversalTime();

        Assert.Equal(expectedDateTime, actualDateTime);
    }

    [Fact]
    public void Write_ValidDateTimeInObject_WritesExpectedString()
    {
        var obj = new MultiFormatDateTimeObject { X = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc) };
        var json = JsonSerializer.Serialize(obj, _options);
        Assert.Equal("{\"x\":\"2023-01-01T00:00:00.000Z\"}", json);
    }
}
