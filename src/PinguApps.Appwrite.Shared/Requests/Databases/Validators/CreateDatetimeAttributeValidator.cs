using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateDatetimeAttributeValidator : AbstractValidator<CreateDatetimeAttribute>
{
    public CreateDatetimeAttributeValidator()
    {
        Include(new CreateAttributeBaseRequestValidator<CreateDatetimeAttribute, CreateDatetimeAttributeValidator>());

        RuleFor(x => x.Default)
            .Must((request, defaultValue) => !request.Required || defaultValue == null)
            .WithMessage("Default value cannot be set when attribute is required.");
    }
}
