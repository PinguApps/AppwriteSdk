using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateDatetimeAttributeRequestValidator : AbstractValidator<UpdateDatetimeAttributeRequest>
{
    public UpdateDatetimeAttributeRequestValidator()
    {
        Include(new UpdateAttributeBaseRequestValidator<UpdateDatetimeAttributeRequest, UpdateDatetimeAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .Must((request, defaultValue) => !request.Required || defaultValue == null)
            .WithMessage("Default value cannot be set when attribute is required.");
    }
}
