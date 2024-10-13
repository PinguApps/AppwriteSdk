using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserTargetRequestValidator : AbstractValidator<CreateUserTargetRequest>
{
    public CreateUserTargetRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<CreateUserTargetRequest, CreateUserTargetRequestValidator>());

        RuleFor(x => x.TargetId)
            .NotEmpty()
            .WithMessage("TargetId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("TargetId must be 1-36 characters long and can contain letters, numbers, periods, hyphens, and underscores. It cannot start with a special character.");

        RuleFor(x => x.ProviderType)
            .IsInEnum()
            .WithMessage("ProviderType must be a valid enum value.");

        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage("Identifier is required.");

        RuleFor(x => x.ProviderId)
            .NotEmpty()
            .When(x => x.ProviderId is not null)
            .WithMessage("Identifier must either be null or have a non empty string value.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .When(x => x.Name is not null)
            .WithMessage("Name must either be null or have a non empty string value.")
            .MaximumLength(128)
            .WithMessage("Name must be at most 128 characters long.");
    }
}
