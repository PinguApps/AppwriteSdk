using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

internal class UpdateDocumentRequestBuilder : IUpdateDocumentRequestBuilder
{
    private readonly UpdateDocumentRequest _request = new();
    private readonly Dictionary<string, object?> _data = [];

    public IUpdateDocumentRequestBuilder WithDatabaseId(string databaseId)
    {
        _request.DatabaseId = databaseId;
        return this;
    }

    public IUpdateDocumentRequestBuilder WithCollectionId(string collectionId)
    {
        _request.CollectionId = collectionId;
        return this;
    }

    public IUpdateDocumentRequestBuilder WithDocumentId(string documentId)
    {
        _request.DocumentId = documentId;
        return this;
    }

    public IUpdateDocumentRequestBuilder WithPermissions(List<Permission> permissions)
    {
        _request.Permissions = permissions;
        return this;
    }

    public IUpdateDocumentRequestBuilder AddPermission(Permission permission)
    {
        _request.Permissions.Add(permission);
        return this;
    }

    public IUpdateDocumentRequestBuilder AddField(string name, object? value)
    {
        _data[name] = value;
        return this;
    }

    public IUpdateDocumentRequestBuilder WithChanges<T>(T before, T after) where T : class
    {
        if (before is null)
        {
            throw new ArgumentNullException(nameof(before));
        }
        if (after is null)
        {
            throw new ArgumentNullException(nameof(after));
        }

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            if (!property.CanRead) continue;

            var beforeValue = property.GetValue(before);
            var afterValue = property.GetValue(after);

            if (!AreValuesEqual(beforeValue, afterValue))
            {
                var jsonPropertyName = GetJsonPropertyName(property);
                AddField(jsonPropertyName, afterValue);
            }
        }

        return this;
    }

    public UpdateDocumentRequest Build()
    {
        _request.Data = _data;
        return _request;
    }

    private static string GetJsonPropertyName(PropertyInfo property)
    {
        var jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();

        return jsonPropertyAttribute?.Name ?? property.Name;
    }

    private static bool AreValuesEqual(object? value1, object? value2)
    {
        if (ReferenceEquals(value1, value2))
        {
            return true;
        }

        if (value1 is null || value2 is null)
        {
            return false;
        }

        if (value1 is IEnumerable<object> enumerable1 && value2 is IEnumerable<object> enumerable2)
        {
            return enumerable1.SequenceEqual(enumerable2);
        }

        return value1.Equals(value2);
    }
}
