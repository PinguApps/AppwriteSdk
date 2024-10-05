using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdateUserTargertRequestValidator : AbstractValidator<UpdateUserTargertRequest>
{
    public UpdateUserTargertRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdateUserTargertRequest, UpdateUserTargertRequestValidator>());

        RuleFor(x => x.TargetId)
            .NotEmpty()
            .WithMessage("Target ID is required.");

        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage("Identifier must either be null or a non empty string.")
            .When(x => x.Identifier != null);

        RuleFor(x => x.ProviderId)
            .NotEmpty()
            .WithMessage("Provider must either be null or a non empty string.")
            .When(x => x.ProviderId != null);

        RuleFor(x => x.Name)
            .MaximumLength(128)
            .WithMessage("Name cannot exceed 128 characters.")
            .NotEmpty()
            .WithMessage("Name must either be null or a non empty string.")
            .When(x => x.Name != null);
    }
}
