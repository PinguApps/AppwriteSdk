using System;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client.Clients;

/// <summary>
/// <para>The Databases service allows you to create structured collections of documents, query and filter lists of documents, and manage an advanced set of read and write access permissions.</para>
/// <para>All data returned by the Databases service are represented as structured JSON documents.</para>
/// <para>The Databases service can contain multiple databases, each database can contain multiple collections. A collection is a group of similarly structured documents. The accepted structure of documents is defined by <see href="https://appwrite.io/docs/products/databases/collections#attributes">collection attributes</see>. The collection attributes help you ensure all your user-submitted data is validated and stored according to the collection structure.</para>
/// <para>Using Appwrite permissions architecture, you can assign read or write access to each collection or document in your project for either a specific user, team, user role, or even grant it with public access (any). You can learn more about <see href="https://appwrite.io/docs/products/databases/permissions">how Appwrite handles permissions and access control</see>.</para>
/// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/databases">Appwrite Docs</see></para>
/// </summary>
public interface IDatabasesClient
{
    /// <summary>
    /// Get a list of all the user's documents in a given collection. You can use the query params to filter your results.
    /// <para><see href="https://appwrite.io/docs/references/cloud/client-rest/databases#listDocuments">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The documents list</returns>
    Task<AppwriteResult<DocumentsList>> ListDocuments(ListDocumentsRequest request);

    /// <summary>
    /// Create a new Document. Before using this route, you should create a new collection resource using either a <see href="https://appwrite.io/docs/server/databases#databasesCreateCollection">server integration</see> API or directly from your database console.
    /// <para><see href="https://appwrite.io/docs/references/cloud/client-rest/databases#createDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document>> CreateDocument(CreateDocumentRequest request);

    /// <summary>
    /// Delete a document by its unique ID.
    /// <para><see href="https://appwrite.io/docs/references/cloud/client-rest/databases#deleteDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 Success Code</returns>
    Task<AppwriteResult> DeleteDocument(DeleteDocumentRequest request);

    /// <summary>
    /// Get a document by its unique ID. This endpoint response returns a JSON object with the document data. You can return select columns by passing in a Select query.
    /// <para><see href="https://appwrite.io/docs/references/cloud/client-rest/databases#getDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document>> GetDocument(GetDocumentRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Document>> UpdateDocument(UpdateDocumentRequest request);
}
