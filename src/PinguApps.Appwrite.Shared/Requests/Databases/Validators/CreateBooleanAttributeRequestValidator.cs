using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateBooleanAttributeRequestValidator : AbstractValidator<CreateBooleanAttributeRequest>
{
    public CreateBooleanAttributeRequestValidator()
    {
        Include(new CreateAttributeBaseRequestValidator<CreateBooleanAttributeRequest, CreateBooleanAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .Must((request, defaultValue) => !request.Required || defaultValue is null)
            .WithMessage("Default value cannot be set when attribute is required.");
    }
}
