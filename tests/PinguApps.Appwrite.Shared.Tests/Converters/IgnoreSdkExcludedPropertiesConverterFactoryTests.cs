using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Tests.Converters;
public class IgnoreSdkExcludedPropertiesConverterFactoryTests
{
    private readonly JsonSerializerOptions _options;

    public IgnoreSdkExcludedPropertiesConverterFactoryTests()
    {
        _options = new JsonSerializerOptions
        {
            Converters = { new IgnoreSdkExcludedPropertiesConverterFactory() }
        };
    }

    [Fact]
    public void CanConvert_PrimitiveTypes_ReturnsFalse()
    {
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();

        Assert.False(factory.CanConvert(typeof(int)));
        Assert.False(factory.CanConvert(typeof(string)));
        Assert.False(factory.CanConvert(typeof(decimal)));
        Assert.False(factory.CanConvert(typeof(DateTime)));
        Assert.False(factory.CanConvert(typeof(DateTimeOffset)));
        Assert.False(factory.CanConvert(typeof(TimeSpan)));
        Assert.False(factory.CanConvert(typeof(Guid)));
        Assert.False(factory.CanConvert(typeof(object)));
    }

    [Fact]
    public void CanConvert_EnumerableTypes_ReturnsFalse()
    {
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();

        Assert.False(factory.CanConvert(typeof(List<int>)));
        Assert.False(factory.CanConvert(typeof(string[])));
    }

    [Fact]
    public void CanConvert_ClassTypes_ReturnsTrue()
    {
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();

        Assert.True(factory.CanConvert(typeof(TestClass)));
    }

    [Fact]
    public void CanConvert_AbstractClassTypes_ReturnsFalse()
    {
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();

        Assert.False(factory.CanConvert(typeof(AbstractTestClass)));
    }

    [Fact]
    public void CanConvert_NonClassNonAbstractTypes_ReturnsFalse()
    {
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();

        // Create a type that is not a class and not abstract but bypasses all previous checks
        var type = typeof(NonClassNonAbstractType);

        Assert.False(factory.CanConvert(type));
    }

    [Fact]
    public void CreateConverter_ReturnsCorrectConverter()
    {
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();
        var converter = factory.CreateConverter(typeof(TestClass), _options);

        Assert.NotNull(converter);
    }

    [Fact]
    public void Read_DeserializesCorrectly()
    {
        var json = "{\"Name\":\"Test\",\"Age\":30}";
        var result = JsonSerializer.Deserialize<TestClass>(json, _options);

        Assert.NotNull(result);
        Assert.Equal("Test", result.Name);
        Assert.Equal(30, result.Age);
    }

    [Fact]
    public void Write_SerializesCorrectly()
    {
        var testClass = new TestClass { Name = "Test", Age = 30 };
        var json = JsonSerializer.Serialize(testClass, _options);

        Assert.Contains("\"Name\":\"Test\"", json);
        Assert.Contains("\"Age\":30", json);
    }

    [Fact]
    public void Write_ExcludesSdkExcludedProperties()
    {
        var testClass = new TestClassWithExcludedProperty { Name = "Test", Age = 30, Secret = "Secret" };
        var json = JsonSerializer.Serialize(testClass, _options);

        Assert.Contains("\"Name\":\"Test\"", json);
        Assert.Contains("\"Age\":30", json);
        Assert.DoesNotContain("\"Secret\"", json);
    }

    [Fact]
    public void Write_UsesCustomConverter()
    {
        var testClass = new TestClassWithCustomConverter { Name = "Test", Age = 30, CustomDate = new DateTime(2023, 1, 1) };
        var json = JsonSerializer.Serialize(testClass, _options);

        Assert.Contains("\"Name\":\"Test\"", json);
        Assert.Contains("\"Age\":30", json);
        Assert.Contains("\"CustomDate\":\"2023-01-01\"", json);
    }

    [Fact]
    public void Write_ValueIsNull_WritesNullValue()
    {
        // Arrange
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();
        var converter = factory.CreateConverter(typeof(TestClass), _options) as JsonConverter<TestClass>;

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Act
        converter?.Write(writer, null!, _options);
        writer.Flush();

        // Assert
        var json = Encoding.UTF8.GetString(stream.ToArray());
        Assert.Equal("null", json);
    }

    [Fact]
    public void Write_PropertyWithoutGetMethod_IsIgnored()
    {
        // Arrange
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();
        var converter = factory.CreateConverter(typeof(TestClassWithSetOnlyProperty), _options) as JsonConverter<TestClassWithSetOnlyProperty>;

        var testClass = new TestClassWithSetOnlyProperty { Name = "Test" };

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Act
        converter?.Write(writer, testClass, _options);
        writer.Flush();

        // Assert
        var json = Encoding.UTF8.GetString(stream.ToArray());
        Assert.Contains("\"Name\":\"Test\"", json);
        Assert.DoesNotContain("\"SetOnlyProperty\"", json);
    }

    [Fact]
    public void Write_PropertyWithJsonPropertyNameAttribute_UsesCustomName()
    {
        // Arrange
        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();
        var converter = factory.CreateConverter(typeof(TestClassWithJsonPropertyName), _options) as JsonConverter<TestClassWithJsonPropertyName>;

        var testClass = new TestClassWithJsonPropertyName { CustomName = "Test" };

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Act
        converter?.Write(writer, testClass, _options);
        writer.Flush();

        // Assert
        var json = Encoding.UTF8.GetString(stream.ToArray());
        Assert.Contains("\"custom_name\":\"Test\"", json);
    }

    [Fact]
    public void Write_PropertyWithNamingPolicy_UsesConvertedName()
    {
        // Arrange
        var optionsWithNamingPolicy = new JsonSerializerOptions(_options)
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();
        var converter = factory.CreateConverter(typeof(TestClassWithNamingPolicy), optionsWithNamingPolicy) as JsonConverter<TestClassWithNamingPolicy>;

        var testClass = new TestClassWithNamingPolicy { CustomName = "Test" };

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Act
        converter?.Write(writer, testClass, optionsWithNamingPolicy);
        writer.Flush();

        // Assert
        var json = Encoding.UTF8.GetString(stream.ToArray());
        Assert.Contains("\"customName\":\"Test\"", json);
    }

    [Fact]
    public void Write_PropertyValueIsNullAndDefaultIgnoreConditionIsWhenWritingNull_PropertyIsIgnored()
    {
        // Arrange
        var optionsWithIgnoreCondition = new JsonSerializerOptions(_options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        var factory = new IgnoreSdkExcludedPropertiesConverterFactory();
        var converter = factory.CreateConverter(typeof(TestClassWithNullProperty), optionsWithIgnoreCondition) as JsonConverter<TestClassWithNullProperty>;

        var testClass = new TestClassWithNullProperty { Name = null };

        using var stream = new MemoryStream();
        using var writer = new Utf8JsonWriter(stream);

        // Act
        converter?.Write(writer, testClass, optionsWithIgnoreCondition);
        writer.Flush();

        // Assert
        var json = Encoding.UTF8.GetString(stream.ToArray());
        Assert.DoesNotContain("\"Name\"", json);
    }

    private class TestClass
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    private abstract class AbstractTestClass
    {
        public string Name { get; set; } = string.Empty;
    }

    private class TestClassWithExcludedProperty
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        [SdkExclude]
        public string Secret { get; set; } = string.Empty;
    }

    private class TestClassWithCustomConverter
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CustomDate { get; set; }
    }

    private class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }

    private struct NonClassNonAbstractType
    {
        public int Value { get; set; }
    }

    private class TestClassWithSetOnlyProperty
    {
        public string Name { get; set; } = string.Empty;

        // Property with only a set method
        public int SetOnlyProperty
        {
            set { /* Do nothing */ }
        }
    }

    private class TestClassWithJsonPropertyName
    {
        [JsonPropertyName("custom_name")]
        public string CustomName { get; set; } = string.Empty;
    }

    private class TestClassWithNamingPolicy
    {
        public string CustomName { get; set; } = string.Empty;
    }

    private class TestClassWithNullProperty
    {
        public string? Name { get; set; }
    }
}
