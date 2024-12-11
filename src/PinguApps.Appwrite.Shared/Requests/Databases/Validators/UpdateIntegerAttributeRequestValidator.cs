using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateIntegerAttributeRequestValidator : AbstractValidator<UpdateIntegerAttributeRequest>
{
    public UpdateIntegerAttributeRequestValidator()
    {
        Include(new UpdateAttributeBaseRequestValidator<UpdateIntegerAttributeRequest, UpdateIntegerAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .Must((request, defaultValue) => !request.Required || defaultValue is null)
            .WithMessage("Default value cannot be set when attribute is required.")
            .Must((request, defaultValue) => defaultValue is null || defaultValue >= request.Min)
            .WithMessage("Default cannot be a smaller value than Min.")
            .Must((request, defaultValue) => defaultValue is null || defaultValue <= request.Max)
            .WithMessage("Default cannot be a larger value than Max.");

        RuleFor(x => x.Max)
            .Must((request, max) => max >= request.Min)
            .WithMessage("Max can not be a lower value than Min.");
    }
}
