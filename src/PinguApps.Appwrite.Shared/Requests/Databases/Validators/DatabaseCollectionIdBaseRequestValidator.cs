using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DatabaseCollectionIdBaseRequestValidator<TRequest, TValidator> : AbstractValidator<DatabaseCollectionIdBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public DatabaseCollectionIdBaseRequestValidator()
    {
        Include(new DatabaseIdBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.CollectionId)
            .NotEmpty()
            .WithMessage("CollectionId is required.");
    }
}
