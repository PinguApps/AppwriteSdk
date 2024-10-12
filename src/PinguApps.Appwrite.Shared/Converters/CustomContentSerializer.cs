using System;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace PinguApps.Appwrite.Shared.Converters;
public class CustomContentSerializer : IHttpContentSerializer
{
    private readonly JsonSerializerOptions _serializerOptions;

    public CustomContentSerializer()
    {
        _serializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        _serializerOptions.Converters.Add(new IgnoreUnderscorePropertiesConverterFactory());
    }

    public async Task<T?> FromHttpContentAsync<T>(HttpContent content, CancellationToken cancellationToken = default)
    {
        if (content is null)
            throw new ArgumentNullException(nameof(content));

        var json = await content.ReadAsStringAsync().ConfigureAwait(false);

        return JsonSerializer.Deserialize<T>(json, _serializerOptions);
    }

    public HttpContent ToHttpContent<T>(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        // Serialize the object using the configured JsonSerializerOptions
        var json = JsonSerializer.Serialize(item, _serializerOptions);

        return new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    }

    public string? GetFieldNameForProperty(PropertyInfo propertyInfo)
    {
        if (propertyInfo is null)
            throw new ArgumentNullException(nameof(propertyInfo));

        var jsonPropertyNameAttr = propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>();

        if (jsonPropertyNameAttr is not null)
            return jsonPropertyNameAttr.Name;

        // Apply naming policy if set
        return _serializerOptions.PropertyNamingPolicy?.ConvertName(propertyInfo.Name) ?? propertyInfo.Name;
    }
}
