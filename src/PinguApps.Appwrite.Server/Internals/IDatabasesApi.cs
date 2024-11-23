using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;
using Refit;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;
using Index = PinguApps.Appwrite.Shared.Responses.Index;

namespace PinguApps.Appwrite.Server.Internals;
internal interface IDatabasesApi : IBaseApi
{
    // Database Operations
    [Get("/databases")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<DatabasesList>> ListDatabases([Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, [AliasAs("search")] string? search);

    [Post("/databases")]
    Task<IApiResponse<Database>> CreateDatabase(CreateDatabaseRequest request);

    [Delete("/databases/{databaseId}")]
    Task<IApiResponse> DeleteDatabase(string databaseId);

    [Get("/databases/{databaseId}")]
    Task<IApiResponse<Database>> GetDatabase(string databaseId);

    [Put("/databases/{databaseId}")]
    Task<IApiResponse<Database>> UpdateDatabase(string databaseId, UpdateDatabaseRequest request);

    // Collection Operations
    [Get("/databases/{databaseId}/collections")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<CollectionsList>> ListCollections(string databaseId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, [AliasAs("search")] string? search);

    [Post("/databases/{databaseId}/collections")]
    Task<IApiResponse<Collection>> CreateCollection(string databaseId, CreateCollectionRequest request);

    [Delete("/databases/{databaseId}/collections/{collectionId}")]
    Task<IApiResponse> DeleteCollection(string databaseId, string collectionId);

    [Get("/databases/{databaseId}/collections/{collectionId}")]
    Task<IApiResponse<Collection>> GetCollection(string databaseId, string collectionId);

    [Put("/databases/{databaseId}/collections/{collectionId}")]
    Task<IApiResponse<Collection>> UpdateCollection(string databaseId, string collectionId, UpdateCollectionRequest request);

    // Attribute Operations
    [Get("/databases/{databaseId}/collections/{collectionId}/attributes")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<AttributesList>> ListAttributes(string databaseId, string collectionId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/boolean")]
    Task<IApiResponse<AttributeBoolean>> CreateBooleanAttribute(string databaseId, string collectionId, CreateBooleanAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/boolean/{key}")]
    Task<IApiResponse<AttributeBoolean>> UpdateBooleanAttribute(string databaseId, string collectionId, string key, UpdateBooleanAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/datetime")]
    Task<IApiResponse<AttributeDatetime>> CreateDatetimeAttribute(string databaseId, string collectionId, CreateDatetimeAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/datetime/{key}")]
    Task<IApiResponse<AttributeDatetime>> UpdateDatetimeAttribute(string databaseId, string collectionId, string key, UpdateDatetimeAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/email")]
    Task<IApiResponse<AttributeEmail>> CreateEmailAttribute(string databaseId, string collectionId, CreateEmailAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/email/{key}")]
    Task<IApiResponse<AttributeEmail>> UpdateEmailAttribute(string databaseId, string collectionId, string key, UpdateEmailAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/enum")]
    Task<IApiResponse<AttributeEnum>> CreateEnumAttribute(string databaseId, string collectionId, CreateEnumAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/enum/{key}")]
    Task<IApiResponse<AttributeEnum>> UpdateEnumAttribute(string databaseId, string collectionId, string key, UpdateEnumAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/float")]
    Task<IApiResponse<AttributeFloat>> CreateFloatAttribute(string databaseId, string collectionId, CreateFloatAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/float/{key}")]
    Task<IApiResponse<AttributeFloat>> UpdateFloatAttribute(string databaseId, string collectionId, string key, UpdateFloatAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/integer")]
    Task<IApiResponse<AttributeInteger>> CreateIntegerAttribute(string databaseId, string collectionId, CreateIntegerAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/integer/{key}")]
    Task<IApiResponse<AttributeInteger>> UpdateIntegerAttribute(string databaseId, string collectionId, string key, UpdateIntegerAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/ip")]
    Task<IApiResponse<AttributeIp>> CreateIpAttribute(string databaseId, string collectionId, CreateIPAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/ip/{key}")]
    Task<IApiResponse<AttributeIp>> UpdateIpAttribute(string databaseId, string collectionId, string key, UpdateIPAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/relationship")]
    Task<IApiResponse<AttributeRelationship>> CreateRelationshipAttribute(string databaseId, string collectionId, CreateRelationshipAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/string")]
    Task<IApiResponse<AttributeString>> CreateStringAttribute(string databaseId, string collectionId, CreateStringAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/string/{key}")]
    Task<IApiResponse<AttributeString>> UpdateStringAttribute(string databaseId, string collectionId, string key, UpdateStringAttributeRequest request);

    [Post("/databases/{databaseId}/collections/{collectionId}/attributes/url")]
    Task<IApiResponse<AttributeUrl>> CreateUrlAttribute(string databaseId, string collectionId, CreateURLAttributeRequest request);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/url/{key}")]
    Task<IApiResponse<AttributeUrl>> UpdateUrlAttribute(string databaseId, string collectionId, string key, UpdateURLAttributeRequest request);

    [Delete("/databases/{databaseId}/collections/{collectionId}/attributes/{key}")]
    Task<IApiResponse> DeleteAttribute(string databaseId, string collectionId, string key);

    [Get("/databases/{databaseId}/collections/{collectionId}/attributes/{key}")]
    Task<IApiResponse<Attribute>> GetAttribute(string databaseId, string collectionId, string key);

    [Patch("/databases/{databaseId}/collections/{collectionId}/attributes/{key}/relationship")]
    Task<IApiResponse<AttributeRelationship>> UpdateRelationshipAttribute(string databaseId, string collectionId, string key, UpdateRelationshipAttributeRequest request);

    // Document Operations
    [Get("/databases/{databaseId}/collections/{collectionId}/documents")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<DocumentsList>> ListDocuments(string databaseId, string collectionId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries);

    [Post("/databases/{databaseId}/collections/{collectionId}/documents")]
    Task<IApiResponse<Document>> CreateDocument(string databaseId, string collectionId, CreateDocumentRequest request);

    [Delete("/databases/{databaseId}/collections/{collectionId}/documents/{documentId}")]
    Task<IApiResponse> DeleteDocument(string databaseId, string collectionId, string documentId);

    [Get("/databases/{databaseId}/collections/{collectionId}/documents/{documentId}")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<Document>> GetDocument(string databaseId, string collectionId, string documentId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries);

    [Patch("/databases/{databaseId}/collections/{collectionId}/documents/{documentId}")]
    Task<IApiResponse<Document>> UpdateDocument(string databaseId, string collectionId, string documentId, UpdateDocumentRequest request);

    // Index Operations
    [Get("/databases/{databaseId}/collections/{collectionId}/indexes")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<IndexesList>> ListIndexes(string databaseId, string collectionId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries);

    [Post("/databases/{databaseId}/collections/{collectionId}/indexes")]
    Task<IApiResponse<Index>> CreateIndex(string databaseId, string collectionId, CreateIndexRequest request);

    [Delete("/databases/{databaseId}/collections/{collectionId}/indexes/{key}")]
    Task<IApiResponse> DeleteIndex(string databaseId, string collectionId, string key);

    [Get("/databases/{databaseId}/collections/{collectionId}/indexes/{key}")]
    Task<IApiResponse<Index>> GetIndex(string databaseId, string collectionId, string key);
}
