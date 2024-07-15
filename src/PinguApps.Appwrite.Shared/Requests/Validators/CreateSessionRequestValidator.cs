using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class CreateSessionRequestValidator : AbstractValidator<CreateSessionRequest>
{
    public CreateSessionRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$");
        RuleFor(x => x.Secret).NotEmpty();
    }
}
