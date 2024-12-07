﻿using System;
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
/// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/databases">Appwrite Docs</see></para>
/// </summary>
public interface IDatabasesClient
{
    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Document>> CreateDocument(CreateDocumentRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult> DeleteDocument(DeleteDocumentRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Document>> GetDocument(GetDocumentRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<DocumentsList>> ListDocuments(ListDocumentsRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Document>> UpdateDocument(UpdateDocumentRequest request);
}
