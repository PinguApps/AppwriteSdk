using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DeleteIndexRequestValidator : AbstractValidator<DeleteIndexRequest>
{
    public DeleteIndexRequestValidator()
    {
        Include(new DatabaseCollectionIdIndexKeyBaseRequestValidator<DeleteIndexRequest, DeleteIndexRequestValidator>());
    }
}
