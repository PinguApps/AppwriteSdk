using System;

namespace PinguApps.Appwrite.Shared.Attributes;

internal class UrlReplacementAttribute : Attribute
{
    public UrlReplacementAttribute(string pattern)
    {
        Pattern = pattern;
    }

    public string Pattern { get; }
}
