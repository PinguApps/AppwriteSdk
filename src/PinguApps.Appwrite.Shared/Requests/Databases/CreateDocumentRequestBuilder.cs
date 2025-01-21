using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Utils;
using static PinguApps.Appwrite.Shared.Requests.Databases.ICreateDocumentRequestBuilder;

namespace PinguApps.Appwrite.Shared.Requests.Databases;
internal class CreateDocumentRequestBuilder : ICreateDocumentRequestBuilder
{
    private readonly CreateDocumentRequest _request = new();
    private readonly Dictionary<string, object?> _data = [];

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propertyCache = new();

    public ICreateDocumentRequestBuilder WithDatabaseId(string databaseId)
    {
        _request.DatabaseId = databaseId;
        return this;
    }

    public ICreateDocumentRequestBuilder WithCollectionId(string collectionId)
    {
        _request.CollectionId = collectionId;
        return this;
    }

    public ICreateDocumentRequestBuilder WithDocumentId(string documentId)
    {
        _request.DocumentId = documentId;
        return this;
    }

    public ICreateDocumentRequestBuilder WithPermissions(List<Permission> permissions)
    {
        _request.Permissions = permissions;
        return this;
    }

    public ICreateDocumentRequestBuilder AddPermission(Permission permission)
    {
        if (_request.Permissions is null)
        {
            _request.Permissions = [];
        }
        _request.Permissions.Add(permission);
        return this;
    }

    public ICreateDocumentRequestBuilder AddField(string name, object? value)
    {
        _data[name] = value;
        return this;
    }

    public ICreateDocumentRequestBuilder WithData<T>(T? data, Action<WithDataOptions>? options = null) where T : class
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        var withDataOptions = new WithDataOptions();
        options?.Invoke(withDataOptions);

        var properties = _propertyCache.GetOrAdd(typeof(T), x => x.GetProperties(BindingFlags.Public | BindingFlags.Instance));

        foreach (var property in properties)
        {
            if (!withDataOptions.ShouldIncludeProperty(property))
            {
                continue;
            }

            var jsonPropertyName = GetJsonPropertyName(property);

            var value = property.GetValue(data);
            if (value is not null || !withDataOptions.IgnoreNullValues)
            {
                AddField(jsonPropertyName, value);
            }
        }

        return this;
    }

    [ExcludeFromCodeCoverage]
    private static string GetJsonPropertyName(PropertyInfo property)
    {
        return property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name
            ?? _jsonOptions.PropertyNamingPolicy?.ConvertName(property.Name)
            ?? property.Name;
    }

    public CreateDocumentRequest Build()
    {
        _request.Data = _data;
        return _request;
    }
}
