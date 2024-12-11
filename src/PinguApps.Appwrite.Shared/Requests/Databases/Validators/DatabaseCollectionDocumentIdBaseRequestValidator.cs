using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DatabaseCollectionDocumentIdBaseRequestValidator<TRequest, TValidator> : AbstractValidator<DatabaseCollectionDocumentIdBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public DatabaseCollectionDocumentIdBaseRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.DocumentId)
            .NotEmpty()
            .WithMessage("DocumentId is required.");
    }
}
