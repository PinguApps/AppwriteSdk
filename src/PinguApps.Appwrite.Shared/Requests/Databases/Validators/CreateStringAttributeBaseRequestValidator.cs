using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateStringAttributeBaseRequestValidator<TRequest, TValidator> : AbstractValidator<CreateStringAttributeBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public CreateStringAttributeBaseRequestValidator()
    {
        Include(new CreateAttributeBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.Default)
            .Must((request, defaultValue) => !request.Required || defaultValue is null)
            .WithMessage("Default value cannot be set when attribute is required.");
    }
}
