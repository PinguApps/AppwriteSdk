using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class UpperCaseEnumConverterTests
{
    public enum TestEnum
    {
        FirstValue,
        SecondValue,
        UPPERCASE_VALUE
    }

    private readonly UpperCaseEnumConverter _converter;
    private readonly JsonSerializerOptions _options;

    public UpperCaseEnumConverterTests()
    {
        _converter = new UpperCaseEnumConverter();
        _options = new JsonSerializerOptions();
    }

    [Fact]
    public void CanConvert_WhenTypeIsEnum_ReturnsTrue()
    {
        // Arrange
        var enumType = typeof(TestEnum);

        // Act
        var result = _converter.CanConvert(enumType);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanConvert_WhenTypeIsNotEnum_ReturnsFalse()
    {
        // Arrange
        var nonEnumType = typeof(string);

        // Act
        var result = _converter.CanConvert(nonEnumType);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("FirstValue", TestEnum.FirstValue)]
    [InlineData("FIRSTVALUE", TestEnum.FirstValue)]
    [InlineData("secondValue", TestEnum.SecondValue)]
    [InlineData("UPPERCASE_VALUE", TestEnum.UPPERCASE_VALUE)]
    public void Read_ValidEnumString_ReturnsEnumValue(string input, TestEnum expected)
    {
        // Arrange
        var json = $"\"{input}\"";
        var reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
        reader.Read(); // Move to first token

        // Act
        var result = _converter.Read(ref reader, typeof(TestEnum), _options);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Read_InvalidEnumString_ThrowsArgumentException()
    {
        // Arrange
        var json = "\"InvalidValue\"";
        var jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);

        // Act & Assert
        void TestCode()
        {
            var reader = new Utf8JsonReader(jsonBytes);
            reader.Read(); // Move to first token
            _converter.Read(ref reader, typeof(TestEnum), _options);
        }

        Assert.Throws<ArgumentException>(TestCode);
    }

    [Theory]
    [InlineData(TestEnum.FirstValue, "FIRSTVALUE")]
    [InlineData(TestEnum.SecondValue, "SECONDVALUE")]
    [InlineData(TestEnum.UPPERCASE_VALUE, "UPPERCASE_VALUE")]
    public void Write_EnumValue_WritesUpperCaseString(TestEnum input, string expected)
    {
        // Arrange
        using var stream = new System.IO.MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Act
        _converter.Write(writer, input, _options);
        writer.Flush();

        // Assert
        var json = System.Text.Encoding.UTF8.GetString(stream.ToArray());
        Assert.Equal($"\"{expected}\"", json);
    }
}
