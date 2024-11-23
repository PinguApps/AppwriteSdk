using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DatabaseCollectionIdIndexKeyBaseRequestValidator<TRequest, TValidator> : AbstractValidator<DatabaseCollectionIdIndexKeyBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public DatabaseCollectionIdIndexKeyBaseRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.Key)
            .NotEmpty()
            .WithMessage("Key is required.");
    }
}
