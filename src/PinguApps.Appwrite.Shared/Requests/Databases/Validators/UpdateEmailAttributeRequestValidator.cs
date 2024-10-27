using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateEmailAttributeRequestValidator : AbstractValidator<UpdateEmailAttributeRequest>
{
    public UpdateEmailAttributeRequestValidator()
    {
        Include(new UpdateStringAttributeBaseRequestValidator<UpdateEmailAttributeRequest, UpdateEmailAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .EmailAddress()
            .WithMessage("Default should be formatted as an email address");
    }
}
