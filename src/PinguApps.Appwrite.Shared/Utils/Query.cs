using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Utils;

/// <summary>
/// Many list endpoints in Appwrite allow you to filter, sort, and paginate results using queries. Appwrite provides a common set of syntax to build queries.
/// </summary>
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

        if (values is IEnumerable<object> objects)
        {
            Values = objects.ToList();
        }
        else if (values is ICollection valuesList)
        {
            Values = [.. valuesList];
        }
        else if (values is not null)
        {
            Values = [values];
        }
    }

    /// <summary>
    /// Provides the query string for the given query
    /// </summary>
    /// <returns></returns>
    public string GetQueryString() => Uri.EscapeUriString(JsonSerializer.Serialize(this));

    /// <summary>
    /// Returns document if attribute is equal to any value in the provided array.
    /// </summary>
    public static Query Equal(string attribute, object value) => new("equal", attribute, value);

    /// <summary>
    /// Returns document if attribute is not equal to any value in the provided array.
    /// </summary>
    public static Query NotEqual(string attribute, object value) => new("notEqual", attribute, value);

    /// <summary>
    /// Returns document if attribute is less than the provided value.
    /// </summary>
    public static Query LessThan(string attribute, object value) => new("lessThan", attribute, value);

    /// <summary>
    /// Returns document if attribute is less than or equal to the provided value.
    /// </summary>
    public static Query LessThanEqual(string attribute, object value) => new("lessThanEqual", attribute, value);

    /// <summary>
    /// Returns document if attribute is greater than the provided value.
    /// </summary>
    public static Query GreaterThan(string attribute, object value) => new("greaterThan", attribute, value);

    /// <summary>
    /// Returns document if attribute is greater than or equal to the provided value.
    /// </summary>
    public static Query GreaterThanEqual(string attribute, object value) => new("greaterThanEqual", attribute, value);

    /// <summary>
    /// Searches string attributes for provided keywords. Requires a <see href="https://appwrite.io/docs/products/databases/collections#indexes">full-text index</see> on queried attributes.
    /// </summary>
    public static Query Search(string attribute, object value) => new("search", attribute, value);

    /// <summary>
    /// Returns documents where attribute value is null.
    /// </summary>
    public static Query IsNull(string attribute) => new("isNull", attribute, null);

    /// <summary>
    /// Returns documents where attribute value is not null.
    /// </summary>
    public static Query IsNotNull(string attribute) => new("isNotNull", attribute, null);

    /// <summary>
    /// Returns documents if a string attributes starts with a substring.
    /// </summary>
    public static Query StartsWith(string attribute, object value) => new("startsWith", attribute, value);

    /// <summary>
    /// Returns documents if a string attributes ends with a substring.
    /// </summary>
    public static Query EndsWith(string attribute, object value) => new("endsWith", attribute, value);

    /// <summary>
    /// Returns document if attribute value falls between the two values. The boundary values are inclusive.
    /// </summary>
    public static Query Between(string attribute, string start, string end) => new("between", attribute, new List<string> { start, end });

    /// <summary>
    /// Returns document if attribute value falls between the two values. The boundary values are inclusive.
    /// </summary>
    public static Query Between(string attribute, int start, int end) => new("between", attribute, new List<int> { start, end });

    /// <summary>
    /// Returns document if attribute value falls between the two values. The boundary values are inclusive.
    /// </summary>
    public static Query Between(string attribute, double start, double end) => new("between", attribute, new List<double> { start, end });

    /// <summary>
    /// Select which attributes should be returned from a document
    /// </summary>
    public static Query Select(List<string> attributes) => new("select", null, attributes);

    /// <summary>
    /// Places the cursor after the specified resource ID. Used for <see href="https://appwrite.io/docs/products/databases/pagination">pagination</see>.
    /// </summary>
    public static Query CursorAfter(string documentId) => new("cursorAfter", null, documentId);

    /// <summary>
    /// Places the cursor before the specified resource ID. Used for <see href="https://appwrite.io/docs/products/databases/pagination">pagination</see>.
    /// </summary>
    public static Query CursorBefore(string documentId) => new("cursorBefore", null, documentId);

    /// <summary>
    /// Orders results in ascending order by attribute. Attribute must be indexed. Pass in an empty string to return in natural order.
    /// </summary>
    public static Query OrderAsc(string attribute) => new("orderAsc", attribute, null);

    /// <summary>
    /// Orders results in descending order by attribute. Attribute must be indexed. Pass in an empty string to return in natural order.
    /// </summary>
    public static Query OrderDesc(string attribute) => new("orderDesc", attribute, null);

    /// <summary>
    /// Limits the number of results returned by the query. Used for <see href="https://appwrite.io/docs/products/databases/pagination">pagination</see>. If the limit query is not used, the limit defaults to 25 results.
    /// </summary>
    public static Query Limit(int limit) => new("limit", null, limit);

    /// <summary>
    /// Offset the results returned by skipping some of the results. Used for <see href="https://appwrite.io/docs/products/databases/pagination">pagination</see>.
    /// </summary>
    public static Query Offset(int offset) => new("offset", null, offset);

    /// <summary>
    /// Returns documents if a the array attribute contains the specified elements.
    /// </summary>
    public static Query Contains(string attribute, object value) => new("contains", attribute, value);

    /// <summary>
    /// Returns document if it matches any of the nested sub-queries in the array passed in.
    /// </summary>
    public static Query Or(List<Query> queries) => new("or", null, queries);

    /// <summary>
    /// Returns document if it matches all of the nested sub-queries in the array passed in.
    /// </summary>
    public static Query And(List<Query> queries) => new("and", null, queries);
}
