using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateStringAttributeBaseRequestValidator<TRequest, TValidator> : AbstractValidator<UpdateStringAttributeBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public UpdateStringAttributeBaseRequestValidator()
    {
        Include(new UpdateAttributeBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.Default)
            .Must((request, defaultValue) => !request.Required || defaultValue is null)
            .WithMessage("Default value cannot be set when attribute is required.");
    }
}
