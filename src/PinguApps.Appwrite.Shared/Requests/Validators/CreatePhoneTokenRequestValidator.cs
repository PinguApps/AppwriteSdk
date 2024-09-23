using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreatePhoneTokenRequestValidator : AbstractValidator<CreatePhoneTokenRequest>
{
    public CreatePhoneTokenRequestValidator()
    {
        RuleFor(request => request.UserId)
            .NotEmpty().WithMessage("User ID must not be empty.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("User ID must be alphanumeric and can include periods, hyphens, and underscores. It cannot start with a special character and must be at most 36 characters long.");

        RuleFor(request => request.PhoneNumber)
            .NotEmpty().WithMessage("Phone number must not be empty.")
            .Matches(@"^\+\d{1,15}$").WithMessage("Phone number must start with a '+' and include the country code, followed by up to 15 digits.");
    }
}
