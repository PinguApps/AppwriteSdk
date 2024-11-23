using System.Collections.Generic;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;
internal class CreateDocumentRequestBuilder : ICreateDocumentRequestBuilder
{
    private readonly CreateDocumentRequest _request = new();
    private readonly Dictionary<string, object?> _data = [];

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
        _request.Permissions.Add(permission);
        return this;
    }

    public ICreateDocumentRequestBuilder AddField(string name, object? value)
    {
        _data[name] = value;
        return this;
    }

    public CreateDocumentRequest Build()
    {
        _request.Data = _data;
        return _request;
    }
}
