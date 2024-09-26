using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="UpdateMfaRequest"/>
/// </summary>
public class UpdateMfaRequestValidator : AbstractValidator<UpdateMfaRequest>
{
    public UpdateMfaRequestValidator()
    {
        RuleFor(x => x.MfaEnabled)
            .NotNull().WithMessage("MfaEnabled is required.");
    }
}
