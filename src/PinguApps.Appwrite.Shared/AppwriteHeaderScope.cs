using System;
using System.Collections.Generic;

namespace PinguApps.Appwrite.Shared;

public class AppwriteHeaderScope : IDisposable
{
    private readonly Dictionary<string, (bool hadValue, string oldValue)> _originalState = [];

    /// <summary>
    /// Creates a new scope with a single header.
    /// </summary>
    /// <param name="key">The header name</param>
    /// <param name="value">The header value</param>
    public AppwriteHeaderScope(string key, string value)
    {
        StoreOriginalValue(key);
        AppwriteRequestContext.AddHeader(key, value);
    }

    /// <summary>
    /// Creates a new scope with multiple headers.
    /// </summary>
    /// <param name="headers">Dictionary of headers to add</param>
    public AppwriteHeaderScope(IDictionary<string, string> headers)
    {
        foreach (var header in headers)
        {
            StoreOriginalValue(header.Key);
        }

        AppwriteRequestContext.AddHeaders(headers);
    }

    private void StoreOriginalValue(string key)
    {
        var hadValue = AppwriteRequestContext.CurrentHeaders.TryGetValue(key, out var oldValue);
        _originalState[key] = (hadValue, oldValue);
    }

    /// <summary>
    /// Restores the original header values from before this scope was created.
    /// </summary>
    public void Dispose()
    {
        foreach (var entry in _originalState)
        {
            var key = entry.Key;
            var (hadValue, oldValue) = entry.Value;

            if (hadValue)
                AppwriteRequestContext.AddHeader(key, oldValue);
            else
                AppwriteRequestContext.CurrentHeaders.Remove(key);
        }
    }
}
