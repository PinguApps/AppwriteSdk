using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;
internal interface IDatabasesApi : IBaseApi
{
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
}
