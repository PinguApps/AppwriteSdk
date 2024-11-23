using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateCollectionRequestValidator : AbstractValidator<UpdateCollectionRequest>
{
    public UpdateCollectionRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<UpdateCollectionRequest, UpdateCollectionRequestValidator>());

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(128)
            .WithMessage("Name cannot exceed 128 characters.");

        RuleFor(x => x.Permissions)
            .NotNull()
            .WithMessage("Permissions cannot be null.");

        RuleFor(x => x.DocumentSecurity)
            .NotNull()
            .WithMessage("DocumentSecurity is required.");

        RuleFor(x => x.Enabled)
            .NotNull()
            .WithMessage("Enabled is required.");
    }
}
