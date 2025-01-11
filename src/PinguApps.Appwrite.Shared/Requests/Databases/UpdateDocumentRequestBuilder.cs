using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;
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
        _request.Permissions ??= [];
        _request.Permissions.Add(permission);
        return this;
    }

    public IUpdateDocumentRequestBuilder AddField(string name, object? value)
    {
        if (value == null)
        {
            _data[name] = null;
            return this;
        }

        var valueType = value.GetType();

        if (valueType.IsEnum)
        {
            _data[name] = value.ToString();
            return this;
        }

        // Check if it's an IEnumerable<T> (but not string, which is IEnumerable<char>)
        if (valueType != typeof(string))
        {
            var enumerableInterface = valueType
                .GetInterfaces()
                .Concat([valueType])
                .FirstOrDefault(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

            if (enumerableInterface is not null)
            {
                var elementType = enumerableInterface.GetGenericArguments()[0];

                if (IsStandardType(elementType))
                {
                    _data[name] = value;
                    return this;
                }
            }
        }

        if (IsStandardType(valueType))
        {
            _data[name] = value;
        }

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

        // Check if T is Document<TData>
        if (IsDocumentType(typeof(T)))
        {
            HandleDocumentChanges(before, after);
            return this;
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

    private bool IsDocumentType(Type type)
    {
        if (!type.IsGenericType)
        {
            return false;
        }

        return type.GetGenericTypeDefinition() == typeof(Document<>);
    }

    private void HandleDocumentChanges<T>(T before, T after) where T : class
    {
        var documentType = typeof(T);
        var idProperty = documentType.GetProperty(nameof(Document<object>.Id));
        var dataProperty = documentType.GetProperty(nameof(Document<object>.Data));

        var beforeId = idProperty.GetValue(before) as string;
        var afterId = idProperty.GetValue(after) as string;

        var beforeData = dataProperty.GetValue(before);
        var afterData = dataProperty.GetValue(after);

        if (beforeData is null || afterData is null)
        {
            return;
        }

        // If IDs match, compare the Data properties
        if (!string.IsNullOrEmpty(beforeId) && beforeId == afterId)
        {
            var dataProperties = afterData.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in dataProperties)
            {
                if (!property.CanRead) continue;

                var beforeValue = property.GetValue(beforeData);
                var afterValue = property.GetValue(afterData);

                if (!IsStandardType(property.PropertyType) && afterValue is null)
                {
                    continue;
                }

                if (!AreValuesEqual(beforeValue, afterValue))
                {
                    var jsonPropertyName = GetJsonPropertyName(property);
                    AddField(jsonPropertyName, afterValue);
                }
            }
        }
        // If IDs don't match, add all properties from after.Data
        else
        {
            var dataProperties = afterData.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in dataProperties)
            {
                if (!property.CanRead) continue;

                var afterValue = property.GetValue(afterData);
                var jsonPropertyName = GetJsonPropertyName(property);
                AddField(jsonPropertyName, afterValue);
            }
        }
    }

    private static bool IsStandardType(Type type) =>
        type.IsPrimitive ||
        type == typeof(string) ||
        type == typeof(DateTime) ||
        type == typeof(DateTimeOffset) ||
        type == typeof(decimal) ||
        type.IsEnum;
}
