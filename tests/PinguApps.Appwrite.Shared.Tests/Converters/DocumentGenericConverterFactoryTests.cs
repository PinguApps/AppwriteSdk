using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class DocumentGenericConverterFactoryTests
{
    private readonly DocumentGenericConverterFactory _factory;

    public DocumentGenericConverterFactoryTests()
    {
        _factory = new DocumentGenericConverterFactory();
    }

    public class TestData
    {
        public string? Field1 { get; set; }
    }

    [Fact]
    public void CanConvert_DocumentGenericType_ReturnsTrue()
    {
        // Arrange
        var typeToConvert = typeof(Document<TestData>);

        // Act
        var result = _factory.CanConvert(typeToConvert);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanConvert_NonGenericType_ReturnsFalse()
    {
        // Arrange
        var typeToConvert = typeof(TestData);

        // Act
        var result = _factory.CanConvert(typeToConvert);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanConvert_DifferentGenericType_ReturnsFalse()
    {
        // Arrange
        var typeToConvert = typeof(List<TestData>);

        // Act
        var result = _factory.CanConvert(typeToConvert);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CreateConverter_DocumentGenericType_ReturnsConverter()
    {
        // Arrange
        var typeToConvert = typeof(Document<TestData>);
        var options = new JsonSerializerOptions();

        // Act
        var converter = _factory.CreateConverter(typeToConvert, options);

        // Assert
        Assert.NotNull(converter);
        Assert.IsType<DocumentGenericConverter<TestData>>(converter);
    }

    [Fact]
    public void CreateConverter_NonGenericType_ThrowsException()
    {
        // Arrange
        var typeToConvert = typeof(TestData);
        var options = new JsonSerializerOptions();

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => _factory.CreateConverter(typeToConvert, options));
    }

    [Fact]
    public void CreateConverter_DifferentGenericType_ReturnsConverterWithFirstGenericArgument()
    {
        // Arrange
        var typeToConvert = typeof(List<TestData>);
        var options = new JsonSerializerOptions();

        // Act
        var converter = _factory.CreateConverter(typeToConvert, options);

        // Assert
        Assert.NotNull(converter);
        Assert.IsType<DocumentGenericConverter<TestData>>(converter);
    }
}
