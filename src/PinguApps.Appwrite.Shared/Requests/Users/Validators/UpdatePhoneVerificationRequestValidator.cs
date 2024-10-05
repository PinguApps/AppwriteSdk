using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdatePhoneVerificationRequestValidator : AbstractValidator<UpdatePhoneVerificationRequest>
{
    public UpdatePhoneVerificationRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdatePhoneVerificationRequest, UpdatePhoneVerificationRequestValidator>());

        RuleFor(x => x.PhoneVerification)
            .NotNull()
            .WithMessage("Phone verification status is required.");
    }
}
