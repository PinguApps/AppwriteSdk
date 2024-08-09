using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class AddAuthenticatorRequestValidator : AbstractValidator<AddAuthenticatorRequest>
{
    public AddAuthenticatorRequestValidator()
    {
        RuleFor(x => x.Type).NotEmpty();
    }
}
