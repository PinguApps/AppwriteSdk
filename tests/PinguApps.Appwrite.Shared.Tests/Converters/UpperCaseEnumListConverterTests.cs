using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class UpperCaseEnumListConverterTests
{
    private enum TestEnum
    {
        FirstValue,
        SecondValue,
        UPPERCASE_VALUE
    }

    private readonly JsonSerializerOptions _options;

    public UpperCaseEnumListConverterTests()
    {
        _options = new JsonSerializerOptions
        {
            Converters = { new UpperCaseEnumListConverter<TestEnum>() }
        };
    }

    [Fact]
    public void Read_NotArray_ThrowsJsonException()
    {
        var json = "\"NotAnArray\"";
        Assert.ThrowsAny<JsonException>(() =>
            JsonSerializer.Deserialize<List<TestEnum>>(json, _options));
    }

    [Fact]
    public void Read_ValidArray_ReturnsEnumList()
    {
        var json = "[\"FirstValue\", \"SECONDVALUE\", \"uppercase_value\"]";
        var result = JsonSerializer.Deserialize<List<TestEnum>>(json, _options);

        Assert.NotNull(result);
        Assert.Collection(result,
            item => Assert.Equal(TestEnum.FirstValue, item),
            item => Assert.Equal(TestEnum.SecondValue, item),
            item => Assert.Equal(TestEnum.UPPERCASE_VALUE, item));
    }

    [Fact]
    public void Read_EmptyArray_ReturnsEmptyList()
    {
        var json = "[]";
        var result = JsonSerializer.Deserialize<List<TestEnum>>(json, _options);
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Read_InvalidEnumValue_ThrowsArgumentException()
    {
        var json = "[\"InvalidValue\"]";
        Assert.Throws<ArgumentException>(() =>
            JsonSerializer.Deserialize<List<TestEnum>>(json, _options));
    }

    [Fact]
    public void Write_ValidList_WritesUpperCaseArray()
    {
        var list = new List<TestEnum>
        {
            TestEnum.FirstValue,
            TestEnum.SecondValue,
            TestEnum.UPPERCASE_VALUE
        };

        var json = JsonSerializer.Serialize(list, _options);
        Assert.Equal("[\"FIRSTVALUE\",\"SECONDVALUE\",\"UPPERCASE_VALUE\"]", json);
    }

    [Fact]
    public void Write_EmptyList_WritesEmptyArray()
    {
        var list = new List<TestEnum>();
        var json = JsonSerializer.Serialize(list, _options);
        Assert.Equal("[]", json);
    }
}
