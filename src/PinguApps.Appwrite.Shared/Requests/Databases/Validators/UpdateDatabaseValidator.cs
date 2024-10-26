using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateDatabaseValidator : AbstractValidator<UpdateDatabase>
{
    public UpdateDatabaseValidator()
    {
        Include(new DatabaseIdBaseRequestValidator<UpdateDatabase, UpdateDatabaseValidator>());

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(128)
            .WithMessage("Name cannot exceed 128 characters.");

        RuleFor(x => x.Enabled)
            .NotNull()
            .WithMessage("Enabled is required.");
    }
}
