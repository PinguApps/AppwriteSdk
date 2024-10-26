using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DatabaseCollectionIdAttributeKeyBaseRequestValidator<TRequest, TValidator> : AbstractValidator<DatabaseCollectionIdAttributeKeyBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public DatabaseCollectionIdAttributeKeyBaseRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.Key)
            .NotEmpty()
            .WithMessage("Key is required.");
    }
}
