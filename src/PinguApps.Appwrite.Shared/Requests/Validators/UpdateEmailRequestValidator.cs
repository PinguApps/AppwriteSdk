using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class UpdateEmailRequestValidator : AbstractValidator<UpdateEmailRequest>
{
    public UpdateEmailRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}
