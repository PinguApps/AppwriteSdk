using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DeleteDocumentRequestValidator : AbstractValidator<DeleteDocumentRequest>
{
    public DeleteDocumentRequestValidator()
    {
        Include(new DatabaseCollectionDocumentIdBaseRequestValidator<DeleteDocumentRequest, DeleteDocumentRequestValidator>());
    }
}
