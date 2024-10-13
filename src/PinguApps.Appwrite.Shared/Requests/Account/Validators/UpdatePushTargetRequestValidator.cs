using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;
public class UpdatePushTargetRequestValidator : AbstractValidator<UpdatePushTargetRequest>
{
    public UpdatePushTargetRequestValidator()
    {
        RuleFor(x => x.TargetId)
            .NotEmpty().WithMessage("TargetId is required.");

        RuleFor(x => x.Identifier)
            .NotEmpty().WithMessage("Identifier is required.");
    }
}
