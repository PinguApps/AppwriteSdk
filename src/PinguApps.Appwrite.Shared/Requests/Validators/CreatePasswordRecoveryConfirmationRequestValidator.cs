using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreatePasswordRecoveryConfirmationRequestValidator : AbstractValidator<CreatePasswordRecoveryConfirmationRequest>
{
    public CreatePasswordRecoveryConfirmationRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Secret).NotEmpty();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(256);
    }
}
