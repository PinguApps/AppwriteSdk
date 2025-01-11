using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Enums;
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
public interface IServerDatabasesClient
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

    /// <summary>
    /// Create a new Collection. Before using this route, you should create a new database resource using either <see cref="CreateDatabase(CreateDatabaseRequest)"/> or directly from your database console.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createCollection">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The collection</returns>
    Task<AppwriteResult<Collection>> CreateCollection(CreateCollectionRequest request);

    /// <summary>
    /// Delete a collection by its unique ID. Only users with write permissions have access to delete this resource.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#deleteCollection">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 Success Response</returns>
    Task<AppwriteResult> DeleteCollection(DeleteCollectionRequest request);

    /// <summary>
    /// Get a collection by its unique ID. This endpoint response returns a JSON object with the collection metadata.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#getCollection">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The collection</returns>
    Task<AppwriteResult<Collection>> GetCollection(GetCollectionRequest request);

    /// <summary>
    /// Update a collection by its unique ID.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateCollection">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The collection</returns>
    Task<AppwriteResult<Collection>> UpdateCollection(UpdateCollectionRequest request);

    /// <summary>
    /// List attributes in the collection.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#listAttributes">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The attributes list</returns>
    Task<AppwriteResult<AttributesList>> ListAttributes(ListAttributesRequest request);

    /// <summary>
    /// Create a boolean attribute.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createBooleanAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The boolean attribute</returns>
    Task<AppwriteResult<AttributeBoolean>> CreateBooleanAttribute(CreateBooleanAttributeRequest request);

    /// <summary>
    /// Update a boolean attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateBooleanAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The boolean attribute</returns>
    Task<AppwriteResult<AttributeBoolean>> UpdateBooleanAttribute(UpdateBooleanAttributeRequest request);

    /// <summary>
    /// Create a date time attribute according to the ISO 8601 standard.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createDatetimeAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The datetime attribute</returns>
    Task<AppwriteResult<AttributeDatetime>> CreateDatetimeAttribute(CreateDatetimeAttributeRequest request);

    /// <summary>
    /// Update a date time attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateDatetimeAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The datetime attribute</returns>
    Task<AppwriteResult<AttributeDatetime>> UpdateDatetimeAttribute(UpdateDatetimeAttributeRequest request);

    /// <summary>
    /// Create an email attribute.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createEmailAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The email attribute</returns>
    Task<AppwriteResult<AttributeEmail>> CreateEmailAttribute(CreateEmailAttributeRequest request);

    /// <summary>
    /// Update an email attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateEmailAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The email attribute</returns>
    Task<AppwriteResult<AttributeEmail>> UpdateEmailAttribute(UpdateEmailAttributeRequest request);

    /// <summary>
    /// Create an enumeration attribute. The elements param acts as a white-list of accepted values for this attribute.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createEnumAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The enum attribute</returns>
    Task<AppwriteResult<AttributeEnum>> CreateEnumAttribute(CreateEnumAttributeRequest request);

    /// <summary>
    /// Update an enumeration attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateEnumAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The enum attribute</returns>
    Task<AppwriteResult<AttributeEnum>> UpdateEnumAttribute(UpdateEnumAttributeRequest request);

    /// <summary>
    /// Create a float attribute. Optionally, minimum and maximum values can be provided.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createFloatAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The float attribute</returns>
    Task<AppwriteResult<AttributeFloat>> CreateFloatAttribute(CreateFloatAttributeRequest request);

    /// <summary>
    /// Update a float attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateFloatAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The float attribute</returns>
    Task<AppwriteResult<AttributeFloat>> UpdateFloatAttribute(UpdateFloatAttributeRequest request);

    /// <summary>
    /// Create an integer attribute. Optionally, minimum and maximum values can be provided.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createIntegerAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The integer attribute</returns>
    Task<AppwriteResult<AttributeInteger>> CreateIntegerAttribute(CreateIntegerAttributeRequest request);

    /// <summary>
    /// Update an integer attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateIntegerAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The integer attribute</returns>
    Task<AppwriteResult<AttributeInteger>> UpdateIntegerAttribute(UpdateIntegerAttributeRequest request);

    /// <summary>
    /// Create an IP attribute.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createIpAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The ip address attribute</returns>
    Task<AppwriteResult<AttributeIp>> CreateIpAttribute(CreateIPAttributeRequest request);

    /// <summary>
    /// Update an IP attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateIpAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The ip address attribute</returns>
    Task<AppwriteResult<AttributeIp>> UpdateIpAttribute(UpdateIPAttributeRequest request);

    /// <summary>
    /// Create relationship attribute. <see href="https://appwrite.io/docs/databases-relationships#relationship-attributes">Learn more about relationship attributes</see>.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createRelationshipAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The relationship attribute</returns>
    Task<AppwriteResult<AttributeRelationship>> CreateRelationshipAttribute(CreateRelationshipAttributeRequest request);

    /// <summary>
    /// Create a string attribute.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createStringAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The string attribute</returns>
    Task<AppwriteResult<AttributeString>> CreateStringAttribute(CreateStringAttributeRequest request);

    /// <summary>
    /// Update a string attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateStringAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The string attribute</returns>
    Task<AppwriteResult<AttributeString>> UpdateStringAttribute(UpdateStringAttributeRequest request);

    /// <summary>
    /// Create a URL attribute.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createUrlAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The url attribute</returns>
    Task<AppwriteResult<AttributeUrl>> CreateUrlAttribute(CreateURLAttributeRequest request);

    /// <summary>
    /// Update a URL attribute. Changing the <c>default</c> value will not update already existing documents.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateUrlAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The url attribute</returns>
    Task<AppwriteResult<AttributeUrl>> UpdateUrlAttribute(UpdateURLAttributeRequest request);

    /// <summary>
    /// Deletes an attribute.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#deleteAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteAttribute(DeleteAttributeRequest request);

    /// <summary>
    /// Get attribute by ID.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#getAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The attribute</returns>
    Task<AppwriteResult<Attribute>> GetAttribute(GetAttributeRequest request);

    /// <summary>
    /// Update relationship attribute. <see href="https://appwrite.io/docs/databases-relationships#relationship-attributes">Learn more about relationship attributes</see>.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateRelationshipAttribute">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The relationship attribute</returns>
    Task<AppwriteResult<AttributeRelationship>> UpdateRelationshipAttribute(UpdateRelationshipAttributeRequest request);

    /// <summary>
    /// Get a list of all the user's documents in a given collection. You can use the query params to filter your results.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#listDocuments">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The documents list</returns>
    Task<AppwriteResult<DocumentsList>> ListDocuments(ListDocumentsRequest request);

    /// <summary>
    /// Get a list of all the user's documents in a given collection. You can use the query params to filter your results.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#listDocuments">Appwrite Docs</see></para>
    /// </summary>
    /// <typeparam name="TData">The data type for your documents</typeparam>
    /// <param name="request">The request content</param>
    /// <returns>The documents list</returns>
    Task<AppwriteResult<DocumentsList<TData>>> ListDocuments<TData>(ListDocumentsRequest request) where TData : class, new();

    /// <summary>
    /// Create a new Document. Before using this route, you should create a new collection resource using either <see cref="CreateCollection(CreateCollectionRequest)"/> or directly from your database console.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document>> CreateDocument(CreateDocumentRequest request);

    /// <summary>
    /// Create a new Document. Before using this route, you should create a new collection resource using either <see cref="CreateCollection(CreateCollectionRequest)"/> or directly from your database console.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <typeparam name="TData">The data type for your document</typeparam>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document<TData>>> CreateDocument<TData>(CreateDocumentRequest<TData> request) where TData : class, new();

    /// <summary>
    /// Create a new Document. Before using this route, you should create a new collection resource using either <see cref="CreateCollection(CreateCollectionRequest)"/> or directly from your database console.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <typeparam name="TData">The data type for your data</typeparam>
    /// <typeparam name="TResponse">The data type for your response</typeparam>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document<TResponse>>> CreateDocument<TData, TResponse>(CreateDocumentRequest<TData> request)
        where TData : class, new()
        where TResponse : class, new();

    /// <summary>
    /// Delete a document by its unique ID.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#deleteDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteDocument(DeleteDocumentRequest request);

    /// <summary>
    /// Get a document by its unique ID. This endpoint response returns a JSON object with the document data. You can return select columns by passing in a Select query.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#getDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document>> GetDocument(GetDocumentRequest request);

    /// <summary>
    /// Get a document by its unique ID. This endpoint response returns a JSON object with the document data. You can return select columns by passing in a Select query.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#getDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <typeparam name="TData">The data type for your document</typeparam>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document<TData>>> GetDocument<TData>(GetDocumentRequest request) where TData : class, new();

    /// <summary>
    /// Update a document by its unique ID. Using the patch method you can pass only specific fields that will get updated.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document>> UpdateDocument(UpdateDocumentRequest request);

    /// <summary>
    /// Update a document by its unique ID. Using the patch method you can pass only specific fields that will get updated.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#updateDocument">Appwrite Docs</see></para>
    /// </summary>
    /// <typeparam name="TData">The data type for your document</typeparam>
    /// <param name="request">The request content</param>
    /// <returns>The document</returns>
    Task<AppwriteResult<Document<TData>>> UpdateDocument<TData>(UpdateDocumentRequest request) where TData : class, new();

    /// <summary>
    /// List indexes in the collection.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#listIndexes">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The indexes list</returns>
    Task<AppwriteResult<IndexesList>> ListIndexes(ListIndexesRequest request);

    /// <summary>
    /// Creates an index on the attributes listed. Your index should include all the attributes you will query in a single request. Attributes can be <see cref="IndexType.Key"/>, <see cref="IndexType.Fulltext"/> and <see cref="IndexType.Unique"/>.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#createIndex">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The index</returns>
    Task<AppwriteResult<Index>> CreateIndex(CreateIndexRequest request);

    /// <summary>
    /// Delete an index.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#deleteIndex">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteIndex(DeleteIndexRequest request);

    /// <summary>
    /// Get index by ID.
    /// <para><see href="https://appwrite.io/docs/references/cloud/server-rest/databases#getIndex">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The index</returns>
    Task<AppwriteResult<Index>> GetIndex(GetIndexRequest request);
}
