using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="CreateEmailPasswordSessionRequest"/>
/// </summary>
public class CreateEmailPasswordSessionRequestValidator : AbstractValidator<CreateEmailPasswordSessionRequest>
{
    public CreateEmailPasswordSessionRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
    }
}
