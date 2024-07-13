using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreateEmailTokenRequestValidator : AbstractValidator<CreateEmailTokenRequest>
{
    public CreateEmailTokenRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$");
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
