using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class DeleteUserSessionRequestValidator : AbstractValidator<DeleteUserSessionRequest>
{
    public DeleteUserSessionRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<DeleteUserSessionRequest, DeleteUserSessionRequestValidator>());

        RuleFor(x => x.SessionId)
            .NotEmpty()
            .WithMessage("SessionId is required.");
    }
}
