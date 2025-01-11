using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class SdkMarkerConverterTests
{
    private readonly SdkMarkerConverter _converter;

    public SdkMarkerConverterTests()
    {
        _converter = new SdkMarkerConverter();
    }

    [Fact]
    public void CanConvert_AlwaysReturnsFalse()
    {
        // Arrange
        var types = new[]
        {
            typeof(string),
            typeof(int),
            typeof(object),
            typeof(SdkMarkerConverter)
        };

        // Act & Assert
        foreach (var type in types)
        {
            Assert.False(_converter.CanConvert(type));
        }
    }

    [Fact]
    public void Read_ThrowsNotImplementedException()
    {
        // Arrange
        var json = "{}";
        var reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(json));
        var options = new JsonSerializerOptions();
        var exceptionThrown = false;

        // Act
        try
        {
            _converter.Read(ref reader, typeof(object), options);
        }
        catch (NotImplementedException)
        {
            exceptionThrown = true;
        }

        // Assert
        Assert.True(exceptionThrown);
    }

    [Fact]
    public void Write_ThrowsNotImplementedException()
    {
        // Arrange
        using var stream = new System.IO.MemoryStream();
        using var writer = new Utf8JsonWriter(stream);
        var options = new JsonSerializerOptions();

        // Act & Assert
        Assert.Throws<NotImplementedException>(() =>
            _converter.Write(writer, new object(), options));
    }
}
