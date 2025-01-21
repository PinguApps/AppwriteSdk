using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateDocumentRequestValidator<TData> : AbstractValidator<CreateDocumentRequest<TData>>
    where TData : class
{
    public CreateDocumentRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<CreateDocumentRequest<TData>, CreateDocumentRequestValidator<TData>>());

        RuleFor(x => x.DocumentId)
            .NotEmpty()
            .WithMessage("DocumentId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("DocumentId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special character. Max length is 36 characters.");

        RuleFor(x => x.Data)
            .NotNull()
            .WithMessage("Data is required.");
    }
}
