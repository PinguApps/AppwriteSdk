using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateDocumentRequestValidator : AbstractValidator<UpdateDocumentRequest>
{
    public UpdateDocumentRequestValidator()
    {
        Include(new DatabaseCollectionDocumentIdBaseRequestValidator<UpdateDocumentRequest, UpdateDocumentRequestValidator>());

        RuleFor(x => x)
            .Must(x => (x.Data?.Count > 0) || x.Permissions != null)
            .WithMessage("Either Data must contain at least one item or Permissions must be provided.");
    }
}
