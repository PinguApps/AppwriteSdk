using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DeleteCollectionRequestValidator : AbstractValidator<DeleteCollectionRequest>
{
    public DeleteCollectionRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<DeleteCollectionRequest, DeleteCollectionRequestValidator>());
    }
}
