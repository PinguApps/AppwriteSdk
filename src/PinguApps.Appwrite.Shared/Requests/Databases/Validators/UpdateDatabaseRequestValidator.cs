using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateDatabaseRequestValidator : AbstractValidator<UpdateDatabaseRequest>
{
    public UpdateDatabaseRequestValidator()
    {
        Include(new DatabaseIdBaseRequestValidator<UpdateDatabaseRequest, UpdateDatabaseRequestValidator>());

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
