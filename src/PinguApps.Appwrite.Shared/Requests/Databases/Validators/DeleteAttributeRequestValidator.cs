using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DeleteAttributeRequestValidator : AbstractValidator<DeleteAttributeRequest>
{
    public DeleteAttributeRequestValidator()
    {
        Include(new DatabaseCollectionIdAttributeKeyBaseRequestValidator<DeleteAttributeRequest, DeleteAttributeRequestValidator>());
    }
}
