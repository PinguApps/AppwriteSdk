using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;
public class CreatePushTargetRequestValidator : AbstractValidator<CreatePushTargetRequest>
{
    public CreatePushTargetRequestValidator()
    {
        RuleFor(x => x.TargetId)
            .NotEmpty()
            .WithMessage("TargetId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("TargetId must be 1-36 characters long and can contain letters, numbers, periods, hyphens, and underscores. It cannot start with a special character.");

        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage("Identifier is required.");

        RuleFor(x => x.ProviderId)
            .NotEmpty()
            .WithMessage("ProviderId should not be an empty string - it should be null or have content.")
            .When(x => x.ProviderId is not null);
    }
}
