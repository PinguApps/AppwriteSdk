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

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Collection>> CreateCollection(CreateCollectionRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteCollection(DeleteCollectionRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Collection>> GetCollection(GetCollectionRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Collection>> UpdateCollection(UpdateCollectionRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributesList>> ListAttributes(ListAttributesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeBoolean>> CreateBooleanAttribute(CreateBooleanAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeBoolean>> UpdateBooleanAttribute(UpdateBooleanAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeDatetime>> CreateDatetimeAttribute(CreateDatetimeAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeDatetime>> UpdateDatetimeAttribute(UpdateDatetimeAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeEmail>> CreateEmailAttribute(CreateEmailAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeEmail>> UpdateEmailAttribute(UpdateEmailAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeEnum>> CreateEnumAttribute(CreateEnumAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeEnum>> UpdateEnumAttribute(UpdateEnumAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeFloat>> CreateFloatAttribute(CreateFloatAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeFloat>> UpdateFloatAttribute(UpdateFloatAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeInteger>> CreateIntegerAttribute(CreateIntegerAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeInteger>> UpdateIntegerAttribute(UpdateIntegerAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeIp>> CreateIpAttribute(CreateIPAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeIp>> UpdateIpAttribute(UpdateIPAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeRelationship>> CreateRelationshipAttribute(CreateRelationshipAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeString>> CreateStringAttribute(CreateStringAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeString>> UpdateStringAttribute(UpdateStringAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeUrl>> CreateUrlAttribute(CreateURLAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeUrl>> UpdateUrlAttribute(UpdateURLAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteAttribute(DeleteAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Attribute>> GetAttribute(GetAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<AttributeRelationship>> UpdateRelationshipAttribute(UpdateRelationshipAttributeRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<DocumentsList>> ListDocuments(ListDocumentsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Document>> CreateDocument(CreateDocumentRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteDocument(DeleteDocumentRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Document>> GetDocument(GetDocumentRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Document>> UpdateDocument(UpdateDocumentRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<IndexesList>> ListIndexes(ListIndexesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Index>> CreateIndex(CreateIndexRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteIndex(DeleteIndexRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Index>> GetIndex(GetIndexRequest request) => throw new NotImplementedException();
}
