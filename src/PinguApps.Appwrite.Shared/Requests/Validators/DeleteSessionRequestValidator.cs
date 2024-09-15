using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class DeleteSessionRequestValidator : AbstractValidator<DeleteSessionRequest>
{
    public DeleteSessionRequestValidator()
    {
        RuleFor(x => x.SessionId).NotEmpty();
    }
}
