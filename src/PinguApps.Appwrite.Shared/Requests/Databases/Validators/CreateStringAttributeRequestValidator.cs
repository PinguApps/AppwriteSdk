using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateStringAttributeRequestValidator : AbstractValidator<CreateStringAttributeRequest>
{
    public CreateStringAttributeRequestValidator()
    {
        Include(new CreateStringAttributeBaseRequestValidator<CreateStringAttributeRequest, CreateStringAttributeRequestValidator>());

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithMessage("Size should be greater than 0")
            .LessThan(1_073_741_825)
            .WithMessage("Size should be less than 1,073,741,825");

        RuleFor(x => x.Encrypt)
            .NotNull()
            .WithMessage("Encrypt should not be null");

        RuleFor(x => x.Default)
            .Length(x => 0, x => x.Size)
            .When(x => x.Default is not null)
            .WithMessage("Default should be between {MinLength} and {MaxLength} characters long");
    }
}
