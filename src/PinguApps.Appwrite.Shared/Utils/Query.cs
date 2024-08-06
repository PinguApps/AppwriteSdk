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

    public static Query Equal(string attribute, object value) => new("equal", attribute, value);

    public static Query NotEqual(string attribute, object value) => new("notEqual", attribute, value);

    public static Query LessThan(string attribute, object value) => new("lessThan", attribute, value);

    public static Query LessThanEqual(string attribute, object value) => new("lessThanEqual", attribute, value);

    public static Query GreaterThan(string attribute, object value) => new("greaterThan", attribute, value);

    public static Query GreaterThanEqual(string attribute, object value) => new("greaterThanEqual", attribute, value);

    public static Query Search(string attribute, object value) => new("search", attribute, value);

    public static Query IsNull(string attribute) => new("isNull", attribute, null);

    public static Query IsNotNull(string attribute) => new("isNotNull", attribute, null);

    public static Query StartsWith(string attribute, object value) => new("startsWith", attribute, value);

    public static Query EndsWith(string attribute, object value) => new("endsWith", attribute, value);

    public static Query Between(string attribute, string start, string end) => new("between", attribute, new List<string> { start, end });

    public static Query Between(string attribute, int start, int end) => new("between", attribute, new List<int> { start, end });

    public static Query Between(string attribute, double start, double end) => new("between", attribute, new List<double> { start, end });

    public static Query Select(List<string> attributes) => new("select", null, attributes);

    public static Query CursorAfter(string documentId) => new("cursorAfter", null, documentId);

    public static Query CursorBefore(string documentId) => new("cursorBefore", null, documentId);

    public static Query OrderAsc(string attribute) => new("orderAsc", attribute, null);

    public static Query OrderDesc(string attribute) => new("orderDesc", attribute, null);

    public static Query Limit(int limit) => new("limit", null, limit);

    public static Query Offset(int offset) => new("offset", null, offset);

    public static Query Contains(string attribute, object value) => new("contains", attribute, value);

    public static Query Or(List<Query> queries) => new("or", null, queries);

    public static Query And(List<Query> queries) => new("and", null, queries);
}
