using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateAttributeBaseRequestValidator<TRequest, TValidator> : AbstractValidator<UpdateAttributeBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public UpdateAttributeBaseRequestValidator()
    {
        Include(new DatabaseCollectionIdAttributeKeyBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.Required)
            .NotNull()
            .WithMessage("Required is required.");

        RuleFor(x => x.NewKey)
            .NotEmpty()
            .When(x => x.NewKey is not null)
            .WithMessage("NewKey must either be null or a non empty string");
    }
}
