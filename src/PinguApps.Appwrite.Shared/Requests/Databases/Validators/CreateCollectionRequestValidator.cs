using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateCollectionRequestValidator : AbstractValidator<CreateCollectionRequest>
{
    public CreateCollectionRequestValidator()
    {
        Include(new DatabaseIdBaseRequestValidator<CreateCollectionRequest, CreateCollectionRequestValidator>());

        RuleFor(x => x.CollectionId)
            .NotEmpty()
            .WithMessage("CollectionId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("CollectionId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special character. Max length is 36 characters.");

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
