using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class AttributeJsonConverterTests
{
    private readonly JsonSerializerOptions _options;

    public AttributeJsonConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Converters = { new AttributeJsonConverter() }
        };
    }

    [Fact]
    public void Read_ShouldDeserializeBooleanAttribute()
    {
        var json = "{\"type\":\"boolean\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeBoolean>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeIntegerAttribute()
    {
        var json = "{\"type\":\"integer\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeInteger>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeDoubleAttribute()
    {
        var json = "{\"type\":\"double\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeFloat>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeDatetimeAttribute()
    {
        var json = "{\"type\":\"datetime\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeDatetime>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeStringAttribute()
    {
        var json = "{\"type\":\"string\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeString>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeEmailAttribute()
    {
        var json = "{\"type\":\"string\", \"format\":\"email\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeEmail>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeUrlAttribute()
    {
        var json = "{\"type\":\"string\", \"format\":\"url\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeUrl>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeIpAttribute()
    {
        var json = "{\"type\":\"string\", \"format\":\"ip\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeIp>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeEnumAttribute()
    {
        var json = "{\"type\":\"string\", \"format\":\"enum\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeEnum>(attribute);
    }

    [Fact]
    public void Read_ShouldDeserializeRelationshipAttribute()
    {
        var json = "{\"type\":\"string\", \"relatedCollection\":\"someCollection\"}";
        var attribute = JsonSerializer.Deserialize<Attribute>(json, _options);
        Assert.IsType<AttributeRelationship>(attribute);
    }

    [Fact]
    public void Read_ShouldThrowJsonExceptionForUnknownType()
    {
        var json = "{\"type\":\"unknown\"}";
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Attribute>(json, _options));
    }

    [Fact]
    public void Read_ShouldThrowJsonExceptionForUnknownFormat()
    {
        var json = "{\"type\":\"string\", \"format\":\"unknown\"}";
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Attribute>(json, _options));
    }

    [Fact]
    public void Read_ShouldThrowJsonExceptionForMissingType()
    {
        var json = "{}";
        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Attribute>(json, _options));
    }

    [Fact]
    public void Write_ShouldSerializeAttribute()
    {
        var attribute = new AttributeBoolean("a", "boolean", AttributeStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, null);
        var converter = new AttributeJsonConverter();

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        converter.Write(writer, attribute, _options);
        writer.Flush();

        var json = System.Text.Encoding.UTF8.GetString(stream.ToArray());
        Assert.Contains("\"type\":\"boolean\"", json);
        Assert.Contains("\"key\":\"a\"", json);
        Assert.Contains("\"status\":\"available\"", json);
        Assert.Contains("\"required\":false", json);
        Assert.Contains("\"array\":false", json);
        Assert.Contains($"\"$createdAt\":\"{attribute.CreatedAt:O}\"", json);
        Assert.Contains($"\"$updatedAt\":\"{attribute.UpdatedAt:O}\"", json);
    }
}
