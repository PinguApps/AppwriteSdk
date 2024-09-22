using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class UpdateMfaRequestValidator : AbstractValidator<UpdateMfaRequest>
{
    public UpdateMfaRequestValidator()
    {
        RuleFor(x => x.MfaEnabled)
            .NotNull().WithMessage("MfaEnabled is required.");
    }
}
