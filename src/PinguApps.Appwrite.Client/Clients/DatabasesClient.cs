using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Client.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client.Clients;

/// <inheritdoc/>
public class DatabasesClient : SessionAwareClientBase, IDatabasesClient
{
    private readonly IDatabasesApi _databasesApi;

    internal DatabasesClient(IDatabasesApi databasesApi)
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

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Document>> UpdateDocument(UpdateDocumentRequest request) => throw new NotImplementedException();
}
