using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdatePhoneRequestValidator : AbstractValidator<UpdatePhoneRequest>
{
    public UpdatePhoneRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdatePhoneRequest, UpdatePhoneRequestValidator>());

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+\d{1,15}$")
            .WithMessage("Phone number must be in the format '+[country code][number]', e.g., +16175551212.");
    }
}
