using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreateEmailVerificationConfirmationRequestValidator : AbstractValidator<CreateEmailVerificationConfirmationRequest>
{
    public CreateEmailVerificationConfirmationRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$");
        RuleFor(x => x.Secret).NotEmpty();
    }
}
