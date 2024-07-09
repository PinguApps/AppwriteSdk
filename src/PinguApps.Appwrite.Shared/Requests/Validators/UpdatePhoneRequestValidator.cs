using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class UpdatePhoneRequestValidator : AbstractValidator<UpdatePhoneRequest>
{
    public UpdatePhoneRequestValidator()
    {
        RuleFor(x => x.Phone).NotEmpty().Matches("^\\+\\d*$");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}
