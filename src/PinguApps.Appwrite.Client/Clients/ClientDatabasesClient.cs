using System;
using System.Threading.Tasks;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Client.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client.Clients;

/// <inheritdoc/>
public class ClientDatabasesClient : SessionAwareClientBase, IClientDatabasesClient
{
    private readonly IDatabasesApi _databasesApi;

    internal ClientDatabasesClient(IDatabasesApi databasesApi)
    {
        _databasesApi = databasesApi;
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<DocumentsList>> ListDocuments(ListDocumentsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.ListDocuments(GetCurrentSession(), request.DatabaseId, request.CollectionId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<DocumentsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<DocumentsList<TData>>> ListDocuments<TData>(ListDocumentsRequest request)
        where TData : class, new()
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.ListDocuments<TData>(GetCurrentSession(), request.DatabaseId, request.CollectionId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<DocumentsList<TData>>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Document>> CreateDocument(CreateDocumentRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateDocument(GetCurrentSession(), request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Document>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Document<TData>>> CreateDocument<TData>(CreateDocumentRequest request)
        where TData : class, new()
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.CreateDocument<TData>(GetCurrentSession(), request.DatabaseId, request.CollectionId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Document<TData>>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteDocument(DeleteDocumentRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.DeleteDocument(GetCurrentSession(), request.DatabaseId, request.CollectionId, request.DocumentId);

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

            var result = await _databasesApi.GetDocument(GetCurrentSession(), request.DatabaseId, request.CollectionId, request.DocumentId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Document>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Document<TData>>> GetDocument<TData>(GetDocumentRequest request)
        where TData : class, new()
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.GetDocument<TData>(GetCurrentSession(), request.DatabaseId, request.CollectionId, request.DocumentId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Document<TData>>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Document>> UpdateDocument(UpdateDocumentRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateDocument(GetCurrentSession(), request.DatabaseId, request.CollectionId, request.DocumentId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Document>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Document<TData>>> UpdateDocument<TData>(UpdateDocumentRequest request)
        where TData : class, new()
    {
        try
        {
            request.Validate(true);

            var result = await _databasesApi.UpdateDocument<TData>(GetCurrentSession(), request.DatabaseId, request.CollectionId, request.DocumentId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Document<TData>>();
        }
    }
}
