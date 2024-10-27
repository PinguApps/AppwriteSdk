using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateAttributeBaseRequestValidator<TRequest, TValidator> : AbstractValidator<CreateAttributeBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public CreateAttributeBaseRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.Key)
            .NotEmpty()
            .WithMessage("Key is required.");

        RuleFor(x => x.Required)
            .NotEmpty()
            .WithMessage("Required is required.");

        RuleFor(x => x.Array)
            .NotEmpty()
            .WithMessage("Array is required.");
    }
}
