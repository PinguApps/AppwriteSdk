using System;

namespace PinguApps.Appwrite.Shared.Attributes;
internal class QueryParameterAttribute : Attribute
{
    public QueryParameterAttribute(string key)
    {
        Key = key;
    }

    public string Key { get; }
}
