using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateBooleanAttributeRequestValidator : AbstractValidator<UpdateBooleanAttributeRequest>
{
    public UpdateBooleanAttributeRequestValidator()
    {
        Include(new UpdateAttributeBaseRequestValidator<UpdateBooleanAttributeRequest, UpdateBooleanAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .Must((request, defaultValue) => !request.Required || defaultValue == null)
            .WithMessage("Default value cannot be set when attribute is required.");
    }
}
