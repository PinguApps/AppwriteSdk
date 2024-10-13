using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdateEmailVerificationRequestValidator : AbstractValidator<UpdateEmailVerificationRequest>
{
    public UpdateEmailVerificationRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdateEmailVerificationRequest, UpdateEmailVerificationRequestValidator>());

        RuleFor(x => x.EmailVerification)
            .NotNull()
            .WithMessage("Email verification status is required.");
    }
}
