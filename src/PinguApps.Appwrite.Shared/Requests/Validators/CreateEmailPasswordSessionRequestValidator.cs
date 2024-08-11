using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreateEmailPasswordSessionRequestValidator : AbstractValidator<CreateEmailPasswordSessionRequest>
{
    public CreateEmailPasswordSessionRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(256);
    }
}
