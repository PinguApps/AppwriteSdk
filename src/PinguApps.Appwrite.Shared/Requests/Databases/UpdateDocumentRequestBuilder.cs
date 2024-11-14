using System.Collections.Generic;
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

    public UpdateDocumentRequest Build()
    {
        _request.Data = _data;
        return _request;
    }
}
