using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class AttributeListJsonConverterTests
{
    private readonly JsonSerializerOptions _options;

    public AttributeListJsonConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Converters = { new AttributeListJsonConverter() }
        };
    }

    [Fact]
    public void Read_ShouldDeserializeAttributeList()
    {
        var json = "[{\"type\":\"boolean\"}, {\"type\":\"integer\"}]";
        var attributes = JsonSerializer.Deserialize<IReadOnlyList<Attribute>>(json, _options);

        Assert.NotNull(attributes);
        Assert.Equal(2, attributes.Count);
        Assert.IsType<AttributeBoolean>(attributes[0]);
        Assert.IsType<AttributeInteger>(attributes[1]);
    }

    [Fact]
    public void Read_ShouldThrowJsonExceptionForInvalidStartToken()
    {
        var json = "{\"type\":\"boolean\"}";
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<IReadOnlyList<Attribute>>(json, _options));
        Assert.Equal("Expected start of array", exception.Message);
    }

    [Fact]
    public void Write_ShouldSerializeAttributeList()
    {
        var attributes = new List<Attribute>
            {
                new AttributeBoolean("a", "boolean", AttributeStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, null),
                new AttributeInteger("b", "integer", AttributeStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, null, null, null)
            };

        var json = JsonSerializer.Serialize((IReadOnlyList<Attribute>)attributes, _options);

        Assert.Contains("\"type\":\"boolean\"", json);
        Assert.Contains("\"type\":\"integer\"", json);
    }

    [Fact]
    public void Write_ShouldHandleEmptyList()
    {
        var attributes = new List<Attribute>();

        var json = JsonSerializer.Serialize((IReadOnlyList<Attribute>)attributes, _options);

        Assert.Equal("[]", json);
    }
}
