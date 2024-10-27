using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateEmailAttributeRequestValidator : AbstractValidator<CreateEmailAttributeRequest>
{
    public CreateEmailAttributeRequestValidator()
    {
        Include(new CreateStringAttributeBaseRequestValidator<CreateEmailAttributeRequest, CreateEmailAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .EmailAddress()
            .WithMessage("Default should be formatted as an email address");
    }
}
