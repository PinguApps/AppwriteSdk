using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Utils;
public class Query
{
    [JsonPropertyName("method")]
    public string Method { get; private set; }

    [JsonPropertyName("attribute")]
    public string? Attribute { get; private set; }

    [JsonPropertyName("values")]
    public List<object>? Values { get; private set; }

    private Query(string method, string? attribute, object? values)
    {
        Method = method;
        Attribute = attribute;

        if (values is IEnumerable valuesList)
        {
            Values = [valuesList];
        }
        else if (values is not null)
        {
            Values = [values];
        }
    }

    public string GetQueryString() => Uri.EscapeUriString(JsonSerializer.Serialize(this));

    public static Query Limit(int limit) => new("limit", null, limit);

    public static Query Offset(int offset) => new("offset", null, offset);
}
