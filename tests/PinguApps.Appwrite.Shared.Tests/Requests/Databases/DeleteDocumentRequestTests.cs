using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class DeleteDocumentRequestTests : DatabaseCollectionDocumentIdBaseRequestTests<DeleteDocumentRequest, DeleteDocumentRequestValidator>
{
    protected override DeleteDocumentRequest CreateValidDatabaseCollectionDocumentIdRequest => new();
}
