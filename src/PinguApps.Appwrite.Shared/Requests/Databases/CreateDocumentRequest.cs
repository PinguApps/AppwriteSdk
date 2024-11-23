using System.Collections.Generic;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create a document
/// </summary>
public class CreateDocumentRequest : CreateDocumentRequest<Dictionary<string, object?>>
{
    internal CreateDocumentRequest() { }

    /// <summary>
    /// Creates a new builder for creating a document request
    /// </summary>
    public static ICreateDocumentRequestBuilder CreateBuilder() => new CreateDocumentRequestBuilder();
}
