using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;
public class DeletePushTargetRequestValidator : AbstractValidator<DeletePushTargetRequest>
{
    public DeletePushTargetRequestValidator()
    {
        RuleFor(x => x.TargetId)
            .NotEmpty().WithMessage("TargetId is required.");
    }
}
