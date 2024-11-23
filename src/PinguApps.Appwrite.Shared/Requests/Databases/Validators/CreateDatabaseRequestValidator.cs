using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateDatabaseRequestValidator : AbstractValidator<CreateDatabaseRequest>
{
    public CreateDatabaseRequestValidator()
    {
        RuleFor(x => x.DatabaseId)
            .NotEmpty()
            .WithMessage("DatabaseId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("DatabaseId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special character. Max length is 36 chars.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(128)
            .WithMessage("Name can have a maximum length of 128 characters.");

        RuleFor(x => x.Enabled)
            .NotNull()
            .WithMessage("Enabled is required.");
    }
}
