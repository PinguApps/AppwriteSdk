using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAccountRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$");
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(256);
        RuleFor(x => x.Name).MaximumLength(128);
    }
}
