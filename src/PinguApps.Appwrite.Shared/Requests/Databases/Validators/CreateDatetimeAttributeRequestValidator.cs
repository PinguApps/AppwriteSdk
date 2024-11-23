using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateDatetimeAttributeRequestValidator : AbstractValidator<CreateDatetimeAttributeRequest>
{
    public CreateDatetimeAttributeRequestValidator()
    {
        Include(new CreateAttributeBaseRequestValidator<CreateDatetimeAttributeRequest, CreateDatetimeAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .Must((request, defaultValue) => !request.Required || defaultValue == null)
            .WithMessage("Default value cannot be set when attribute is required.");
    }
}
