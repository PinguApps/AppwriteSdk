using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdateMfaRequestValidator : AbstractValidator<UpdateMfaRequest>
{
    public UpdateMfaRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdateMfaRequest, UpdateMfaRequestValidator>());

        RuleFor(x => x.Mfa)
            .NotNull()
            .WithMessage("Mfa must be specified.");
    }
}
