using System;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;
using Index = PinguApps.Appwrite.Shared.Responses.Index;

namespace PinguApps.Appwrite.Server.Clients;

/// <summary>
/// <para>The Databases service allows you to create structured collections of documents, query and filter lists of documents, and manage an advanced set of read and write access permissions.</para>
/// <para>All data returned by the Databases service are represented as structured JSON documents.</para>
/// <para>The Databases service can contain multiple databases, each database can contain multiple collections. A collection is a group of similarly structured documents. The accepted structure of documents is defined by <see href="https://appwrite.io/docs/products/databases/collections#attributes">collection attributes</see>. The collection attributes help you ensure all your user-submitted data is validated and stored according to the collection structure.</para>
/// <para>Using Appwrite permissions architecture, you can assign read or write access to each collection or document in your project for either a specific user, team, user role, or even grant it with public access (any). You can learn more about <see href="https://appwrite.io/docs/products/databases/permissions">how Appwrite handles permissions and access control</see>.</para>
/// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/databases">Appwrite Docs</see></para>
/// </summary>
public interface IDatabasesClient
{
    /// <summary>
    /// Get a list of all databases from the current Appwrite project. You can use the search parameter to filter your results.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#list">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The databases list</returns>
    Task<AppwriteResult<DatabasesList>> ListDatabases(ListDatabasesRequest request);

    /// <summary>
    /// Create a new Database.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#create">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The database</returns>
    Task<AppwriteResult<Database>> CreateDatabase(CreateDatabaseRequest request);

    /// <summary>
    /// Delete a database by its unique ID. Only API keys with with databases.write scope can delete a database.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#delete">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>200 Success Response</returns>
    Task<AppwriteResult> DeleteDatabase(DeleteDatabaseRequest request);

    /// <summary>
    /// Get a database by its unique ID. This endpoint response returns a JSON object with the database metadata.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#get">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The database</returns>
    Task<AppwriteResult<Database>> GetDatabase(GetDatabaseRequest request);

    /// <summary>
    /// Update a database by its unique ID.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#update">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The database</returns>
    Task<AppwriteResult<Database>> UpdateDatabase(UpdateDatabaseRequest request);

    /// <summary>
    /// Get a list of all collections that belong to the provided databaseId. You can use the search parameter to filter your results.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#listCollections">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The collections list</returns>
    Task<AppwriteResult<CollectionsList>> ListCollections(ListCollectionsRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeBoolean>> CreateBooleanAttribute(CreateBooleanAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Collection>> CreateCollection(CreateCollectionRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeDatetime>> CreateDatetimeAttribute(CreateDatetimeAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Document>> CreateDocument(CreateDocumentRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeEmail>> CreateEmailAttribute(CreateEmailAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeEnum>> CreateEnumAttribute(CreateEnumAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeFloat>> CreateFloatAttribute(CreateFloatAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Index>> CreateIndex(CreateIndexRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeInteger>> CreateIntegerAttribute(CreateIntegerAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeIp>> CreateIpAttribute(CreateIPAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeRelationship>> CreateRelationshipAttribute(CreateRelationshipAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeString>> CreateStringAttribute(CreateStringAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeUrl>> CreateUrlAttribute(CreateURLAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult> DeleteAttribute(DeleteAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult> DeleteCollection(DeleteCollectionRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult> DeleteDocument(DeleteDocumentRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult> DeleteIndex(DeleteIndexRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Attribute>> GetAttribute(GetAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Collection>> GetCollection(GetCollectionRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Document>> GetDocument(GetDocumentRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Index>> GetIndex(GetIndexRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributesList>> ListAttributes(ListAttributesRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<DocumentsList>> ListDocuments(ListDocumentsRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<IndexesList>> ListIndexes(ListIndexesRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeBoolean>> UpdateBooleanAttribute(UpdateBooleanAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Collection>> UpdateCollection(UpdateCollectionRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeDatetime>> UpdateDatetimeAttribute(UpdateDatetimeAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<Document>> UpdateDocument(UpdateDocumentRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeEmail>> UpdateEmailAttribute(UpdateEmailAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeEnum>> UpdateEnumAttribute(UpdateEnumAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeFloat>> UpdateFloatAttribute(UpdateFloatAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeInteger>> UpdateIntegerAttribute(UpdateIntegerAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeIp>> UpdateIpAttribute(UpdateIPAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeRelationship>> UpdateRelationshipAttribute(UpdateRelationshipAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeString>> UpdateStringAttribute(UpdateStringAttributeRequest request);

    [Obsolete("Endpoint not yet implemented.")]
    Task<AppwriteResult<AttributeUrl>> UpdateUrlAttribute(UpdateURLAttributeRequest request);
}
