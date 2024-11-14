using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateDocumentRequestValidator : AbstractValidator<UpdateDocumentRequest>
{
    public UpdateDocumentRequestValidator()
    {
        Include(new DatabaseCollectionDocumentIdBaseRequestValidator<UpdateDocumentRequest, UpdateDocumentRequestValidator>());

        RuleFor(x => x.Data)
            .NotNull()
            .WithMessage("Data is required.");

        RuleFor(x => x.Permissions)
            .NotNull()
            .WithMessage("Permissions cannot be null.");
    }
}
