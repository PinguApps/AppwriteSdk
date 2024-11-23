using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using PinguApps.Appwrite.Client.Internals;
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
}
