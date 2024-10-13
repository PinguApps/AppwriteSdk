using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="UpdatePasswordRequest"/>
/// </summary>
public class UpdatePasswordRequestValidator : AbstractValidator<UpdatePasswordRequest>
{
    public UpdatePasswordRequestValidator()
    {
        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("NewPassword is required.")
            .MinimumLength(8).WithMessage("NewPassword must be at least 8 characters long.");

        RuleFor(x => x.OldPassword)
            .MinimumLength(8).When(x => x.OldPassword is not null).WithMessage("OldPassword must be at least 8 characters long.");
    }
}
