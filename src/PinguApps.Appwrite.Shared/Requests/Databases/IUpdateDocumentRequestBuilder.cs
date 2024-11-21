using System.Collections.Generic;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;
/// <summary>
/// Builder interface for creating document requests
/// </summary>
public interface IUpdateDocumentRequestBuilder
{
    /// <summary>
    /// Sets the database identifier
    /// </summary>
    IUpdateDocumentRequestBuilder WithDatabaseId(string databaseId);

    /// <summary>
    /// Sets the collection identifier
    /// </summary>
    IUpdateDocumentRequestBuilder WithCollectionId(string collectionId);

    /// <summary>
    /// Sets the document identifier
    /// </summary>
    IUpdateDocumentRequestBuilder WithDocumentId(string documentId);

    /// <summary>
    /// Sets the document permissions
    /// </summary>
    IUpdateDocumentRequestBuilder WithPermissions(List<Permission> permissions);

    /// <summary>
    /// Adds a permission for the document
    /// </summary>
    IUpdateDocumentRequestBuilder AddPermission(Permission permission);

    /// <summary>
    /// Adds a field to the document data
    /// </summary>
    IUpdateDocumentRequestBuilder AddField(string name, object? value);

    /// <summary>
    /// Builds the document request
    /// </summary>
    UpdateDocumentRequest Build();

    /// <summary>
    /// Compares a before and after snapshop of an object, and adds any changed values to the document data
    /// </summary>
    /// <typeparam name="T">The model type</typeparam>
    /// <param name="before">The values before any modifications</param>
    /// <param name="after">The values after modifications</param>
    /// <returns></returns>
    IUpdateDocumentRequestBuilder WithChanges<T>(T before, T after) where T : class;
}
