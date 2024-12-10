using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;
using Index = PinguApps.Appwrite.Shared.Responses.Index;

namespace PinguApps.Appwrite.Server.Clients;

/// <inheritdoc/>
public class DatabasesClient : IDatabasesClient
{
    private readonly IDatabasesApi _databasesApi;

    internal DatabasesClient(IDatabasesApi databasesApi)
    {
        _databasesApi = databasesApi;
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<DatabasesList>> ListDatabases(ListDatabasesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.ListDatabases(RequestUtils.GetQueryStrings(request.Queries), request.Search);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<DatabasesList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Database>> CreateDatabase(CreateDatabaseRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateDatabase(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Database>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteDatabase(DeleteDatabaseRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.DeleteDatabase(request.DatabaseId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Database>> GetDatabase(GetDatabaseRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.GetDatabase(request.DatabaseId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Database>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Database>> UpdateDatabase(UpdateDatabaseRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateDatabase(request.DatabaseId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Database>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<CollectionsList>> ListCollections(ListCollectionsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.ListCollections(request.DatabaseId, RequestUtils.GetQueryStrings(request.Queries), request.Search);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<CollectionsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Collection>> CreateCollection(CreateCollectionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateCollection(request.DatabaseId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Collection>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteCollection(DeleteCollectionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.DeleteCollection(request.DatabaseId, request.CollectionId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Collection>> GetCollection(GetCollectionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.GetCollection(request.DatabaseId, request.CollectionId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Collection>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Collection>> UpdateCollection(UpdateCollectionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateCollection(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Collection>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributesList>> ListAttributes(ListAttributesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.ListAttributes(request.DatabaseId, request.CollectionId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributesList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeBoolean>> CreateBooleanAttribute(CreateBooleanAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateBooleanAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeBoolean>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeBoolean>> UpdateBooleanAttribute(UpdateBooleanAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateBooleanAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeBoolean>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeDatetime>> CreateDatetimeAttribute(CreateDatetimeAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateDatetimeAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeDatetime>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeDatetime>> UpdateDatetimeAttribute(UpdateDatetimeAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateDatetimeAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeDatetime>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeEmail>> CreateEmailAttribute(CreateEmailAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateEmailAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeEmail>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeEmail>> UpdateEmailAttribute(UpdateEmailAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateEmailAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeEmail>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeEnum>> CreateEnumAttribute(CreateEnumAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateEnumAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeEnum>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeEnum>> UpdateEnumAttribute(UpdateEnumAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateEnumAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeEnum>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeFloat>> CreateFloatAttribute(CreateFloatAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateFloatAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeFloat>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeFloat>> UpdateFloatAttribute(UpdateFloatAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateFloatAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeFloat>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeInteger>> CreateIntegerAttribute(CreateIntegerAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateIntegerAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeInteger>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeInteger>> UpdateIntegerAttribute(UpdateIntegerAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateIntegerAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeInteger>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeIp>> CreateIpAttribute(CreateIPAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateIpAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeIp>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeIp>> UpdateIpAttribute(UpdateIPAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateIpAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeIp>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeRelationship>> CreateRelationshipAttribute(CreateRelationshipAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateRelationshipAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeRelationship>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeString>> CreateStringAttribute(CreateStringAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateStringAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeString>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeString>> UpdateStringAttribute(UpdateStringAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateStringAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeString>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeUrl>> CreateUrlAttribute(CreateURLAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateUrlAttribute(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeUrl>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeUrl>> UpdateUrlAttribute(UpdateURLAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateUrlAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeUrl>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteAttribute(DeleteAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.DeleteAttribute(request.DatabaseId, request.CollectionId, request.Key);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Attribute>> GetAttribute(GetAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.GetAttribute(request.DatabaseId, request.CollectionId, request.Key);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Attribute>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<AttributeRelationship>> UpdateRelationshipAttribute(UpdateRelationshipAttributeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateRelationshipAttribute(request.DatabaseId, request.CollectionId, request.Key, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<AttributeRelationship>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<DocumentsList>> ListDocuments(ListDocumentsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.ListDocuments(request.DatabaseId, request.CollectionId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<DocumentsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Document>> CreateDocument(CreateDocumentRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateDocument(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Document>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteDocument(DeleteDocumentRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.DeleteDocument(request.DatabaseId, request.CollectionId, request.DocumentId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Document>> GetDocument(GetDocumentRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.GetDocument(request.DatabaseId, request.CollectionId, request.DocumentId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Document>();
        }
    }

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Document>> UpdateDocument(UpdateDocumentRequest request) => throw new NotImplementedException();

    /// <inheritdoc/>
    public async Task<AppwriteResult<IndexesList>> ListIndexes(ListIndexesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.ListIndexes(request.DatabaseId, request.CollectionId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<IndexesList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Index>> CreateIndex(CreateIndexRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateIndex(request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Index>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteIndex(DeleteIndexRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.DeleteIndex(request.DatabaseId, request.CollectionId, request.Key);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Index>> GetIndex(GetIndexRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.GetIndex(request.DatabaseId, request.CollectionId, request.Key);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Index>();
        }
    }
}
