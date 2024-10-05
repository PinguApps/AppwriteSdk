using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class DeleteAuthenticatorRequestValidator : AbstractValidator<DeleteAuthenticatorRequest>
{
    public DeleteAuthenticatorRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<DeleteAuthenticatorRequest, DeleteAuthenticatorRequestValidator>());

        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Type is required.");
    }
}
