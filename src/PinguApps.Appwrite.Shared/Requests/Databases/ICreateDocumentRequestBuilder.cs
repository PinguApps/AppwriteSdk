using System.Collections.Generic;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// Builder interface for creating document requests
/// </summary>
public interface ICreateDocumentRequestBuilder
{
    /// <summary>
    /// Sets the database identifier
    /// </summary>
    ICreateDocumentRequestBuilder WithDatabaseId(string databaseId);

    /// <summary>
    /// Sets the collection identifier
    /// </summary>
    ICreateDocumentRequestBuilder WithCollectionId(string collectionId);

    /// <summary>
    /// Sets the document identifier
    /// </summary>
    ICreateDocumentRequestBuilder WithDocumentId(string documentId);

    /// <summary>
    /// Sets the document permissions
    /// </summary>
    ICreateDocumentRequestBuilder WithPermissions(List<Permission> permissions);

    /// <summary>
    /// Adds a permission for the document
    /// </summary>
    ICreateDocumentRequestBuilder AddPermission(Permission permission);

    /// <summary>
    /// Adds a field to the document data
    /// </summary>
    ICreateDocumentRequestBuilder AddField(string name, object? value);

    /// <summary>
    /// Builds the document request
    /// </summary>
    CreateDocumentRequest Build();
}
