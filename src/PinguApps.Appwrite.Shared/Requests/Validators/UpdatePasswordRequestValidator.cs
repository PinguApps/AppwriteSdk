using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class UpdatePasswordRequestValidator : AbstractValidator<UpdatePasswordRequest>
{
    public UpdatePasswordRequestValidator()
    {
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8);
        RuleFor(x => x.OldPassword).MinimumLength(8).When(x => x.OldPassword is not null);
    }
}
