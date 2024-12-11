using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateStringAttributeRequestValidator : AbstractValidator<UpdateStringAttributeRequest>
{
    public UpdateStringAttributeRequestValidator()
    {
        Include(new UpdateStringAttributeBaseRequestValidator<UpdateStringAttributeRequest, UpdateStringAttributeRequestValidator>());

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithMessage("Size should be greater than 0")
            .LessThan(1_073_741_825)
            .WithMessage("Size should be less than 1,073,741,825")
            .When(x => x.Size is not null);

        RuleFor(x => x.Default)
            .Length(x => 0, x => x.Size!.Value)
            .When(x => x.Default is not null)
            .WithMessage("Default should be between {MinLength} and {MaxLength} characters long")
            .When(x => x.Size is not null && x.Default is not null);
    }
}
