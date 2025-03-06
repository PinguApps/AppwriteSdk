using System.Collections.Generic;
using System.Threading;

namespace PinguApps.Appwrite.Shared;

public static class AppwriteRequestContext
{
    private static readonly AsyncLocal<Dictionary<string, string>> _headers = new();

    /// <summary>
    /// Gets the current request headers dictionary.
    /// </summary>
    public static Dictionary<string, string> CurrentHeaders
    {
        get => _headers.Value ??= [];
    }

    /// <summary>
    /// Adds or updates a single header in the current context.
    /// </summary>
    public static void AddHeader(string key, string value)
    {
        CurrentHeaders[key] = value;
    }

    /// <summary>
    /// Adds or updates multiple headers in the current context.
    /// </summary>
    public static void AddHeaders(IDictionary<string, string> headers)
    {
        foreach (var header in headers)
        {
            CurrentHeaders[header.Key] = header.Value;
        }
    }

    /// <summary>
    /// Clears all headers from the current context.
    /// </summary>
    public static void ClearHeaders()
    {
        _headers.Value = [];
    }
}
