using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdateEmailRequestValidator : AbstractValidator<UpdateEmailRequest>
{
    public UpdateEmailRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdateEmailRequest, UpdateEmailRequestValidator>());

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
    }
}
